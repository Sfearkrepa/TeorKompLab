using System.Windows.Forms;

namespace TeorKomp_Lab1
{
    public partial class AstViewer : Form
    {
        private readonly bool _russian;

        public AstViewer() : this(true, string.Empty) { }

        public AstViewer(bool russian, string astText)
        {
            _russian = russian;
            InitializeComponent();
            this.Text = russian ? "Дерево AST" : "AST Tree";
            richTextBox1.Text = astText ?? string.Empty;
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = 0;
        }
    }
}