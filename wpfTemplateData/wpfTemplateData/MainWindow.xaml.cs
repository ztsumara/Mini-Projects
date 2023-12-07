using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace wpfTemplateData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<MyTask> listTasks;
        MyTask newTask = new();
        public MainWindow()
        {
            InitializeComponent();

            List<string> listPhones = new() { "IPhone 10", "Nexus 7", "Galaxy A22 Edge" };
            listBoxPhones.ItemsSource = listPhones;

            listTasks = new()
            {
                new MyTask() { TaskName="Помыть руки", Description="с мылом", Priority=1},
                new MyTask() { TaskName="Купить еды", Description="в кафе", Priority=2},
                new MyTask() { TaskName="Выбрать столик", Priority=3},
                new MyTask() { TaskName="Покушать", Priority=4},
            };
            listBoxTasks.ItemsSource = listTasks;

            stackPanel_add.DataContext = newTask;

            buAdd.Click += BuAdd_Click;
        }

        private void BuAdd_Click(object sender, RoutedEventArgs e)
        {
            listTasks.Add(newTask);
        }
    }

    class MyTask : IDataErrorInfo
    {
        public string? TaskName { get; set;}
        public string? Description { get; set;}
        public int? Priority { get; set;}


        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case "TaskName":
                        break;
                    case "Priority":
                        if ((this.Priority<0) || (this.Priority > 10))
                        {
                            error = "Приоритет должен быть больше 0 и меньше 10";
                        }
                        break;
                }
                return error;
            }
        }

        public string Error => throw new NotImplementedException();


    }
}
