using System;
using System.Collections.Generic;

namespace TeorKomp_Lab1
{
    public class SemanticError
    {
        public string Fragment { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
        public int Index { get; set; }
        public string Message { get; set; }

        public SemanticError(string fragment, int line, int column, int index, string message)
        {
            Fragment = fragment;
            Line = line;
            Column = column;
            Index = index;
            Message = message;
        }
    }

    public class SemanticResult
    {
        public ProgramNode Root { get; set; }
        public List<SemanticError> Errors { get; } = new List<SemanticError>();
        public bool Success => Errors.Count == 0;
    }

    public class SemanticAnalyzer
    {
        private SymbolTable _symbols;
        private SemanticResult _result;
        private List<Token> _tokens;
        private int _pos;

        public SemanticResult Analyze(List<Token> tokens)
        {
            _tokens = tokens ?? new List<Token>();
            _pos = 0;
            _symbols = new SymbolTable();
            _result = new SemanticResult { Root = new ProgramNode() };

            while (!IsEOF)
            {
                if (Current.Value == "const")
                {
                    ParseConstDecl();
                }
                else
                {
                    Next();
                }
            }

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

        private void AddError(Token token, string message)
        {
            _result.Errors.Add(new SemanticError(
                token.Value, token.Line, token.Column, token.Index, message));
        }

        private void ParseConstDecl()
        {
            Token constToken = Current;
            Next();

            if (IsEOF || !IsIdentLike(Current.Type))
            {
                return;
            }

            Token nameToken = Current;
            Next();

            if (IsEOF || Current.Value != "=") return;
            Next();

            if (IsEOF || Current.Value != "struct") return;
            Next();

            if (IsEOF || Current.Value != "{") return;
            Next();

            var declNode = new ConstDeclNode
            {
                Name = nameToken.Value,
                Line = constToken.Line,
                Column = constToken.Column
            };
            declNode.Modifiers.Add("const");

            if (_symbols.Contains(declNode.Name))
            {
                var prev = _symbols.Lookup(declNode.Name);
                AddError(nameToken,
                    $"идентификатор \"{declNode.Name}\" уже объявлен ранее (строка {prev.Line})");
            }
            else
            {
                _symbols.Declare(new Symbol
                {
                    Name = declNode.Name,
                    Kind = SymbolKind.Struct,
                    TypeName = "struct",
                    Line = nameToken.Line,
                    Column = nameToken.Column
                });
            }

            var fieldNames = new HashSet<string>();

            while (!IsEOF && Current.Value != "}")
            {
                if (Current.Value == ",")
                {
                    Next();
                    continue;
                }

                ParseField(declNode, fieldNames);
            }

            if (!IsEOF && Current.Value == "}")
            {
                Next();
            }

            if (!IsEOF && Current.Value == ";")
            {
                Next();
            }

            _result.Root.Children.Add(declNode);
        }

        private void ParseField(ConstDeclNode decl, HashSet<string> fieldNames)
        {
            if (!IsIdentLike(Current.Type))
            {
                Next();
                return;
            }

            Token fieldName = Current;
            Next();

            if (IsEOF || Current.Value != ":")
            {
                SkipToFieldEnd();
                return;
            }
            Next();

            var typeNode = ParseType();

            ValueNode valueNode = null;

            if (!IsEOF && Current.Value == "=")
            {
                Next();
                valueNode = ParseValue();
            }

            var fieldNode = new FieldNode
            {
                Name = fieldName.Value,
                Type = typeNode,
                Value = valueNode,
                Line = fieldName.Line,
                Column = fieldName.Column
            };

            if (typeNode != null)
                fieldNode.Children.Add(typeNode);

            if (valueNode != null)
                fieldNode.Children.Add(valueNode);

            if (fieldNames.Contains(fieldName.Value))
            {
                AddError(fieldName,
                    $"поле \"{fieldName.Value}\" уже объявлено в структуре \"{decl.Name}\"");
            }
            else
            {
                fieldNames.Add(fieldName.Value);
            }

            if (typeNode != null && valueNode != null)
            {
                CheckTypeCompatibility(fieldNode, typeNode, valueNode);
                CheckValueRange(typeNode, valueNode);
            }

            decl.Fields.Add(fieldNode);
            decl.Children.Add(fieldNode);
        }

        private TypeNode ParseType()
        {
            if (IsEOF) return null;

            if (Current.Value == "[")
            {
                Next();

                if (!IsEOF && Current.Value == "]")
                {
                    Next();
                }

                if (!IsEOF && Current.Value == "const")
                {
                    Next();
                }

                var element = ParseType();

                var sliceNode = new TypeNode
                {
                    Name = "[]const",
                    IsSlice = true,
                    ElementType = element,
                    Line = element?.Line ?? Current.Line,
                    Column = element?.Column ?? Current.Column
                };

                if (element != null)
                    sliceNode.Children.Add(element);

                return sliceNode;
            }

            if (IsIdentLike(Current.Type))
            {
                Token typeToken = Current;
                Next();

                if (!_symbols.IsBuiltinType(typeToken.Value) && !_symbols.Contains(typeToken.Value))
                {
                    AddError(typeToken,
                        $"неизвестный тип \"{typeToken.Value}\"");
                }

                return new TypeNode
                {
                    Name = typeToken.Value,
                    IsSlice = false,
                    Line = typeToken.Line,
                    Column = typeToken.Column
                };
            }

            return null;
        }

        private ValueNode ParseValue()
        {
            if (IsEOF) return null;

            Token valueToken = Current;

            if (valueToken.Type == TokenType.Number)
            {
                Next();

                var node = new ValueNode
                {
                    RawValue = valueToken.Value,
                    IsNumeric = true,
                    Line = valueToken.Line,
                    Column = valueToken.Column
                };

                if (valueToken.Value.Contains("."))
                {
                    if (double.TryParse(valueToken.Value,
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out double d))
                    {
                        node.NumericValue = (long)d;
                    }
                }
                else
                {
                    if (long.TryParse(valueToken.Value, out long l))
                    {
                        node.NumericValue = l;
                    }
                }

                return node;
            }

            if (valueToken.Type == TokenType.Keyword &&
                (valueToken.Value == "true" || valueToken.Value == "false"))
            {
                Next();

                return new ValueNode
                {
                    RawValue = valueToken.Value,
                    IsBool = true,
                    BoolValue = valueToken.Value == "true",
                    Line = valueToken.Line,
                    Column = valueToken.Column
                };
            }

            if (valueToken.Value == "-" || valueToken.Value == "+")
            {
                string sign = valueToken.Value;
                Next();

                if (!IsEOF && Current.Type == TokenType.Number)
                {
                    Token numToken = Current;
                    Next();

                    string raw = sign + numToken.Value;
                    var node = new ValueNode
                    {
                        RawValue = raw,
                        IsNumeric = true,
                        Line = valueToken.Line,
                        Column = valueToken.Column
                    };

                    if (long.TryParse(raw, out long l))
                    {
                        node.NumericValue = l;
                    }

                    return node;
                }

                return null;
            }

            return null;
        }

        private void CheckTypeCompatibility(FieldNode field, TypeNode type, ValueNode value)
        {
            string typeName = type.IsSlice ? "slice" : type.Name;

            bool isIntegerType =
                typeName == "u8" || typeName == "u16" || typeName == "u32" || typeName == "u64" ||
                typeName == "i8" || typeName == "i16" || typeName == "i32" || typeName == "i64" ||
                typeName == "usize" || typeName == "isize";

            bool isFloatType =
                typeName == "f16" || typeName == "f32" || typeName == "f64";

            bool isBoolType = typeName == "bool";

            if (value.IsBool && !isBoolType)
            {
                AddError(new Token(TokenType.Unknown, value.RawValue, value.Line, value.Column, 0),
                    $"тип значения не соответствует типу поля \"{field.Name}\" ({typeName})");
                return;
            }

            if (value.IsNumeric && isBoolType)
            {
                AddError(new Token(TokenType.Unknown, value.RawValue, value.Line, value.Column, 0),
                    $"тип значения не соответствует типу поля \"{field.Name}\" ({typeName})");
                return;
            }

            if (value.IsNumeric && !isIntegerType && !isFloatType)
            {
                AddError(new Token(TokenType.Unknown, value.RawValue, value.Line, value.Column, 0),
                    $"тип значения не соответствует типу поля \"{field.Name}\" ({typeName})");
            }
        }

        private void CheckValueRange(TypeNode type, ValueNode value)
        {
            if (!value.IsNumeric || type == null || type.IsSlice) return;

            string t = type.Name;

            long min = 0, max = 0;
            bool hasRange = false;

            switch (t)
            {
                case "u8": min = 0; max = 255; hasRange = true; break;
                case "u16": min = 0; max = 65535; hasRange = true; break;
                case "u32": min = 0; max = 4294967295L; hasRange = true; break;
                case "i8": min = -128; max = 127; hasRange = true; break;
                case "i16": min = -32768; max = 32767; hasRange = true; break;
                case "i32": min = -2147483648L; max = 2147483647L; hasRange = true; break;
            }

            if (!hasRange) return;

            if (value.NumericValue < min || value.NumericValue > max)
            {
                AddError(new Token(TokenType.Unknown, value.RawValue, value.Line, value.Column, 0),
                    $"значение {value.RawValue} выходит за пределы типа {t} [{min}..{max}]");
            }
        }

        private void SkipToFieldEnd()
        {
            while (!IsEOF && Current.Value != "," && Current.Value != "}")
            {
                Next();
            }
        }

        private static bool IsIdentLike(TokenType type)
        {
            return type == TokenType.Identifier
                || type == TokenType.Type
                || type == TokenType.Keyword;
        }
    }
}