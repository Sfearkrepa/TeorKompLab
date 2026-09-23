namespace TeorKomp_Lab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            Файл = new ToolStripMenuItem();
            создатьToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьКакToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            правкаToolStripMenuItem = new ToolStripMenuItem();
            отменитьToolStripMenuItem = new ToolStripMenuItem();
            повторитьToolStripMenuItem = new ToolStripMenuItem();
            вырезатьToolStripMenuItem = new ToolStripMenuItem();
            копироватьToolStripMenuItem = new ToolStripMenuItem();
            вставитьToolStripMenuItem = new ToolStripMenuItem();
            удалитьToolStripMenuItem = new ToolStripMenuItem();
            выделитьВсёToolStripMenuItem = new ToolStripMenuItem();
            отменитьToolStripMenuItem1 = new ToolStripMenuItem();
            текстToolStripMenuItem = new ToolStripMenuItem();
            постановкаЗадачиToolStripMenuItem = new ToolStripMenuItem();
            грамматикаToolStripMenuItem = new ToolStripMenuItem();
            классификацияГраматикиToolStripMenuItem = new ToolStripMenuItem();
            методАнализаToolStripMenuItem = new ToolStripMenuItem();
            тестовыйПримерToolStripMenuItem = new ToolStripMenuItem();
            списокЛитературыToolStripMenuItem = new ToolStripMenuItem();
            исходныйКодПрограммыToolStripMenuItem = new ToolStripMenuItem();
            пускToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            вызовСправкиToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            локализацияToolStripMenuItem = new ToolStripMenuItem();
            русскийToolStripMenuItem = new ToolStripMenuItem();
            английскийToolStripMenuItem = new ToolStripMenuItem();
            видToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            СоздатьtoolStripButton2 = new ToolStripButton();
            ОткрытьtoolStripButton2 = new ToolStripButton();
            СохранитьtoolStripButton3 = new ToolStripButton();
            ОтменитьtoolStripButton4 = new ToolStripButton();
            ПовторитьtoolStripButton5 = new ToolStripButton();
            КопироватьtoolStripButton6 = new ToolStripButton();
            ВырезатьtoolStripButton7 = new ToolStripButton();
            ВставитьtoolStripButton8 = new ToolStripButton();
            ПускtoolStripButton9 = new ToolStripButton();
            ВызовСправкиtoolStripButton10 = new ToolStripButton();
            ОПрограммеtoolStripButton11 = new ToolStripButton();
            toolStripComboBox1 = new ToolStripComboBox();
            dataGridView1 = new DataGridView();
            Код = new DataGridViewTextBoxColumn();
            Тип = new DataGridViewTextBoxColumn();
            Лексема = new DataGridViewTextBoxColumn();
            Позиция = new DataGridViewTextBoxColumn();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            statusStrip1 = new StatusStrip();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { Файл, правкаToolStripMenuItem, текстToolStripMenuItem, пускToolStripMenuItem, справкаToolStripMenuItem, локализацияToolStripMenuItem, видToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(724, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // Файл
            // 
            Файл.DropDownItems.AddRange(new ToolStripItem[] { создатьToolStripMenuItem, открытьToolStripMenuItem, сохранитьToolStripMenuItem, сохранитьКакToolStripMenuItem, выходToolStripMenuItem });
            Файл.Name = "Файл";
            Файл.Size = new Size(48, 20);
            Файл.Text = "Файл";
            Файл.Click += Файл_Click;
            // 
            // создатьToolStripMenuItem
            // 
            создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            создатьToolStripMenuItem.Size = new Size(154, 22);
            создатьToolStripMenuItem.Text = "Создать";
            создатьToolStripMenuItem.Click += создатьToolStripMenuItem_Click_1;
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(154, 22);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(154, 22);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // сохранитьКакToolStripMenuItem
            // 
            сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            сохранитьКакToolStripMenuItem.Size = new Size(154, 22);
            сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            сохранитьКакToolStripMenuItem.Click += сохранитьКакToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(154, 22);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // правкаToolStripMenuItem
            // 
            правкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { отменитьToolStripMenuItem, повторитьToolStripMenuItem, вырезатьToolStripMenuItem, копироватьToolStripMenuItem, вставитьToolStripMenuItem, удалитьToolStripMenuItem, выделитьВсёToolStripMenuItem, отменитьToolStripMenuItem1 });
            правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            правкаToolStripMenuItem.Size = new Size(59, 20);
            правкаToolStripMenuItem.Text = "Правка";
            // 
            // отменитьToolStripMenuItem
            // 
            отменитьToolStripMenuItem.Name = "отменитьToolStripMenuItem";
            отменитьToolStripMenuItem.Size = new Size(148, 22);
            отменитьToolStripMenuItem.Text = "Отменить";
            отменитьToolStripMenuItem.Click += отменитьToolStripMenuItem_Click_1;
            // 
            // повторитьToolStripMenuItem
            // 
            повторитьToolStripMenuItem.Name = "повторитьToolStripMenuItem";
            повторитьToolStripMenuItem.Size = new Size(148, 22);
            повторитьToolStripMenuItem.Text = "Повторить";
            повторитьToolStripMenuItem.Click += повторитьToolStripMenuItem_Click;
            // 
            // вырезатьToolStripMenuItem
            // 
            вырезатьToolStripMenuItem.Name = "вырезатьToolStripMenuItem";
            вырезатьToolStripMenuItem.Size = new Size(148, 22);
            вырезатьToolStripMenuItem.Text = "Вырезать";
            вырезатьToolStripMenuItem.Click += вырезатьToolStripMenuItem_Click;
            // 
            // копироватьToolStripMenuItem
            // 
            копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            копироватьToolStripMenuItem.Size = new Size(148, 22);
            копироватьToolStripMenuItem.Text = "Копировать";
            копироватьToolStripMenuItem.Click += копироватьToolStripMenuItem_Click;
            // 
            // вставитьToolStripMenuItem
            // 
            вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            вставитьToolStripMenuItem.Size = new Size(148, 22);
            вставитьToolStripMenuItem.Text = "Вставить";
            вставитьToolStripMenuItem.Click += вставитьToolStripMenuItem_Click;
            // 
            // удалитьToolStripMenuItem
            // 
            удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            удалитьToolStripMenuItem.Size = new Size(148, 22);
            удалитьToolStripMenuItem.Text = "Удалить";
            удалитьToolStripMenuItem.Click += удалитьToolStripMenuItem_Click;
            // 
            // выделитьВсёToolStripMenuItem
            // 
            выделитьВсёToolStripMenuItem.Name = "выделитьВсёToolStripMenuItem";
            выделитьВсёToolStripMenuItem.Size = new Size(148, 22);
            выделитьВсёToolStripMenuItem.Text = "Выделить всё";
            выделитьВсёToolStripMenuItem.Click += выделитьВсёToolStripMenuItem_Click;
            // 
            // отменитьToolStripMenuItem1
            // 
            отменитьToolStripMenuItem1.Name = "отменитьToolStripMenuItem1";
            отменитьToolStripMenuItem1.Size = new Size(148, 22);
            отменитьToolStripMenuItem1.Text = "Отменить";
            отменитьToolStripMenuItem1.Click += отменитьToolStripMenuItem1_Click;
            // 
            // текстToolStripMenuItem
            // 
            текстToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { постановкаЗадачиToolStripMenuItem, грамматикаToolStripMenuItem, классификацияГраматикиToolStripMenuItem, методАнализаToolStripMenuItem, тестовыйПримерToolStripMenuItem, списокЛитературыToolStripMenuItem, исходныйКодПрограммыToolStripMenuItem });
            текстToolStripMenuItem.Name = "текстToolStripMenuItem";
            текстToolStripMenuItem.Size = new Size(48, 20);
            текстToolStripMenuItem.Text = "Текст";
            // 
            // постановкаЗадачиToolStripMenuItem
            // 
            постановкаЗадачиToolStripMenuItem.Name = "постановкаЗадачиToolStripMenuItem";
            постановкаЗадачиToolStripMenuItem.Size = new Size(231, 22);
            постановкаЗадачиToolStripMenuItem.Text = "Постановка задачи";
            постановкаЗадачиToolStripMenuItem.Click += постановкаЗадачиToolStripMenuItem_Click;
            // 
            // грамматикаToolStripMenuItem
            // 
            грамматикаToolStripMenuItem.Name = "грамматикаToolStripMenuItem";
            грамматикаToolStripMenuItem.Size = new Size(231, 22);
            грамматикаToolStripMenuItem.Text = "Грамматика";
            грамматикаToolStripMenuItem.Click += грамматикаToolStripMenuItem_Click;
            // 
            // классификацияГраматикиToolStripMenuItem
            // 
            классификацияГраматикиToolStripMenuItem.Name = "классификацияГраматикиToolStripMenuItem";
            классификацияГраматикиToolStripMenuItem.Size = new Size(231, 22);
            классификацияГраматикиToolStripMenuItem.Text = "Классификация грамматики";
            классификацияГраматикиToolStripMenuItem.Click += классификацияГраматикиToolStripMenuItem_Click;
            // 
            // методАнализаToolStripMenuItem
            // 
            методАнализаToolStripMenuItem.Name = "методАнализаToolStripMenuItem";
            методАнализаToolStripMenuItem.Size = new Size(231, 22);
            методАнализаToolStripMenuItem.Text = "Метод анализа";
            методАнализаToolStripMenuItem.Click += методАнализаToolStripMenuItem_Click;
            // 
            // тестовыйПримерToolStripMenuItem
            // 
            тестовыйПримерToolStripMenuItem.Name = "тестовыйПримерToolStripMenuItem";
            тестовыйПримерToolStripMenuItem.Size = new Size(231, 22);
            тестовыйПримерToolStripMenuItem.Text = "Тестовый пример";
            тестовыйПримерToolStripMenuItem.Click += тестовыйПримерToolStripMenuItem_Click;
            // 
            // списокЛитературыToolStripMenuItem
            // 
            списокЛитературыToolStripMenuItem.Name = "списокЛитературыToolStripMenuItem";
            списокЛитературыToolStripMenuItem.Size = new Size(231, 22);
            списокЛитературыToolStripMenuItem.Text = "Список литературы";
            списокЛитературыToolStripMenuItem.Click += списокЛитературыToolStripMenuItem_Click;
            // 
            // исходныйКодПрограммыToolStripMenuItem
            // 
            исходныйКодПрограммыToolStripMenuItem.Name = "исходныйКодПрограммыToolStripMenuItem";
            исходныйКодПрограммыToolStripMenuItem.Size = new Size(231, 22);
            исходныйКодПрограммыToolStripMenuItem.Text = "Исходный код программы";
            исходныйКодПрограммыToolStripMenuItem.Click += исходныйКодПрограммыToolStripMenuItem_Click;
            // 
            // пускToolStripMenuItem
            // 
            пускToolStripMenuItem.Name = "пускToolStripMenuItem";
            пускToolStripMenuItem.Size = new Size(46, 20);
            пускToolStripMenuItem.Text = "Пуск";
            пускToolStripMenuItem.Click += пускToolStripMenuItem_Click;
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { вызовСправкиToolStripMenuItem, оПрограммеToolStripMenuItem });
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(65, 20);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // вызовСправкиToolStripMenuItem
            // 
            вызовСправкиToolStripMenuItem.Name = "вызовСправкиToolStripMenuItem";
            вызовСправкиToolStripMenuItem.Size = new Size(156, 22);
            вызовСправкиToolStripMenuItem.Text = "Вызов справки";
            вызовСправкиToolStripMenuItem.Click += вызовСправкиToolStripMenuItem_Click;
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(156, 22);
            оПрограммеToolStripMenuItem.Text = "О программе";
            оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
            // 
            // локализацияToolStripMenuItem
            // 
            локализацияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { русскийToolStripMenuItem, английскийToolStripMenuItem });
            локализацияToolStripMenuItem.Name = "локализацияToolStripMenuItem";
            локализацияToolStripMenuItem.Size = new Size(91, 20);
            локализацияToolStripMenuItem.Text = "Локализация";
            локализацияToolStripMenuItem.Click += локализацияToolStripMenuItem_Click;
            // 
            // русскийToolStripMenuItem
            // 
            русскийToolStripMenuItem.Name = "русскийToolStripMenuItem";
            русскийToolStripMenuItem.Size = new Size(119, 22);
            русскийToolStripMenuItem.Text = "Русский";
            // 
            // английскийToolStripMenuItem
            // 
            английскийToolStripMenuItem.Name = "английскийToolStripMenuItem";
            английскийToolStripMenuItem.Size = new Size(119, 22);
            английскийToolStripMenuItem.Text = "English";
            // 
            // видToolStripMenuItem
            // 
            видToolStripMenuItem.Name = "видToolStripMenuItem";
            видToolStripMenuItem.Size = new Size(39, 20);
            видToolStripMenuItem.Text = "Вид";
            видToolStripMenuItem.Click += видToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            toolStrip1.AutoSize = false;
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { СоздатьtoolStripButton2, ОткрытьtoolStripButton2, СохранитьtoolStripButton3, ОтменитьtoolStripButton4, ПовторитьtoolStripButton5, КопироватьtoolStripButton6, ВырезатьtoolStripButton7, ВставитьtoolStripButton8, ПускtoolStripButton9, ВызовСправкиtoolStripButton10, ОПрограммеtoolStripButton11, toolStripComboBox1 });
            toolStrip1.Location = new Point(10, 21);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(703, 39);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // СоздатьtoolStripButton2
            // 
            СоздатьtoolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            СоздатьtoolStripButton2.Image = (Image)resources.GetObject("СоздатьtoolStripButton2.Image");
            СоздатьtoolStripButton2.ImageTransparentColor = Color.Magenta;
            СоздатьtoolStripButton2.Name = "СоздатьtoolStripButton2";
            СоздатьtoolStripButton2.Size = new Size(36, 36);
            СоздатьtoolStripButton2.Text = "Создать";
            СоздатьtoolStripButton2.Click += toolStripButton1_Click;
            // 
            // ОткрытьtoolStripButton2
            // 
            ОткрытьtoolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ОткрытьtoolStripButton2.Image = (Image)resources.GetObject("ОткрытьtoolStripButton2.Image");
            ОткрытьtoolStripButton2.ImageTransparentColor = Color.Magenta;
            ОткрытьtoolStripButton2.Name = "ОткрытьtoolStripButton2";
            ОткрытьtoolStripButton2.Size = new Size(36, 36);
            ОткрытьtoolStripButton2.Text = "Открыть";
            ОткрытьtoolStripButton2.Click += ОткрытьtoolStripButton2_Click;
            // 
            // СохранитьtoolStripButton3
            // 
            СохранитьtoolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            СохранитьtoolStripButton3.Image = (Image)resources.GetObject("СохранитьtoolStripButton3.Image");
            СохранитьtoolStripButton3.ImageTransparentColor = Color.Magenta;
            СохранитьtoolStripButton3.Name = "СохранитьtoolStripButton3";
            СохранитьtoolStripButton3.Size = new Size(36, 36);
            СохранитьtoolStripButton3.Text = "Сохранить";
            СохранитьtoolStripButton3.Click += СохранитьtoolStripButton3_Click;
            // 
            // ОтменитьtoolStripButton4
            // 
            ОтменитьtoolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ОтменитьtoolStripButton4.Image = (Image)resources.GetObject("ОтменитьtoolStripButton4.Image");
            ОтменитьtoolStripButton4.ImageTransparentColor = Color.Magenta;
            ОтменитьtoolStripButton4.Name = "ОтменитьtoolStripButton4";
            ОтменитьtoolStripButton4.Size = new Size(36, 36);
            ОтменитьtoolStripButton4.Text = "Отменить";
            ОтменитьtoolStripButton4.Click += ОтменитьtoolStripButton4_Click;
            // 
            // ПовторитьtoolStripButton5
            // 
            ПовторитьtoolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ПовторитьtoolStripButton5.Image = (Image)resources.GetObject("ПовторитьtoolStripButton5.Image");
            ПовторитьtoolStripButton5.ImageTransparentColor = Color.Magenta;
            ПовторитьtoolStripButton5.Name = "ПовторитьtoolStripButton5";
            ПовторитьtoolStripButton5.Size = new Size(36, 36);
            ПовторитьtoolStripButton5.Text = "Повторить";
            ПовторитьtoolStripButton5.Click += ПовторитьtoolStripButton5_Click;
            // 
            // КопироватьtoolStripButton6
            // 
            КопироватьtoolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Image;
            КопироватьtoolStripButton6.Image = (Image)resources.GetObject("КопироватьtoolStripButton6.Image");
            КопироватьtoolStripButton6.ImageTransparentColor = Color.Magenta;
            КопироватьtoolStripButton6.Name = "КопироватьtoolStripButton6";
            КопироватьtoolStripButton6.Size = new Size(36, 36);
            КопироватьtoolStripButton6.Text = "Копировать";
            КопироватьtoolStripButton6.Click += КопироватьtoolStripButton6_Click;
            // 
            // ВырезатьtoolStripButton7
            // 
            ВырезатьtoolStripButton7.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ВырезатьtoolStripButton7.Image = (Image)resources.GetObject("ВырезатьtoolStripButton7.Image");
            ВырезатьtoolStripButton7.ImageTransparentColor = Color.Magenta;
            ВырезатьtoolStripButton7.Name = "ВырезатьtoolStripButton7";
            ВырезатьtoolStripButton7.Size = new Size(36, 36);
            ВырезатьtoolStripButton7.Text = "Вырезать";
            ВырезатьtoolStripButton7.Click += ВырезатьtoolStripButton7_Click;
            // 
            // ВставитьtoolStripButton8
            // 
            ВставитьtoolStripButton8.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ВставитьtoolStripButton8.Image = (Image)resources.GetObject("ВставитьtoolStripButton8.Image");
            ВставитьtoolStripButton8.ImageTransparentColor = Color.Magenta;
            ВставитьtoolStripButton8.Name = "ВставитьtoolStripButton8";
            ВставитьtoolStripButton8.Size = new Size(36, 36);
            ВставитьtoolStripButton8.Text = "Вставить";
            ВставитьtoolStripButton8.Click += ВставитьtoolStripButton8_Click;
            // 
            // ПускtoolStripButton9
            // 
            ПускtoolStripButton9.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ПускtoolStripButton9.Image = (Image)resources.GetObject("ПускtoolStripButton9.Image");
            ПускtoolStripButton9.ImageTransparentColor = Color.Magenta;
            ПускtoolStripButton9.Name = "ПускtoolStripButton9";
            ПускtoolStripButton9.Size = new Size(36, 36);
            ПускtoolStripButton9.Text = "Пуск";
            ПускtoolStripButton9.Click += ПускtoolStripButton9_Click;
            // 
            // ВызовСправкиtoolStripButton10
            // 
            ВызовСправкиtoolStripButton10.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ВызовСправкиtoolStripButton10.Image = (Image)resources.GetObject("ВызовСправкиtoolStripButton10.Image");
            ВызовСправкиtoolStripButton10.ImageTransparentColor = Color.Magenta;
            ВызовСправкиtoolStripButton10.Name = "ВызовСправкиtoolStripButton10";
            ВызовСправкиtoolStripButton10.Size = new Size(36, 36);
            ВызовСправкиtoolStripButton10.Text = "Вызов справки";
            ВызовСправкиtoolStripButton10.Click += ВызовСправкиtoolStripButton10_Click;
            // 
            // ОПрограммеtoolStripButton11
            // 
            ОПрограммеtoolStripButton11.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ОПрограммеtoolStripButton11.Image = (Image)resources.GetObject("ОПрограммеtoolStripButton11.Image");
            ОПрограммеtoolStripButton11.ImageTransparentColor = Color.Magenta;
            ОПрограммеtoolStripButton11.Name = "ОПрограммеtoolStripButton11";
            ОПрограммеtoolStripButton11.Size = new Size(36, 36);
            ОПрограммеtoolStripButton11.Text = "О программе";
            ОПрограммеtoolStripButton11.Click += ОПрограммеtoolStripButton11_Click;
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(106, 39);
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Код, Тип, Лексема, Позиция });
            dataGridView1.Location = new Point(10, 244);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(703, 126);
            dataGridView1.TabIndex = 2;
            // 
            // Код
            // 
            Код.HeaderText = "Код";
            Код.MinimumWidth = 6;
            Код.Name = "Код";
            Код.Width = 125;
            // 
            // Тип
            // 
            Тип.HeaderText = "Тип";
            Тип.MinimumWidth = 6;
            Тип.Name = "Тип";
            Тип.Width = 125;
            // 
            // Лексема
            // 
            Лексема.HeaderText = "Лексема";
            Лексема.MinimumWidth = 6;
            Лексема.Name = "Лексема";
            Лексема.Width = 125;
            // 
            // Позиция
            // 
            Позиция.HeaderText = "Позиция";
            Позиция.MinimumWidth = 6;
            Позиция.Name = "Позиция";
            Позиция.Width = 125;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Location = new Point(49, 62);
            richTextBox1.Margin = new Padding(3, 2, 3, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(664, 179);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(15, 62);
            richTextBox2.Margin = new Padding(3, 2, 3, 2);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(28, 179);
            richTextBox2.TabIndex = 4;
            richTextBox2.Text = "";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 377);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 12, 0);
            statusStrip1.Size = new Size(724, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 399);
            Controls.Add(statusStrip1);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(dataGridView1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Компилятор";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem Файл;
        private ToolStripMenuItem правкаToolStripMenuItem;
        private ToolStripMenuItem текстToolStripMenuItem;
        private ToolStripMenuItem пускToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton СоздатьtoolStripButton2;
        private ToolStripButton ОткрытьtoolStripButton2;
        private ToolStripButton СохранитьtoolStripButton3;
        private ToolStripButton ОтменитьtoolStripButton4;
        private ToolStripButton ПовторитьtoolStripButton5;
        private ToolStripButton КопироватьtoolStripButton6;
        private ToolStripButton ВырезатьtoolStripButton7;
        private ToolStripButton ВставитьtoolStripButton8;
        private DataGridView dataGridView1;
        private RichTextBox richTextBox1;
        private ToolStripMenuItem создатьToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem отменитьToolStripMenuItem;
        private ToolStripMenuItem повторитьToolStripMenuItem;
        private ToolStripMenuItem вырезатьToolStripMenuItem;
        private ToolStripMenuItem копироватьToolStripMenuItem;
        private ToolStripMenuItem вставитьToolStripMenuItem;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        private ToolStripMenuItem выделитьВсёToolStripMenuItem;
        private ToolStripMenuItem постановкаЗадачиToolStripMenuItem;
        private ToolStripMenuItem грамматикаToolStripMenuItem;
        private ToolStripMenuItem классификацияГраматикиToolStripMenuItem;
        private ToolStripMenuItem методАнализаToolStripMenuItem;
        private ToolStripMenuItem тестовыйПримерToolStripMenuItem;
        private ToolStripMenuItem списокЛитературыToolStripMenuItem;
        private ToolStripMenuItem исходныйКодПрограммыToolStripMenuItem;
        private ToolStripMenuItem вызовСправкиToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStripMenuItem отменитьToolStripMenuItem1;
        private ToolStripButton ПускtoolStripButton9;
        private ToolStripButton ВызовСправкиtoolStripButton10;
        private ToolStripButton ОПрограммеtoolStripButton11;
        private ToolStripMenuItem локализацияToolStripMenuItem;
        private ToolStripMenuItem видToolStripMenuItem;
        private ToolStripMenuItem русскийToolStripMenuItem;
        private ToolStripMenuItem английскийToolStripMenuItem;
        private RichTextBox richTextBox2;
        private DataGridViewTextBoxColumn Код;
        private DataGridViewTextBoxColumn Тип;
        private DataGridViewTextBoxColumn Лексема;
        private DataGridViewTextBoxColumn Позиция;
        private StatusStrip statusStrip1;
        private ToolStripComboBox toolStripComboBox1;
    }
}