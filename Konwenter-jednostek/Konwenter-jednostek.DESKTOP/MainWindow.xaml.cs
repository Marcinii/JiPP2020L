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

namespace Konwenter_jednostek.DESKTOP
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<IKonwenter> konwentery = new List<IKonwenter>()
        {
            new konwenter_temperatury(),
            new konwenter_dlugosci(),
            new konwenter_masy(),
            new konwenter_cisnienia()
        };

            List<string> temperatura = new List<string>()
            {
                "Celsjusze na Fahreinheity",
                "Fahreinheity na Celsjusze",
            };
            
            temperaturaComboBox.ItemsSource = temperatura;

            List<string> masa = new List<string>()
            {
                "Kilogramy na Funty",
                "Funty na Kilogramy",
                "Kilogramy na Tony",
                "Tony na Kilogramy",
                "Funty na Tony",
                "Tony na Funty",
            };
            masaComboBox.ItemsSource = masa;

            List<string> dlugosc = new List<string>()
            {
                "Kilometry na Mile",
                "Mile na Kilometry"
            };
            dlugoscComboBox.ItemsSource = dlugosc;

            List<string> cisnienie = new List<string>()
            {
                "Bar na Psi",
                "Psi na Bar"
            };
            cisnienieComboBox.ItemsSource = cisnienie;
        }

        private void temperaturaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
             {

                string inputA = temperaturaTextBox.Text;
                double a = double.Parse(inputA);
            

            if (temperaturaComboBox.SelectedItem.ToString() == "Celsjusze na Fahreinheity") 
            {
                    double result = new konwenter_temperatury().Konwertuj("C", "F", a);
                    temperaturaTextBlock.Text = result.ToString() + " °F ";
                    jednostkatemperaturyTextBlock.Text = "°C";
                }
                else
                {
                    double result = new konwenter_temperatury().Konwertuj("F", "C", a);
                    temperaturaTextBlock.Text = result.ToString() + " °C ";
                    jednostkatemperaturyTextBlock.Text = "°F";
                }
            
            
        }
        private void temperaturaTextBox_TextChanged(object sender, TextChangedEventArgs e) { }

        private void masaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string inputA = masaTextBox.Text;
            double a = double.Parse(inputA);
            if (masaComboBox.SelectedItem.ToString() == "Kilogramy na Funty")
            {
                double result = new konwenter_masy().Konwertuj("kg", "funty", a);
                masaTextBlock.Text = result.ToString() + " f ";
                jednostkamasy_TextBlock.Text = "kg";
            }
            else if (masaComboBox.SelectedItem.ToString() == "Funty na Kilogramy")
            {
                double result = new konwenter_masy().Konwertuj("funty", "kg", a);
                masaTextBlock.Text = result.ToString() + " kg "; // WYNIK
                jednostkamasy_TextBlock.Text = "f"; // WARTOSC
            }
            else if (masaComboBox.SelectedItem.ToString() == "Kilogramy na Tony")
            {
                double result = new konwenter_masy().Konwertuj("kg", "tony", a);
                masaTextBlock.Text = result.ToString() + " ton "; // WYNIK
                jednostkamasy_TextBlock.Text = "kg"; // WARTOSC
            }
            else if (masaComboBox.SelectedItem.ToString() == "Tony na Kilogramy")
            {
                double result = new konwenter_masy().Konwertuj("tony", "kg", a);
                masaTextBlock.Text = result.ToString() + " kg "; // WYNIK
                jednostkamasy_TextBlock.Text = "ton"; // WARTOSC
            }
            else if (masaComboBox.SelectedItem.ToString() == "Funty na Tony")
            {
                double result = new konwenter_masy().Konwertuj("funty", "tony", a);
                masaTextBlock.Text = result.ToString() + " ton "; // WYNIK
                jednostkamasy_TextBlock.Text = "f"; // WARTOSC
            }
            else if (masaComboBox.SelectedItem.ToString() == "Tony na Funty")
            {
                double result = new konwenter_masy().Konwertuj("tony", "funty", a);
                masaTextBlock.Text = result.ToString() + " f "; // WYNIK
                jednostkamasy_TextBlock.Text = "ton"; // WARTOSC
            }
        }
        private void masaTextBox_TextChanged(object sender, TextChangedEventArgs e) { }

        private void dlugoscComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string inputA = temperaturaTextBox.Text;
            double a = double.Parse(inputA);


            if (dlugoscComboBox.SelectedItem.ToString() == "Kilometry na Mile")
            {
                double result = new konwenter_dlugosci().Konwertuj("km", "mile", a);
                dlugoscTextBlock.Text = result.ToString() + " mil ";
                jednostkadlugosci_TextBlock.Text = "km";
            }
            else
            {
                double result = new konwenter_dlugosci().Konwertuj("mile", "km", a);
                dlugoscTextBlock.Text = result.ToString() + " km ";
                jednostkadlugosci_TextBlock.Text = "mil";
            }

        }

        private void dlugoscTextBox_TextChanged(object sender, TextChangedEventArgs e) { }

        private void cisnienieComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string inputA = cisnienieTextBox.Text;
            double a = double.Parse(inputA);


            if (cisnienieComboBox.SelectedItem.ToString() == "Bar na Psi")
            {
                double result = new konwenter_cisnienia().Konwertuj("bar", "psi", a);
                cisnienieTextBlock.Text = result.ToString() + " psi ";
                jednostkacisnienia_TextBlock.Text = "bar";
            }
            else
            {
                double result = new konwenter_cisnienia().Konwertuj("psi", "bar", a);
                cisnienieTextBlock.Text = result.ToString() + " bar ";
                jednostkacisnienia_TextBlock.Text = "psi";
            }
           
        }
    }

}

           
    
    

