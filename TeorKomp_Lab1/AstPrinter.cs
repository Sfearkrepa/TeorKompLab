using System.Text;

namespace TeorKomp_Lab1
{
    public static class AstPrinter
    {
        public static string Print(AstNode root)
        {
            var sb = new StringBuilder();
            if (root == null) return string.Empty;

            sb.AppendLine(root.NodeName);

            for (int i = 0; i < root.Children.Count; i++)
            {
                bool isLast = i == root.Children.Count - 1;
                PrintNode(root.Children[i], sb, "", isLast);
            }

            return sb.ToString();
        }

        private static void PrintNode(AstNode node, StringBuilder sb, string indent, bool isLast)
        {
            string branch = isLast ? "└── " : "├── ";
            sb.AppendLine(indent + branch + node.NodeName + GetAttributes(node));

            string newIndent = indent + (isLast ? "    " : "│   ");

            for (int i = 0; i < node.Children.Count; i++)
            {
                bool childIsLast = i == node.Children.Count - 1;
                PrintNode(node.Children[i], sb, newIndent, childIsLast);
            }
        }

        private static string GetAttributes(AstNode node)
        {
            if (node is ConstDeclNode c)
            {
                string mods = c.Modifiers.Count > 0
                    ? " [" + string.Join(", ", c.Modifiers) + "]"
                    : "";
                return $": \"{c.Name}\"{mods}";
            }

            if (node is FieldNode f)
            {
                string val = f.Value != null ? $", value: {f.Value.RawValue}" : "";
                return $": \"{f.Name}\"{val}";
            }

            if (node is TypeNode t)
            {
                if (t.IsSlice)
                    return ": []const";
                return $": \"{t.Name}\"";
            }

            if (node is ValueNode v)
            {
                return $": {v.RawValue}";
            }

            return string.Empty;
        }
    }
}