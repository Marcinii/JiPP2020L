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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Todo.CustomControls
{
    /// <summary>
    /// Interaction logic for TodoView.xaml
    /// </summary>
    public partial class TodoView : UserControl
    {
        public TodoView()
        {
            InitializeComponent();
        }
        public event EventHandler<TodoCompletedEventArgs> TodoCompletedChanged;

        public class TodoCompletedEventArgs : EventArgs
        {
            public bool Completed { get; set; }
        }

        public void SetTitle(string title)
        {
            TitleLabel.Content = title;
        }

        public void SetContent(string content)
        {
            ContentTextBlock.Text = content;
        }

        public void SetDate(DateTime date)
        {
            DateLabel.Content = date.ToString();
        }

        public void IsCompleted(bool is_completed)
        {
            CompletedCheckBox.IsChecked = is_completed;
        }

        private void CompletedCheckBox_Click(object sender, RoutedEventArgs e)
        {
            var is_completed = CompletedCheckBox.IsEnabled;
            TodoCompletedChanged(sender, new TodoCompletedEventArgs() { Completed = is_completed});
        }
    }
}
