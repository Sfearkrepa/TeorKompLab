using System.Collections.Generic;

namespace TeorKomp_Lab1
{
    public abstract class AstNode
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public abstract string NodeName { get; }
        public virtual string Attributes { get; set; } = string.Empty;
        public List<AstNode> Children { get; } = new List<AstNode>();
    }

    public class ProgramNode : AstNode
    {
        public override string NodeName => "ProgramNode";
    }

    public class ConstDeclNode : AstNode
    {
        public override string NodeName => "ConstDeclNode";
        public string Name { get; set; }
        public List<string> Modifiers { get; } = new List<string>();
        public List<FieldNode> Fields { get; } = new List<FieldNode>();
    }

    public class FieldNode : AstNode
    {
        public override string NodeName => "FieldNode";
        public string Name { get; set; }
        public TypeNode Type { get; set; }
        public ValueNode Value { get; set; }
    }

    public class TypeNode : AstNode
    {
        public override string NodeName => "TypeNode";
        public string Name { get; set; }
        public bool IsSlice { get; set; }
        public TypeNode ElementType { get; set; }
    }

    public class ValueNode : AstNode
    {
        public override string NodeName => "ValueNode";
        public string RawValue { get; set; }
        public bool IsNumeric { get; set; }
        public long NumericValue { get; set; }
        public bool IsBool { get; set; }
        public bool BoolValue { get; set; }
        public bool IsString { get; set; }
    }
}