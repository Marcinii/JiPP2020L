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
using UnitConverter.Desktop;

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
            List<string> godzina = new List<string>()
            {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"
            };
            combobox_tg.ItemsSource = godzina;
            List<string> minuta = new List<string>()
            {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"
            };
            combobox_tm.ItemsSource = minuta;
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
        private void Button_Clickti(object sender, RoutedEventArgs e)
        {
            string inputValue = combobox_tg.Text;

            decimal value = decimal.Parse(inputValue); // TryParse!

            decimal result = new TimeConverter().Convert(value);

            outputTextBlock_th.Text = result.ToString();
            outputTextBlock_tm.Text = combobox_tm.Text;

            if(Int16.Parse(inputValue) >= 0 && Int16.Parse(inputValue) <= 11)
                outputTextBlock_ap.Text = "AM";
            else
                outputTextBlock_ap.Text = "PM";
            RotateTransform rotateTransform1 = new RotateTransform(Int16.Parse(outputTextBlock_tm.Text) *6);
            BlackM.RenderTransform = rotateTransform1;
            RotateTransform rotateTransform2 = new RotateTransform(Int16.Parse(outputTextBlock_th.Text) * 30);
            BlackH.RenderTransform = rotateTransform2;
        }
        private void rateControl_RateValueChanged(object sender, Common.Controls.RateEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rateControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
