using System.Collections.Generic;

namespace TeorKomp_Lab1
{
    public enum SymbolKind
    {
        Struct,
        Field,
        BuiltinType
    }

    public class Symbol
    {
        public string Name { get; set; }
        public SymbolKind Kind { get; set; }
        public string TypeName { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }

    public class SymbolTable
    {
        private readonly Dictionary<string, Symbol> _symbols = new Dictionary<string, Symbol>();
        private readonly HashSet<string> _builtinTypes = new HashSet<string>
        {
            "u8", "u16", "u32", "u64",
            "i8", "i16", "i32", "i64",
            "f16", "f32", "f64",
            "bool", "void", "usize", "isize"
        };

        public bool IsBuiltinType(string name)
        {
            return _builtinTypes.Contains(name);
        }

        public bool Contains(string name)
        {
            return _symbols.ContainsKey(name);
        }

        public Symbol Lookup(string name)
        {
            return _symbols.TryGetValue(name, out var s) ? s : null;
        }

        public void Declare(Symbol symbol)
        {
            _symbols[symbol.Name] = symbol;
        }
    }
}