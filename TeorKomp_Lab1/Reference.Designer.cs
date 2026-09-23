namespace TeorKomp_Lab1
{
    partial class Reference
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            SuspendLayout();

            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Font = new Font("Segoe UI", 11F);
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.BackColor = SystemColors.Window;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Both;
            richTextBox1.Size = new Size(820, 560);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            richTextBox1.WordWrap = true;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 560);
            Controls.Add(richTextBox1);
            MinimumSize = new Size(500, 400);
            Name = "Reference";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Справка";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
    }
}