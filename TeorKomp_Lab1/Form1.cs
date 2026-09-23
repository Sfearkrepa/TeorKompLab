using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TeorKomp_Lab1
{
    public partial class Form1 : Form
    {
        private string currentFilePath = string.Empty;
        private bool isModified = false;
        private float currentFontSize = 10.0f;
        private bool isRussian = true;
        private readonly LexicalAnalyzer _lexer = new LexicalAnalyzer();
        private readonly List<LexError> _currentErrors = new List<LexError>();

        public Form1()
        {
            InitializeComponent();

            richTextBox1.TextChanged += RichTextBox1_TextChanged;
            richTextBox1.VScroll += RichTextBox1_VScroll;
            richTextBox1.FontChanged += RichTextBox1_FontChanged;

            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            SetupHotkeys();
            SetupFontSizeComboBox();
            SetupDragAndDrop();
            SetupLocalization();

            SetLanguage(true);

            UpdateFormTitle();
            richTextBox1.ShortcutsEnabled = true;
            UpdateLineNumbers();
        }

        #region Локализация

        private void SetupLocalization()
        {
            русскийToolStripMenuItem.Click += (s, e) => SetLanguage(true);
            английскийToolStripMenuItem.Click += (s, e) => SetLanguage(false);
        }

        private void SetLanguage(bool russian)
        {
            isRussian = russian;

            if (russian)
            {
                this.Text = "Компилятор";

                Файл.Text = "Файл";
                правкаToolStripMenuItem.Text = "Правка";
                текстToolStripMenuItem.Text = "Текст";
                пускToolStripMenuItem.Text = "Пуск";
                справкаToolStripMenuItem.Text = "Справка";
                локализацияToolStripMenuItem.Text = "Локализация";
                видToolStripMenuItem.Text = "Вид";

                создатьToolStripMenuItem.Text = "Создать";
                открытьToolStripMenuItem.Text = "Открыть";
                сохранитьToolStripMenuItem.Text = "Сохранить";
                сохранитьКакToolStripMenuItem.Text = "Сохранить как";
                выходToolStripMenuItem.Text = "Выход";

                отменитьToolStripMenuItem.Text = "Отменить";
                повторитьToolStripMenuItem.Text = "Повторить";
                вырезатьToolStripMenuItem.Text = "Вырезать";
                копироватьToolStripMenuItem.Text = "Копировать";
                вставитьToolStripMenuItem.Text = "Вставить";
                удалитьToolStripMenuItem.Text = "Удалить";
                выделитьВсёToolStripMenuItem.Text = "Выделить всё";

                постановкаЗадачиToolStripMenuItem.Text = "Постановка задачи";
                грамматикаToolStripMenuItem.Text = "Грамматика";
                классификацияГраматикиToolStripMenuItem.Text = "Классификация грамматики";
                методАнализаToolStripMenuItem.Text = "Метод анализа";
                тестовыйПримерToolStripMenuItem.Text = "Тестовый пример";
                списокЛитературыToolStripMenuItem.Text = "Список литературы";
                исходныйКодПрограммыToolStripMenuItem.Text = "Исходный код программы";

                вызовСправкиToolStripMenuItem.Text = "Вызов справки";
                оПрограммеToolStripMenuItem.Text = "О программе";

                СоздатьtoolStripButton2.Text = "Создать";
                ОткрытьtoolStripButton2.Text = "Открыть";
                СохранитьtoolStripButton3.Text = "Сохранить";
                ОтменитьtoolStripButton4.Text = "Отменить";
                ПовторитьtoolStripButton5.Text = "Повторить";
                КопироватьtoolStripButton6.Text = "Копировать";
                ВырезатьtoolStripButton7.Text = "Вырезать";
                ВставитьtoolStripButton8.Text = "Вставить";
                ПускtoolStripButton9.Text = "Пуск";
                ВызовСправкиtoolStripButton10.Text = "Справка";
                ОПрограммеtoolStripButton11.Text = "О программе";
            }
            else
            {
                this.Text = "Compiler";

                Файл.Text = "File";
                правкаToolStripMenuItem.Text = "Edit";
                текстToolStripMenuItem.Text = "Text";
                пускToolStripMenuItem.Text = "Run";
                справкаToolStripMenuItem.Text = "Help";
                локализацияToolStripMenuItem.Text = "Language";
                видToolStripMenuItem.Text = "View";

                создатьToolStripMenuItem.Text = "New";
                открытьToolStripMenuItem.Text = "Open";
                сохранитьToolStripMenuItem.Text = "Save";
                сохранитьКакToolStripMenuItem.Text = "Save As";
                выходToolStripMenuItem.Text = "Exit";

                отменитьToolStripMenuItem.Text = "Undo";
                повторитьToolStripMenuItem.Text = "Redo";
                вырезатьToolStripMenuItem.Text = "Cut";
                копироватьToolStripMenuItem.Text = "Copy";
                вставитьToolStripMenuItem.Text = "Paste";
                удалитьToolStripMenuItem.Text = "Delete";
                выделитьВсёToolStripMenuItem.Text = "Select All";

                постановкаЗадачиToolStripMenuItem.Text = "Problem Statement";
                грамматикаToolStripMenuItem.Text = "Grammar";
                классификацияГраматикиToolStripMenuItem.Text = "Grammar Classification";
                методАнализаToolStripMenuItem.Text = "Analysis Method";
                тестовыйПримерToolStripMenuItem.Text = "Test Example";
                списокЛитературыToolStripMenuItem.Text = "References";
                исходныйКодПрограммыToolStripMenuItem.Text = "Source Code";

                вызовСправкиToolStripMenuItem.Text = "Help Contents";
                оПрограммеToolStripMenuItem.Text = "About";

                СоздатьtoolStripButton2.Text = "New";
                ОткрытьtoolStripButton2.Text = "Open";
                СохранитьtoolStripButton3.Text = "Save";
                ОтменитьtoolStripButton4.Text = "Undo";
                ПовторитьtoolStripButton5.Text = "Redo";
                КопироватьtoolStripButton6.Text = "Copy";
                ВырезатьtoolStripButton7.Text = "Cut";
                ВставитьtoolStripButton8.Text = "Paste";
                ПускtoolStripButton9.Text = "Run";
                ВызовСправкиtoolStripButton10.Text = "Help";
                ОПрограммеtoolStripButton11.Text = "About";
            }

            TranslateDataGridViewHeaders(russian);

            UpdateFormTitle();
        }

        private void TranslateDataGridViewHeaders(bool russian)
        {
            if (dataGridView1.Columns.Count == 0) return;

            if (russian)
            {
                if (dataGridView1.Columns["Код"] != null) dataGridView1.Columns["Код"].HeaderText = "Лексема";
                if (dataGridView1.Columns["Тип"] != null) dataGridView1.Columns["Тип"].HeaderText = "Тип";
                if (dataGridView1.Columns["Лексема"] != null) dataGridView1.Columns["Лексема"].HeaderText = "Строка";
                if (dataGridView1.Columns["Позиция"] != null) dataGridView1.Columns["Позиция"].HeaderText = "Позиция";
            }
            else
            {
                if (dataGridView1.Columns["Код"] != null) dataGridView1.Columns["Код"].HeaderText = "Lexeme";
                if (dataGridView1.Columns["Тип"] != null) dataGridView1.Columns["Тип"].HeaderText = "Type";
                if (dataGridView1.Columns["Лексема"] != null) dataGridView1.Columns["Лексема"].HeaderText = "Line";
                if (dataGridView1.Columns["Позиция"] != null) dataGridView1.Columns["Позиция"].HeaderText = "Position";
            }
        }

        #endregion

        private void UpdateFormTitle()
        {
            string title = isRussian ? "Компилятор" : "Compiler";
            if (!string.IsNullOrEmpty(currentFilePath))
                title += " - " + Path.GetFileName(currentFilePath);
            if (isModified) title += " *";

            this.Text = title;
        }

        private void SetupDragAndDrop()
        {
            this.AllowDrop = true;
            richTextBox1.AllowDrop = true;

            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;
            richTextBox1.DragEnter += Form1_DragEnter;
            richTextBox1.DragDrop += Form1_DragDrop;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    string filePath = files[0];
                    string ext = Path.GetExtension(filePath).ToLower();

                    if (ext == ".txt" || ext == ".cs" || ext == ".cpp" || ext == ".h" || ext == ".json" || ext == "" || ext == ".zig")
                        OpenDroppedFile(filePath);
                    else
                        MessageBox.Show(isRussian ? "Поддерживаются текстовые файлы" : "Only text files are supported",
                            isRussian ? "Неподдерживаемый формат" : "Unsupported format",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void OpenDroppedFile(string filePath)
        {
            if (isModified && !PromptSaveChanges()) return;

            try
            {
                richTextBox1.Text = File.ReadAllText(filePath);
                currentFilePath = filePath;
                isModified = false;
                UpdateFormTitle();
                UpdateLineNumbers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    isRussian ? $"Ошибка открытия файла:\n{ex.Message}" : $"Error opening file:\n{ex.Message}",
                    isRussian ? "Ошибка" : "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupFontSizeComboBox()
        {
            toolStripComboBox1.Items.Clear();
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 24, 28, 32 };
            foreach (int size in sizes) toolStripComboBox1.Items.Add(size);

            toolStripComboBox1.SelectedIndex = 2;
            toolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox1.SelectedIndexChanged += ToolStripComboBox1_SelectedIndexChanged;
        }

        private void ToolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedItem is int newSize)
            {
                currentFontSize = newSize;
                ApplyFontSizeToAll();
            }
        }

        private void ApplyFontSizeToAll()
        {
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, currentFontSize);
            richTextBox2.Font = new Font(richTextBox2.Font.FontFamily, currentFontSize);

            var cellFont = dataGridView1.DefaultCellStyle.Font ?? new Font("Segoe UI", 10f);
            dataGridView1.DefaultCellStyle.Font = new Font(cellFont.FontFamily, currentFontSize);

            var headerFont = dataGridView1.ColumnHeadersDefaultCellStyle.Font ?? new Font("Segoe UI", 9f);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(headerFont.FontFamily, currentFontSize - 1);

            UpdateLineNumbers();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!isModified)
            {
                isModified = true;
                UpdateFormTitle();
            }
            UpdateLineNumbers();
        }

        private void RichTextBox1_VScroll(object sender, EventArgs e) => UpdateLineNumbers();
        private void RichTextBox1_FontChanged(object sender, EventArgs e) => UpdateLineNumbers();

        private void UpdateLineNumbers()
        {
            richTextBox2.Clear();
            int lineCount = richTextBox1.Lines.Length;
            for (int i = 1; i <= lineCount; i++)
                richTextBox2.AppendText(i + Environment.NewLine);

            AdjustLineNumberWidth();
        }

        private void AdjustLineNumberWidth()
        {
            using (Graphics g = richTextBox2.CreateGraphics())
            {
                int maxDigits = Math.Max(2, richTextBox1.Lines.Length.ToString().Length);
                float width = g.MeasureString(new string('9', maxDigits + 1), richTextBox2.Font).Width + 10;
                richTextBox2.Width = (int)Math.Ceiling(width);
            }
        }

        private void SetupHotkeys()
        {
            создатьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            открытьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            сохранитьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            сохранитьКакToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            выходToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;

            отменитьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            повторитьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            вырезатьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            копироватьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            вставитьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            удалитьToolStripMenuItem.ShortcutKeys = Keys.Delete;
            выделитьВсёToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;

            пускToolStripMenuItem.ShortcutKeys = Keys.F5;
            вызовСправкиToolStripMenuItem.ShortcutKeys = Keys.F1;
        }

        private void отменитьToolStripMenuItem_Click_1(object sender, EventArgs e) => richTextBox1.Undo();
        private void ОтменитьtoolStripButton4_Click(object sender, EventArgs e) => richTextBox1.Undo();
        private void повторитьToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Redo();
        private void ПовторитьtoolStripButton5_Click(object sender, EventArgs e) => richTextBox1.Redo();
        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Cut();
        private void ВырезатьtoolStripButton7_Click(object sender, EventArgs e) => richTextBox1.Cut();
        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Copy();
        private void КопироватьtoolStripButton6_Click(object sender, EventArgs e) => richTextBox1.Copy();
        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Paste();
        private void ВставитьtoolStripButton8_Click(object sender, EventArgs e) => richTextBox1.Paste();
        private void выделитьВсёToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.SelectAll();

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
                richTextBox1.SelectedText = string.Empty;
            else if (richTextBox1.SelectionStart < richTextBox1.TextLength)
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.SelectionStart, 1);
        }

        private void создатьToolStripMenuItem_Click_1(object sender, EventArgs e) => NewFile();
        private void toolStripButton1_Click(object sender, EventArgs e) => NewFile();
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e) => OpenFile();
        private void ОткрытьtoolStripButton2_Click(object sender, EventArgs e) => OpenFile();
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e) => SaveFile();
        private void СохранитьtoolStripButton3_Click(object sender, EventArgs e) => SaveFile();
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e) => SaveFileAs();

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isModified && !PromptSaveChanges()) return;
            Application.Exit();
        }

        private void NewFile()
        {
            if (isModified && !PromptSaveChanges()) return;
            richTextBox1.Clear();
            dataGridView1.Rows.Clear();
            _currentErrors.Clear();
            currentFilePath = string.Empty;
            isModified = false;
            UpdateFormTitle();
            UpdateLineNumbers();
        }

        private void OpenFile()
        {
            if (isModified && !PromptSaveChanges()) return;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = isRussian
                    ? "Текстовые файлы (*.txt)|*.txt|Файлы Zig (*.zig)|*.zig|Все файлы (*.*)|*.*"
                    : "Text files (*.txt)|*.txt|Zig files (*.zig)|*.zig|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        richTextBox1.Text = File.ReadAllText(ofd.FileName);
                        currentFilePath = ofd.FileName;
                        isModified = false;
                        UpdateFormTitle();
                        UpdateLineNumbers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            isRussian ? $"Ошибка открытия файла:\n{ex.Message}" : $"Error opening file:\n{ex.Message}",
                            isRussian ? "Ошибка" : "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveFile()
        {
            if (string.IsNullOrEmpty(currentFilePath)) { SaveFileAs(); return; }
            try
            {
                File.WriteAllText(currentFilePath, richTextBox1.Text);
                isModified = false;
                UpdateFormTitle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    isRussian ? $"Ошибка сохранения:\n{ex.Message}" : $"Error saving file:\n{ex.Message}",
                    isRussian ? "Ошибка" : "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveFileAs()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = isRussian
                    ? "Текстовые файлы (*.txt)|*.txt|Файлы Zig (*.zig)|*.zig|Все файлы (*.*)|*.*"
                    : "Text files (*.txt)|*.txt|Zig files (*.zig)|*.zig|All files (*.*)|*.*";

                sfd.FileName = string.IsNullOrEmpty(currentFilePath)
                    ? (isRussian ? "Новый документ.txt" : "New document.txt")
                    : Path.GetFileName(currentFilePath);

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(sfd.FileName, richTextBox1.Text);
                        currentFilePath = sfd.FileName;
                        isModified = false;
                        UpdateFormTitle();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            isRussian ? $"Ошибка сохранения:\n{ex.Message}" : $"Error saving file:\n{ex.Message}",
                            isRussian ? "Ошибка" : "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool PromptSaveChanges()
        {
            string msg = isRussian ? "Сохранить изменения в текущем документе?" : "Save changes to the current document?";
            string title = isRussian ? "Несохранённые изменения" : "Unsaved Changes";

            var result = MessageBox.Show(msg, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) { SaveFile(); return true; }
            return result != DialogResult.Cancel;
        }

        private void пускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunLexicalAnalysis();
        }

        private void RunLexicalAnalysis()
        {
            dataGridView1.Rows.Clear();
            _currentErrors.Clear();

            string source = richTextBox1.Text;
            if (string.IsNullOrWhiteSpace(source))
            {
                MessageBox.Show(
                    isRussian ? "Текст программы пуст." : "Source text is empty.",
                    isRussian ? "Пуск" : "Run",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LexResult result = _lexer.Analyze(source);

            foreach (var token in result.Tokens)
            {
                string typeName = isRussian
                    ? LexicalAnalyzer.TypeToRussian(token.Type)
                    : LexicalAnalyzer.TypeToEnglish(token.Type);

                int rowIndex = dataGridView1.Rows.Add(
                    token.Value,
                    typeName,
                    token.Line,
                    token.Column);

                if (token.Type == TokenType.Unknown)
                {
                    var row = dataGridView1.Rows[rowIndex];
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    row.Tag = token.Index;
                }
            }

            foreach (var error in result.Errors)
            {
                int rowIndex = dataGridView1.Rows.Add(
                    error.Message,
                    isRussian ? "ошибка" : "error",
                    error.Line,
                    error.Column);

                var row = dataGridView1.Rows[rowIndex];
                row.DefaultCellStyle.BackColor = Color.LightCoral;
                row.DefaultCellStyle.ForeColor = Color.White;
                row.Tag = error.Index;

                _currentErrors.Add(error);
            }

            if (result.Errors.Count > 0)
            {
                MessageBox.Show(
                    isRussian
                        ? $"Анализ завершён. Найдено ошибок: {result.Errors.Count}.\nДвойной щелчок по строке ошибки переместит курсор в редактор."
                        : $"Analysis complete. Errors found: {result.Errors.Count}.\nDouble-click an error row to jump to the editor.",
                    isRussian ? "Пуск" : "Run",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(
                    isRussian ? $"Анализ завершён. Найдено лексем: {result.Tokens.Count}"
                              : $"Analysis complete. Tokens found: {result.Tokens.Count}",
                    isRussian ? "Пуск" : "Run",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];
            if (row.Tag == null) return;

            if (!int.TryParse(row.Tag.ToString(), out int index)) return;
            if (index < 0 || index >= richTextBox1.TextLength) return;

            richTextBox1.Focus();
            richTextBox1.SelectionStart = index;
            richTextBox1.SelectionLength = 1;
            richTextBox1.ScrollToCaret();
        }

        private void ПускtoolStripButton9_Click(object sender, EventArgs e) => пускToolStripMenuItem_Click(sender, e);

        private void вызовСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reference = new Reference(isRussian);
            reference.ShowDialog(this);
        }

        private void ВызовСправкиtoolStripButton10_Click(object sender, EventArgs e) => вызовСправкиToolStripMenuItem_Click(sender, e);

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = isRussian ? "Компилятор для лабораторной работы по Теории Компиляторов\nВерсия 1.0"
                                   : "Compiler for Theory of Compilers Lab\nVersion 1.0";
            MessageBox.Show(msg, isRussian ? "О программе" : "About");
        }

        private void ОПрограммеtoolStripButton11_Click(object sender, EventArgs e) => оПрограммеToolStripMenuItem_Click(sender, e);

        private void toolStripComboBox1_Click(object sender, EventArgs e) { }
        private void Файл_Click(object sender, EventArgs e) { }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void отменитьToolStripMenuItem1_Click(object sender, EventArgs e) { }
        private void постановкаЗадачиToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void грамматикаToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void классификацияГраматикиToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void методАнализаToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void тестовыйПримерToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void списокЛитературыToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void исходныйКодПрограммыToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void локализацияToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void видToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e) { }
    }
}