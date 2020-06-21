using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Todo.Logic;

namespace Todo.Desktop
{
    public partial class TodoWindow : Window
    {
        ITodo thisTodo;
        public TodoWindow(ITodo todo)
        {
            InitializeComponent();
            SetTodoViewData(todo);
            thisTodo = todo;
        }

        private void SetTodoViewData(ITodo todo)
        {
            TodoView.SetTitle(todo.Title);
            TodoView.SetContent(todo.Content);
            TodoView.SetDate(todo.date_added);
            TodoView.IsCompleted(todo.IsFinished);
        }

        private void TodoView_TodoCompletedChanged(object sender, CustomControls.TodoView.TodoCompletedEventArgs e)
        {
            thisTodo.IsFinished = e.Completed;
            Db.UpdateTodoFinished(thisTodo);
        }
    }
}
