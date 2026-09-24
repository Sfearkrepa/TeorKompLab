using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TeorKomp_Lab1
{
    public class RegexMatch
    {
        public string Value { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
        public int Length { get; set; }
        public int Index { get; set; }
    }

    public class RegexSearcher
    {
        private static readonly string[] Patterns =
        {
            @"\b\d+\b",
            @"\b0[xX][0-9a-fA-F]+\b",
            @"\b[A-Z][A-Za-z0-9_]*\b"
        };

        private static readonly string[] NamesRu =
        {
            "Целые числа без знака",
            "Hex-литералы Zig",
            "Идентификаторы с заглавной буквы"
        };

        private static readonly string[] NamesEn =
        {
            "Unsigned integers",
            "Hex literals (Zig)",
            "Identifiers starting with uppercase"
        };

        public int TaskCount => Patterns.Length;

        public string GetTaskName(int index, bool russian)
        {
            if (index < 0 || index >= Patterns.Length) return string.Empty;
            return russian ? NamesRu[index] : NamesEn[index];
        }

        public List<RegexMatch> FindAll(string text, int taskIndex)
        {
            var result = new List<RegexMatch>();

            if (string.IsNullOrEmpty(text)) return result;
            if (taskIndex < 0 || taskIndex >= Patterns.Length) return result;

            string pattern = Patterns[taskIndex];
            var regex = new Regex(pattern);

            foreach (Match m in regex.Matches(text))
            {
                if (!m.Success) continue;

                int line, column;
                GetLineAndColumn(text, m.Index, out line, out column);

                result.Add(new RegexMatch
                {
                    Value = m.Value,
                    Line = line,
                    Column = column,
                    Length = m.Length,
                    Index = m.Index
                });
            }

            return result;
        }

        private static void GetLineAndColumn(string text, int index, out int line, out int column)
        {
            line = 1;
            column = 1;

            if (index < 0 || index >= text.Length) return;

            for (int i = 0; i < index; i++)
            {
                if (text[i] == '\n')
                {
                    line++;
                    column = 1;
                }
                else
                {
                    column++;
                }
            }
        }
    }
}