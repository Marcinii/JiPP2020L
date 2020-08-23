using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Zadanie7.Logic;

namespace Zadanie_7
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            wybierzFigura.ItemsSource = new figuraChanged().pobierz();
           
            RatingControls.RateValueChanged += RatingControls_RateValueChanged;
           // wyswietlOcene();
        }

        private void RatingControls_RateValueChanged(int value)
        {
            MessageBox.Show($"Dziękujemy za Twoją ocenę! {value}");
            dodanieRekordu.dodajOcene(value);
          //  wyswietlOcene();
        }

       
        private void wyswietlOcene()
        {
            Model1 model = new Model1();
            var wuswietl = model.rates.Average(e => e.rate_value);
            avgRate.Text = wuswietl.ToString();
        }
        private void wyswietlDane()
        {
            Model1 model = new Model1();
            var wysiweitl = from d in model.data.OrderBy(e => e.id) select d;
            Thread.Sleep(5000);
            Dispatcher.Invoke(() => {

                wysiwetla.ItemsSource = wysiweitl.ToList();

                opoznij.Visibility = Visibility.Hidden;
                rectangle.Visibility = Visibility.Hidden;
                komunikat.Visibility = Visibility.Hidden;
                ((Storyboard)Resources["LoadingScreen"]).Stop();

            });
        }
        private void WybierzFigura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            coLiczysz.ItemsSource = ((Ifigury)wybierzFigura.SelectedItem).what;
           
            string value2 = ((Ifigury)wybierzFigura.SelectedItem).ToString();
           
            if (coLiczysz.SelectedItem != null)
            {
                string value1 = coLiczysz.SelectedItem.ToString();
                string zakres = new coWidoczne().coPokazac(value1, value2);
                double zak = double.Parse(zakres);

                if (zak == 1)
                {
                    wypisz.Visibility = Visibility.Visible;
                    a.Visibility = Visibility.Visible;
                    blok1.Visibility = Visibility.Visible;
                    submitButton.Visibility = Visibility.Visible;
                    h.Visibility = Visibility.Hidden;
                    blok2.Visibility = Visibility.Hidden;
                    b.Visibility = Visibility.Visible;
                    blok3.Visibility = Visibility.Visible;
                    c.Visibility = Visibility.Visible;
                    blok4.Visibility = Visibility.Visible;
                    wynikTO.Visibility = Visibility.Visible;
                    wynik.Visibility = Visibility.Visible;
           
                }
                else if (zak == 2)
                {
                    wypisz.Visibility = Visibility.Visible;
                    a.Visibility = Visibility.Visible;
                    blok1.Visibility = Visibility.Visible;
                    submitButton.Visibility = Visibility.Visible;
                    h.Visibility = Visibility.Hidden;
                    blok2.Visibility = Visibility.Hidden;
                    b.Visibility = Visibility.Hidden;
                    blok3.Visibility = Visibility.Hidden;
                    c.Visibility = Visibility.Hidden;
                    blok4.Visibility = Visibility.Hidden;
                    wynikTO.Visibility = Visibility.Visible;
                    wynik.Visibility = Visibility.Visible;
              
                }
                else if (zak == 3)
                {
                    wypisz.Visibility = Visibility.Visible;
                    a.Visibility = Visibility.Visible;
                    blok1.Visibility = Visibility.Visible;
                    submitButton.Visibility = Visibility.Visible;
                    h.Visibility = Visibility.Visible;
                    blok2.Visibility = Visibility.Visible;
                    b.Visibility = Visibility.Hidden;
                    blok3.Visibility = Visibility.Hidden;
                    c.Visibility = Visibility.Hidden;
                    blok4.Visibility = Visibility.Hidden;
                    wynikTO.Visibility = Visibility.Visible;
                    wynik.Visibility = Visibility.Visible;
                   
                }
                else if (zak == 4)
                {
                    wypisz.Visibility = Visibility.Visible;
                    a.Visibility = Visibility.Visible;
                    blok1.Visibility = Visibility.Visible;
                    submitButton.Visibility = Visibility.Visible;
                    h.Visibility = Visibility.Hidden;
                    blok2.Visibility = Visibility.Hidden;
                    b.Visibility = Visibility.Hidden;
                    blok3.Visibility = Visibility.Hidden;
                    c.Visibility = Visibility.Hidden;
                    blok4.Visibility = Visibility.Hidden;
                    wynikTO.Visibility = Visibility.Hidden;
                    wynik.Visibility = Visibility.Hidden;
                    
                }
                else
                {
                    wypisz.Visibility = Visibility.Hidden;
                    a.Visibility = Visibility.Hidden;
                    blok1.Visibility = Visibility.Hidden;
                    submitButton.Visibility = Visibility.Hidden;
                    h.Visibility = Visibility.Hidden;
                    blok2.Visibility = Visibility.Hidden;
                    b.Visibility = Visibility.Hidden;
                    blok3.Visibility = Visibility.Hidden;
                    c.Visibility = Visibility.Hidden;
                    blok4.Visibility = Visibility.Hidden;
                    wynikTO.Visibility = Visibility.Hidden;
                    wynik.Visibility = Visibility.Hidden;
                   
                }
            }
            if (value2 == "Zadanie_7.trojkat")
            {
                dla_trojkat.Visibility = Visibility.Visible;
                dla_kwadrat.Visibility = Visibility.Hidden;
            }else if (value2 == "Zadanie_7.kwadrat")
            {
                dla_trojkat.Visibility = Visibility.Hidden;
                dla_kwadrat.Visibility = Visibility.Visible;
            }
            else
            {
                dla_trojkat.Visibility = Visibility.Hidden;
                dla_kwadrat.Visibility = Visibility.Hidden;
            }
        }

        private void CoLiczysz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string value1 = coLiczysz.SelectedItem.ToString();
            string value2 = ((Ifigury)wybierzFigura.SelectedItem).ToString();
            string zakres = new coWidoczne().coPokazac(value1,value2);
            double zak = double.Parse(zakres);
          
            if (zak == 1)
            {
                wypisz.Visibility = Visibility.Visible;
                a.Visibility = Visibility.Visible;
                blok1.Visibility = Visibility.Visible;
                submitButton.Visibility = Visibility.Visible;
                h.Visibility = Visibility.Hidden;
                blok2.Visibility = Visibility.Hidden;
                b.Visibility = Visibility.Visible;
                blok3.Visibility = Visibility.Visible;
                c.Visibility = Visibility.Visible;
                blok4.Visibility = Visibility.Visible;
                wynikTO.Visibility = Visibility.Visible;
                wynik.Visibility = Visibility.Visible;
            }
            else if(zak == 2)
            {
                wypisz.Visibility = Visibility.Visible;
                a.Visibility = Visibility.Visible;
                blok1.Visibility = Visibility.Visible;
                submitButton.Visibility = Visibility.Visible;
                h.Visibility = Visibility.Hidden;
                blok2.Visibility = Visibility.Hidden;
                b.Visibility = Visibility.Hidden;
                blok3.Visibility = Visibility.Hidden;
                c.Visibility = Visibility.Hidden;
                blok4.Visibility = Visibility.Hidden;
                wynikTO.Visibility = Visibility.Visible;
                wynik.Visibility = Visibility.Visible;
            }
            else if (zak == 3)
            {
                wypisz.Visibility = Visibility.Visible;
                a.Visibility = Visibility.Visible;
                blok1.Visibility = Visibility.Visible;
                submitButton.Visibility = Visibility.Visible;
                h.Visibility = Visibility.Visible;
                blok2.Visibility = Visibility.Visible;
                b.Visibility = Visibility.Hidden;
                blok3.Visibility = Visibility.Hidden;
                c.Visibility = Visibility.Hidden;
                blok4.Visibility = Visibility.Hidden;
                wynikTO.Visibility = Visibility.Visible;
                wynik.Visibility = Visibility.Visible;
            }
            else if (zak == 4)
            {
                wypisz.Visibility = Visibility.Visible;
                a.Visibility = Visibility.Visible;
                blok1.Visibility = Visibility.Visible;
                submitButton.Visibility = Visibility.Visible;
                h.Visibility = Visibility.Hidden;
                blok2.Visibility = Visibility.Hidden;
                b.Visibility = Visibility.Hidden;
                blok3.Visibility = Visibility.Hidden;
                c.Visibility = Visibility.Hidden;
                blok4.Visibility = Visibility.Hidden;
                wynikTO.Visibility = Visibility.Hidden;
                wynik.Visibility = Visibility.Hidden;
            }
            else
            {
                wypisz.Visibility = Visibility.Hidden;
                a.Visibility = Visibility.Hidden;
                blok1.Visibility = Visibility.Hidden;
                submitButton.Visibility = Visibility.Hidden;
                h.Visibility = Visibility.Hidden;
                blok2.Visibility = Visibility.Hidden;
                b.Visibility = Visibility.Hidden;
                blok3.Visibility = Visibility.Hidden;
                c.Visibility = Visibility.Hidden;
                blok4.Visibility = Visibility.Hidden;
                wynikTO.Visibility = Visibility.Hidden;
                wynik.Visibility = Visibility.Hidden;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            double a =0 ,b =0 ,c =0 ,h =0;
           
            double.TryParse(blok1.Text, out a);
            double.TryParse(blok2.Text, out h);
            double.TryParse(blok3.Text, out b);
            double.TryParse(blok4.Text,out c);

            string value1 = coLiczysz.SelectedItem.ToString();
            string value2 =((Ifigury)wybierzFigura.SelectedItem).oblicz(value1,a,b,c,h).ToString();
            double.TryParse(value2, out double value3);
            wynik.Text = value2;

            string zapis = new coWidoczne().coWpisać(wybierzFigura.SelectedItem.ToString());

            dodanieRekordu.dodajeRekord(zapis, value1, a, b, c, h, value3);
          
        }

        private void Statr_Button_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["CircleSpin"]).Begin();

        }

        private void Stop_Button_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["CircleSpin"]).Stop();
        }

        private void loadDate_Click(object sender, RoutedEventArgs e)
        {
            opoznij.Visibility = Visibility.Visible;
            rectangle.Visibility = Visibility.Visible;
            komunikat.Visibility = Visibility.Visible;
            ((Storyboard)Resources["LoadingScreen"]).Begin();
            Thread thread = new Thread(() => wyswietlDane());
            thread.Start();
        }
    }
}
