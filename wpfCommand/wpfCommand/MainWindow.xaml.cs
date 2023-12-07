using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace wpfCommand
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.New, CmdNew_Executed));
            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, CmdSave_Executed, CmdSave_CanExecuted));
            this.CommandBindings.Add(new CommandBinding(MyCommands.InsertTime, CmdTime_Executed));
            //this.CommandBindings.Add(new CommandBinding(MyCommands.InsertHello, CmdHello_Executed));
        }

        //private void InsertHello_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    edNote.Text += "hello";
        //}

        private void CmdTime_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            edNote.Text += DateTime.Now.ToString("HH:mm");
        }

        private void CmdNew_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            edNote.Clear();
        }

        private void CmdSave_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = edNote.Text != "";
        }


        private void CmdSave_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //MessageBox.Show("Сохранить");

            SaveFileDialog dialog = new();
            if (dialog.ShowDialog() == true)
                File.WriteAllText(dialog.FileName, edNote.Text);
        }



        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void InsertHello_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            edNote.Text += "hello";
        }
    }
    public class MyCommands
    {
        public static RoutedCommand InsertHello { get; set; } = new(nameof(InsertHello), typeof(MainWindow));
        public static RoutedCommand InsertTime { get; set; } = new(nameof(InsertTime), typeof(MainWindow));
    }
}
