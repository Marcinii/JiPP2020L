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

namespace MyControls
{
    /// <summary>
    /// Interaction logic for DataControl.xaml
    /// </summary>
    public partial class DataControl : UserControl
    {
        public event EventHandler OnClick;
        public DataControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnClick?.Invoke(this, new DataEventArgs()
            {
                a = aField.Text,
                b = bField.Text,
                h = hField.Text,
                r = rField.Text,
                item = brylaCombobox.SelectedItem.ToString()
            });
        }

        public void SetItems(List<string> items)
        {
            brylaCombobox.ItemsSource = items;
            brylaCombobox.SelectedIndex = 0;
        }

        public class DataEventArgs : EventArgs
        {
            public string item;
            public string a, b, h, r;
        }
    }
}
