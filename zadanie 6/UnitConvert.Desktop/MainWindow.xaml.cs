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
using UnitConverter;

namespace UnitConvert.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<string> napisy = new List<string>()
            {
                "napis 1",
                "napis 2",
                "napis 3"
            };

            combobox.ItemsSource = napisy;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new Temperature().Convert("C", "K", value);

            outputTextBlock.Text = result.ToString();
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Użytkownik wybrał: " + combobox.SelectedItem);
        }
    }
}
