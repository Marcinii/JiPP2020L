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
using Przelicznik_Jednostek;

namespace Przelicznik_Jednostke.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ComboBox_Unit.ItemsSource = new List<string>()
            {
                "Przelicz na F",
                "Przelicz na C",
                "Przelicz na KM",
                "Przelicz na M",
                "Przelicz na Ibs",
                "Przelicz na KG",
            };
        }

        private void Button_Convert_Click(object sender, RoutedEventArgs e)
        {
            //Dzialania operacja = new Dzialania();
            if (ComboBox_Unit.SelectedItem == "Przelicz na F")
            {
                string input = TexBox_Number.Text;
                double jednostka = double.Parse(input);
                double wyniczek = new Dzialania().fahrenheit(jednostka);
                TextBlock_Converted.Text = wyniczek.ToString();
            }
            if (ComboBox_Unit.SelectedItem == "Przelicz na C")
            {
                string input = TexBox_Number.Text;
                double jednostka = double.Parse(input);
                double wyniczek = new Dzialania().celcjusz(jednostka);
                TextBlock_Converted.Text = wyniczek.ToString();
            }
            if (ComboBox_Unit.SelectedItem == "Przelicz na KM")
            {
                string input = TexBox_Number.Text;
                double jednostka = double.Parse(input);
                double wyniczek = new Dzialania().kilometry(jednostka);
                TextBlock_Converted.Text = wyniczek.ToString();
            }
            if (ComboBox_Unit.SelectedItem == "Przelicz na M")
            {
                string input = TexBox_Number.Text;
                double jednostka = double.Parse(input);
                double wyniczek = new Dzialania().mile(jednostka);
                TextBlock_Converted.Text = wyniczek.ToString();
            }
            if (ComboBox_Unit.SelectedItem == "Przelicz na Ibs")
            {
                string input = TexBox_Number.Text;
                double jednostka = double.Parse(input);
                double wyniczek = new Dzialania().funty(jednostka);
                TextBlock_Converted.Text = wyniczek.ToString();
            }
            if (ComboBox_Unit.SelectedItem == "Przelicz na KG")
            {
                string input = TexBox_Number.Text;
                double jednostka = double.Parse(input);
                double wyniczek = new Dzialania().kilogramy(jednostka);
                TextBlock_Converted.Text = wyniczek.ToString();
            }
        }
    }
}
