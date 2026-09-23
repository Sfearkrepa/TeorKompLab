using System;
using System.Collections.Generic;

namespace TeorKomp_Lab1
{
    public class SyntaxError
    {
        public string Fragment { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }

        public SyntaxError(string fragment, int line, int column, int index, string description)
        {
            Fragment = fragment;
            Line = line;
            Column = column;
            Index = index;
            Description = description;
        }
    }

    public class SyntaxResult
    {
        public List<SyntaxError> Errors { get; } = new List<SyntaxError>();
        public bool Success => Errors.Count == 0;
    }

    public class SyntaxAnalyzer
    {
        private List<Token> _tokens;
        private int _pos;
        private SyntaxResult _result;

        public SyntaxResult Analyze(List<Token> tokens)
        {
            _tokens = tokens ?? new List<Token>();
            _pos = 0;
            _result = new SyntaxResult();

            ParseZ();

            return _result;
        }

        private Token Current
        {
            get
            {
                if (_pos < _tokens.Count) return _tokens[_pos];
                return new Token(TokenType.Unknown, "EOF", 0, 0, 0);
            }
        }

        private bool IsEOF => _pos >= _tokens.Count;

        private void Next()
        {
            if (_pos < _tokens.Count) _pos++;
        }

        private void ReportError(string description)
        {
            var t = Current;
            string fragment = IsEOF ? "<конец файла>" : t.Value;

            _result.Errors.Add(new SyntaxError(
                fragment, t.Line, t.Column, t.Index, description));
        }

        private bool IsIdentLike(TokenType type)
        {
            return type == TokenType.Identifier
                || type == TokenType.Type
                || (type == TokenType.Keyword);
        }

        private bool IsFieldSyncToken(TokenType type)
        {
            return type == TokenType.Punctuation && false;
        }

        private bool IsSyncForFields()
        {
            if (IsEOF) return true;
            var v = Current.Value;
            return v == "," || v == "}" || v == ";";
        }

        private bool IsSyncForDecl()
        {
            if (IsEOF) return true;
            return Current.Value == "const" || Current.Value == ";";
        }

        private void SkipToFieldsSync()
        {
            while (!IsEOF && !IsSyncForFields()) Next();
        }

        private void SkipToDeclSync()
        {
            while (!IsEOF && !IsSyncForDecl()) Next();
        }

        private void ParseZ()
        {
            if (IsEOF)
            {
                ReportError("Ожидалось объявление структуры");
                return;
            }

            ParseDecl();

            while (!IsEOF)
            {
                if (Current.Value == "const")
                {
                    ParseDecl();
                }
                else
                {
                    ReportError("Ожидалось ключевое слово 'const' в начале объявления");
                    SkipToDeclSync();
                    if (!IsEOF && Current.Value == ";") Next();
                }
            }
        }

        private void ParseDecl()
        {
            Expect("const", "Ожидалось ключевое слово 'const'");

            if (!IsIdentLike(Current.Type))
            {
                ReportError("Ожидался идентификатор имени структуры");
                SkipToDeclSync();
                if (!IsEOF && Current.Value == ";") Next();
                return;
            }
            Next();

            Expect("=", "Ожидался символ '='");
            Expect("struct", "Ожидалось ключевое слово 'struct'");
            Expect("{", "Ожидалась открывающая фигурная скобка '{'");

            if (Current.Value == "}")
            {
                Next();
            }
            else
            {
                ParseFields();
                Expect("}", "Ожидалась закрывающая фигурная скобка '}'");
            }

            Expect(";", "Ожидался символ ';' в конце объявления");
        }

        private void ParseFields()
        {
            ParseField();

            while (Current.Value == ",")
            {
                Next();

                if (Current.Value == "}")
                    return;

                ParseField();
            }
        }

        private void ParseField()
        {
            if (!IsIdentLike(Current.Type))
            {
                ReportError("Ожидался идентификатор имени поля");
                SkipToFieldsSync();
                if (Current.Value == ",") Next();
                return;
            }
            Next();

            Expect(":", "Ожидался символ ':' после имени поля");

            ParseType();
        }

        private void ParseType()
        {
            if (Current.Value == "[")
            {
                Next();
                Expect("]", "Ожидалась закрывающая квадратная скобка ']'");
                Expect("const", "Ожидалось ключевое слово 'const' после '[]'");
                ParseType();
                return;
            }

            if (IsIdentLike(Current.Type))
            {
                Next();
                return;
            }

            ReportError("Ожидался тип поля");
            SkipToFieldsSync();
        }

        private void Expect(string expectedValue, string errorDescription)
        {
            if (!IsEOF && Current.Value == expectedValue)
            {
                Next();
                return;
            }

            ReportError(errorDescription);

            if (!IsEOF && Current.Value == expectedValue)
            {
                Next();
            }
        }
    }
}