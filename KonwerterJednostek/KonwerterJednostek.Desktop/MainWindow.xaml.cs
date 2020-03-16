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

namespace KonwerterJednostek.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            combobox.ItemsSource = new List<string>()
            {
                "napis1",
                "napis2",
                "napis3"
            };
        }

        private void actionButton_Click(object sender, RoutedEventArgs e)
        {
            //Temp conv = new Temp();
            string input = inputTextbox.Text;
            string output = "witaj " + input;
            outputTextblock.Text = output;
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Wybrałeś: " + combobox.SelectedItem); 
        }
    }
}
