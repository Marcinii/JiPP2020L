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

            List<string> napisy_tjeden = new List<string>()
            {
                "K",
                "F",
                "C"
            };
            combobox_tjeden.ItemsSource = napisy_tjeden;
            List<string> napisy_tdwa = new List<string>()
            {
                "K",
                "F",
                "C"
            };
            combobox_tdwa.ItemsSource = napisy_tdwa;
            List<string> napisy_ljeden = new List<string>()
            {
                "M",
                "KM",
                "MI"
            };
            combobox_ljeden.ItemsSource = napisy_ljeden;
            List<string> napisy_ldwa = new List<string>()
            {
                "M",
                "KM",
                "MI"
            };
            combobox_ldwa.ItemsSource = napisy_ldwa;
            List<string> napisy_wjeden = new List<string>()
            {
                "KG",
                "G",
                "F"
            };
            combobox_wjeden.ItemsSource = napisy_wjeden;
            List<string> napisy_wdwa = new List<string>()
            {
                "KG",
                "G",
                "F"
            };
            combobox_wdwa.ItemsSource = napisy_wdwa;
        }

        private void Button_Clickt(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBoxt.Text;

            decimal value = decimal.Parse(inputValue); // TryParse!

            decimal result = new TemperatureConverter().Convert(combobox_tjeden.SelectedItem.ToString(), combobox_tdwa.SelectedItem.ToString(), value);

            outputTextBlockt.Text = result.ToString();
        }
        private void Button_Clickl(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBoxl.Text;

            decimal value = decimal.Parse(inputValue); // TryParse!

            decimal result = new UnitConverter.LengthConverter().Convert(combobox_ljeden.SelectedItem.ToString(), combobox_ldwa.SelectedItem.ToString(), value);

            outputTextBlockl.Text = result.ToString();
        }
        private void Button_Clickw(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBoxw.Text;

            decimal value = decimal.Parse(inputValue); // TryParse!

            decimal result = new WeightConverter().Convert(combobox_wjeden.SelectedItem.ToString(), combobox_wdwa.SelectedItem.ToString(), value);

            outputTextBlockw.Text = result.ToString();
        }
    }
}
