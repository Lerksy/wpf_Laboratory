using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Создание привязки и присоединение обработчиков
            CommandBinding saveCommand = new CommandBinding(ApplicationCommands.Save, execute_Save, canExecute_Save);
            CommandBinding openCommand = new CommandBinding(ApplicationCommands.Open, execute_Open, canExecute_Open);
            CommandBinding deleteCommand = new CommandBinding(ApplicationCommands.Delete, execute_Delete, canExecute_Delete);
            CommandBinding copyCommand = new CommandBinding(ApplicationCommands.Copy, execute_Copy, canExecute_Copy);
            CommandBinding pasteCommand = new CommandBinding(ApplicationCommands.Paste, execute_Paste, canExecute_Paste);
            //Регистрация привязки
            CommandBindings.Add(saveCommand);
            CommandBindings.Add(openCommand);
            CommandBindings.Add(deleteCommand);
            CommandBindings.Add(copyCommand);
            CommandBindings.Add(pasteCommand);

        }
        void canExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            if (inputTextBox.Text.Trim().Length > 0) e.CanExecute = true; else e.CanExecute = false;
        }
        void execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            System.IO.File.WriteAllText("d:\\myFile.txt", inputTextBox.Text);
            MessageBox.Show("The file was saved!");
        }

        void canExecute_Open(object sender, CanExecuteRoutedEventArgs e)
        {
            if (inputTextBox.Text.Trim().Length == 0) e.CanExecute = true; else e.CanExecute = false;
        }
        void execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true){
                inputTextBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }
        void canExecute_Delete(object sender, CanExecuteRoutedEventArgs e)
        {
            if (inputTextBox.Text.Trim().Length > 0) e.CanExecute = true; else e.CanExecute = false;
        }
        void execute_Delete(object sender, ExecutedRoutedEventArgs e)
        {
                inputTextBox.Text = "";
        }
        void canExecute_Copy(object sender, CanExecuteRoutedEventArgs e)
        {
            if (inputTextBox.Text.Trim().Length > 0) e.CanExecute = true; else e.CanExecute = false;
        }
        void execute_Copy(object sender, ExecutedRoutedEventArgs e)
        {
            Clipboard.SetText(inputTextBox.Text);
        }
        void canExecute_Paste(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        void execute_Paste(object sender, ExecutedRoutedEventArgs e)
        {
            inputTextBox.Text += Clipboard.GetText();
        }
    }
}

