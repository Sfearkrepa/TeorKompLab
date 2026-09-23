using System;
using System.Collections.Generic;

namespace TeorKomp_Lab1
{
    public enum TokenType
    {
        Keyword,
        Identifier,
        Number,
        Operator,
        Separator,
        Punctuation,
        Type,
        Unknown,
        Comment
    }

    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
        public int Index { get; set; }

        public Token(TokenType type, string value, int line, int column, int index)
        {
            Type = type;
            Value = value;
            Line = line;
            Column = column;
            Index = index;
        }
    }

    public class LexError
    {
        public string Message { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
        public int Index { get; set; }

        public LexError(string message, int line, int column, int index)
        {
            Message = message;
            Line = line;
            Column = column;
            Index = index;
        }
    }

    public class LexResult
    {
        public List<Token> Tokens { get; } = new List<Token>();
        public List<LexError> Errors { get; } = new List<LexError>();
    }

    public class LexicalAnalyzer
    {
        private static readonly HashSet<string> Keywords = new HashSet<string>
        {
            "const", "var", "struct", "enum", "union", "fn", "pub",
            "return", "if", "else", "while", "for", "break", "continue"
        };

        private static readonly HashSet<string> BuiltinTypes = new HashSet<string>
        {
            "u8", "u16", "u32", "u64", "i8", "i16", "i32", "i64",
            "f16", "f32", "f64", "bool", "void", "usize", "isize"
        };

        private string _input;
        private int _pos;
        private int _line;
        private int _column;
        private LexResult _result;

        public LexResult Analyze(string input)
        {
            _input = input ?? string.Empty;
            _pos = 0;
            _line = 1;
            _column = 1;
            _result = new LexResult();

            while (_pos < _input.Length)
            {
                char c = _input[_pos];

                if (c == '\r')
                {
                    _pos++;
                    continue;
                }

                if (c == '\n')
                {
                    _pos++;
                    _line++;
                    _column = 1;
                    continue;
                }

                if (char.IsWhiteSpace(c))
                {
                    _pos++;
                    _column++;
                    continue;
                }

                if (c == '/' && Peek(1) == '/')
                {
                    SkipLineComment();
                    continue;
                }

                if (char.IsLetter(c) || c == '_')
                {
                    ReadIdentifierOrKeyword();
                    continue;
                }

                if (char.IsDigit(c))
                {
                    ReadNumber();
                    continue;
                }

                if (IsPunctuation(c))
                {
                    AddToken(TokenType.Punctuation, c.ToString());
                    _pos++;
                    _column++;
                    continue;
                }

                if (IsOperator(c))
                {
                    ReadOperator();
                    continue;
                }

                _result.Errors.Add(new LexError(
                    $"Ошибка: недопустимый символ '{c}' в строке {_line}, позиция {_column}",
                    _line, _column, _pos));
                AddToken(TokenType.Unknown, c.ToString());
                _pos++;
                _column++;
            }

            return _result;
        }

        private char Peek(int offset)
        {
            int index = _pos + offset;
            return index < _input.Length ? _input[index] : '\0';
        }

        private void AddToken(TokenType type, string value)
        {
            _result.Tokens.Add(new Token(type, value, _line, _column, _pos));
        }

        private void ReadIdentifierOrKeyword()
        {
            int startLine = _line;
            int startColumn = _column;
            int start = _pos;

            while (_pos < _input.Length && (char.IsLetterOrDigit(_input[_pos]) || _input[_pos] == '_'))
            {
                _pos++;
                _column++;
            }

            string value = _input.Substring(start, _pos - start);

            TokenType type;
            if (Keywords.Contains(value)) type = TokenType.Keyword;
            else if (BuiltinTypes.Contains(value)) type = TokenType.Type;
            else type = TokenType.Identifier;

            _result.Tokens.Add(new Token(type, value, startLine, startColumn, start));
        }

        private void ReadNumber()
        {
            int startLine = _line;
            int startColumn = _column;
            int start = _pos;

            while (_pos < _input.Length && char.IsDigit(_input[_pos]))
            {
                _pos++;
                _column++;
            }

            if (_pos < _input.Length && _input[_pos] == '.' &&
                _pos + 1 < _input.Length && char.IsDigit(_input[_pos + 1]))
            {
                _pos++;
                _column++;
                while (_pos < _input.Length && char.IsDigit(_input[_pos]))
                {
                    _pos++;
                    _column++;
                }
            }

            string value = _input.Substring(start, _pos - start);
            _result.Tokens.Add(new Token(TokenType.Number, value, startLine, startColumn, start));
        }

        private void ReadOperator()
        {
            int startLine = _line;
            int startColumn = _column;
            int start = _pos;

            char c = _input[_pos];
            char next = Peek(1);

            string twoChar = c.ToString() + next;
            if (next != '\0' && (twoChar == "==" || twoChar == "!=" || twoChar == "<=" ||
                                 twoChar == ">=" || twoChar == "=>" || twoChar == "->" ||
                                 twoChar == "<<" || twoChar == ">>" || twoChar == "++" ||
                                 twoChar == "--"))
            {
                _result.Tokens.Add(new Token(TokenType.Operator, twoChar, startLine, startColumn, start));
                _pos += 2;
                _column += 2;
                return;
            }

            _result.Tokens.Add(new Token(TokenType.Operator, c.ToString(), startLine, startColumn, start));
            _pos++;
            _column++;
        }

        private void SkipLineComment()
        {
            while (_pos < _input.Length && _input[_pos] != '\n')
            {
                _pos++;
                _column++;
            }
        }

        private static bool IsPunctuation(char c)
        {
            return c == '{' || c == '}' || c == '(' || c == ')' ||
                   c == '[' || c == ']' || c == ',' || c == ';' ||
                   c == ':' || c == '.';
        }

        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' ||
                   c == '%' || c == '=' || c == '<' || c == '>' ||
                   c == '!' || c == '&' || c == '|' || c == '^' ||
                   c == '~' || c == '?';
        }

        public static string TypeToRussian(TokenType type)
        {
            switch (type)
            {
                case TokenType.Keyword: return "ключевое слово";
                case TokenType.Identifier: return "идентификатор";
                case TokenType.Number: return "число";
                case TokenType.Operator: return "оператор";
                case TokenType.Separator: return "разделитель";
                case TokenType.Punctuation: return "разделитель";
                case TokenType.Type: return "тип";
                case TokenType.Comment: return "комментарий";
                default: return "недопустимый символ";
            }
        }

        public static string TypeToEnglish(TokenType type)
        {
            switch (type)
            {
                case TokenType.Keyword: return "keyword";
                case TokenType.Identifier: return "identifier";
                case TokenType.Number: return "number";
                case TokenType.Operator: return "operator";
                case TokenType.Separator: return "separator";
                case TokenType.Punctuation: return "separator";
                case TokenType.Type: return "type";
                case TokenType.Comment: return "comment";
                default: return "unknown";
            }
        }
    }
}