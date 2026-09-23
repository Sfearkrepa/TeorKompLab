using System;
using System.Windows.Forms;

namespace TeorKomp_Lab1
{
    public partial class Reference : Form
    {
        private readonly bool _russian;

        public Reference() : this(true) { }

        public Reference(bool russian)
        {
            _russian = russian;
            InitializeComponent();
            ApplyLanguage();
            LoadHelpContent();
        }

        private void ApplyLanguage()
        {
            this.Text = _russian ? "Справка" : "Help";
        }

        private void LoadHelpContent()
        {
            richTextBox1.Text = _russian ? RussianText : EnglishText;
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = 0;
        }

        private const string RussianText =
@"СПРАВКА

Текстовый редактор. Лабораторная работа №1.

МЕНЮ ФАЙЛ

Создать (Ctrl+N) - создаёт новый пустой документ.
Открыть (Ctrl+O) - открывает текстовый файл.
Сохранить (Ctrl+S) - сохраняет текущий документ.
Сохранить как (Ctrl+Shift+S) - сохраняет документ под новым именем.
Выход (Ctrl+Q) - закрывает приложение. При наличии несохранённых изменений запрашивается подтверждение.

МЕНЮ ПРАВКА

Отменить (Ctrl+Z) - отменяет последнее действие.
Повторить (Ctrl+Y) - повторяет отменённое действие.
Вырезать (Ctrl+X) - вырезает выделенный фрагмент в буфер обмена.
Копировать (Ctrl+C) - копирует выделенный фрагмент в буфер обмена.
Вставить (Ctrl+V) - вставляет содержимое буфера обмена.
Удалить (Delete) - удаляет выделенный фрагмент или символ справа от курсора.
Выделить всё (Ctrl+A) - выделяет весь текст.

МЕНЮ ПУСК

Пуск (F5) - запускает анализ исходного кода. На данном этапе выводится информационное сообщение.

МЕНЮ СПРАВКА

Вызов справки (F1) - открывает данное окно.
О программе - выводит сведения о приложении.

МЕНЮ ЛОКАЛИЗАЦИЯ

Русский - переключает интерфейс на русский язык.
English - переключает интерфейс на английский язык.

ПАНЕЛЬ ИНСТРУМЕНТОВ

Содержит кнопки быстрого доступа к функциям меню Файл, Правка и Справка, а также выпадающий список выбора размера шрифта.

ОБЛАСТЬ РЕДАКТИРОВАНИЯ

Основное поле для ввода и редактирования текста. Слева отображается нумерация строк. Поддерживается перетаскивание файлов в окно редактора.

ОБЛАСТЬ ВЫВОДА РЕЗУЛЬТАТОВ

Таблица в нижней части окна предназначена для вывода результатов работы языкового процессора. Доступна только для чтения.

ГОРЯЧИЕ КЛАВИШИ

Ctrl+N - создать
Ctrl+O - открыть
Ctrl+S - сохранить
Ctrl+Shift+S - сохранить как
Ctrl+Q - выход
Ctrl+Z - отменить
Ctrl+Y - повторить
Ctrl+X - вырезать
Ctrl+C - копировать
Ctrl+V - вставить
Ctrl+A - выделить всё
Delete - удалить
F5 - пуск
F1 - справка";

        private const string EnglishText =
@"HELP

Text editor. Laboratory work No. 1.

FILE MENU

New (Ctrl+N) - creates a new empty document.
Open (Ctrl+O) - opens a text file.
Save (Ctrl+S) - saves the current document.
Save As (Ctrl+Shift+S) - saves the document under a new name.
Exit (Ctrl+Q) - closes the application. If there are unsaved changes, confirmation is requested.

EDIT MENU

Undo (Ctrl+Z) - undoes the last action.
Redo (Ctrl+Y) - redoes the undone action.
Cut (Ctrl+X) - cuts the selected fragment to the clipboard.
Copy (Ctrl+C) - copies the selected fragment to the clipboard.
Paste (Ctrl+V) - pastes the clipboard contents.
Delete (Delete) - deletes the selected fragment or the character to the right of the cursor.
Select All (Ctrl+A) - selects all text.

RUN MENU

Run (F5) - starts source code analysis. At this stage an informational message is shown.

HELP MENU

Help Contents (F1) - opens this window.
About - shows information about the application.

LANGUAGE MENU

Russian - switches the interface to Russian.
English - switches the interface to English.

TOOLBAR

Contains quick-access buttons for the File, Edit and Help menu functions, as well as a drop-down list for choosing the font size.

EDITING AREA

The main field for entering and editing text. Line numbers are displayed on the left. Drag and drop of files into the editor window is supported.

RESULTS AREA

The table at the bottom of the window is intended for displaying the results of the language processor. It is read-only.

HOTKEYS

Ctrl+N - new
Ctrl+O - open
Ctrl+S - save
Ctrl+Shift+S - save as
Ctrl+Q - exit
Ctrl+Z - undo
Ctrl+Y - redo
Ctrl+X - cut
Ctrl+C - copy
Ctrl+V - paste
Ctrl+A - select all
Delete - delete
F5 - run
F1 - help";
    }
}