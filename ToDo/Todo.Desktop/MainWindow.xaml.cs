using System;
using System.Collections.Generic;
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
using Todo.CustomControls;
using Todo.Logic;
using System.Windows.Media.Animation;
using System.Threading;

namespace Todo.Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadTodos();
        }

        private void LoadTodos()
        {
            var loading = (Storyboard)FindResource("LoadingAnimation");
            loading.Begin();
            var t = new Thread(() =>
            {
                Thread.Sleep(1500);
                var todos = Db.LoadAllUnfinishedTodos();
                Dispatcher.Invoke(() =>
                {
                    TodoListView.ItemsSource = todos;
                });
            });
            t.Start();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (TitleTextBox.Text != "")
            {
                Db.SaveNewTodo(new ToDo(TitleTextBox.Text, ContentTextBox.Text));
                LoadTodos();
            }
        }
        public void TodoWindowClosedHandler(object sender, CancelEventArgs e)
        {
            LoadTodos();
        }
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            if (TodoListView.SelectedIndex > -1)
            {
                var selected_todo = (ToDo)TodoListView.SelectedItem;
                TodoWindow todo = new TodoWindow(selected_todo);
                todo.Closing += TodoWindowClosedHandler;
                todo.Show();
            }
        }
    }
}
