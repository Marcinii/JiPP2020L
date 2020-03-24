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
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Threading;

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
            new konwenter_cisnienia(),
            new konwenter_czasu()
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

            List<string> czas = new List<string>()
            {
                "24h na 12h"
            };
            czasComboBox.ItemsSource = czas;
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

        private void czasComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string inputA = czasTextBox.Text;
            double a = double.Parse(inputA);
            double result = new konwenter_czasu().Konwertuj("24h", "12h", a);
            
                if (a < 24)
                {

                    string strefa;
                    if (a > 12)
                    {
                        strefa = "PM";
                    }
                    else
                    {
                        strefa = "AM";
                    }

                    czas_godzinyTextBlock.Text = result.ToString() + ":" + czas_minutyTextBox.Text + " " + strefa;
                    jednostkaczasuTextBlock.Text = strefa;
                    ZmienGodzineNaZegarze(result);
                }

                else
                {
                    czas_godzinyTextBlock.Text = "Podaj Poprawna godzine";
                }
            
        }




        
        private void ZmienGodzineNaZegarze(double godziny)
        {
            RotateTransform transformacjaGodzin = new RotateTransform
            {
                CenterX = 100,
                CenterY = 100,
                Angle = godziny / 12 * 360
            };

            RotateTransform transformacjaMinut = new RotateTransform
            {
                CenterX = 100,
                CenterY = 100,
                Angle = (double.Parse(czas_minutyTextBox.Text) / 60) * 360
            };

            Godzina.RenderTransform = transformacjaGodzin;
            Minuta.RenderTransform = transformacjaMinut;

        }
        private void czasTextBox_TextChanged(object sender, TextChangedEventArgs e) { }




        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["Storyboard1"]).Begin();
            ((Storyboard)Resources["Storyboard2"]).Begin();
        }
        bool on = true;
        private void button2_Click(object sender, RoutedEventArgs e)
        {

            if (on)
            {
                ((Storyboard)Resources["Storyboard3"]).Begin();
                showTextBlock.Text = "OFF";
                showTextBlock.Background = Brushes.Red;
                on = false;
            }
            else
            {
                ((Storyboard)Resources["Storyboard3"]).Stop();
                showTextBlock.Text = "ON";
                showTextBlock.Background = Brushes.Green;
                on = true;
            }

        }
    }
}
        





           
    
    

