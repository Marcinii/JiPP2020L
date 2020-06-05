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

namespace Kontrolka
{
    /// <summary>
    /// Logika interakcji dla klasy Control1.xaml
    /// </summary>
    public partial class Control1 : UserControl
    {
        List<Todo> items = new List<Todo>();
        public Control1()
        {
            InitializeComponent();


        }
        public class Todo
        {
            public int Liczba { get; set; } 
            public string przed { get; set; }
            public Todo(int i,string x)
            {
                Liczba = i;
                przed = x;
            }
        }
    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int i = ListaPrzedmiotow.Items.Count + 1;
            ListaPrzedmiotow.Items.Add(i + ". " + Nazwa.Text);

            items.Add(new Todo(i, Nazwa.Text));
          
        }
    }
}
