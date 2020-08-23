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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            wyswietlDane();
            RatingControls.RateValueChanged += RatingControls_RateValueChanged;
            wyswietlOcene();
        }

        private void RatingControls_RateValueChanged(int value)
        {
            MessageBox.Show($"Dziękujemy za Twoją ocenę! {value}");
            dodanieRekordu.dodajOcene(value);
            wyswietlOcene();
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
            wysiwetla.ItemsSource = wysiweitl.ToList();
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
                    wypisz.Visibility = System.Windows.Visibility.Visible;
                    a.Visibility = System.Windows.Visibility.Visible;
                    blok1.Visibility = System.Windows.Visibility.Visible;
                    submitButton.Visibility = System.Windows.Visibility.Visible;
                    h.Visibility = System.Windows.Visibility.Hidden;
                    blok2.Visibility = System.Windows.Visibility.Hidden;
                    b.Visibility = System.Windows.Visibility.Visible;
                    blok3.Visibility = System.Windows.Visibility.Visible;
                    c.Visibility = System.Windows.Visibility.Visible;
                    blok4.Visibility = System.Windows.Visibility.Visible;
                    wynikTO.Visibility = System.Windows.Visibility.Visible;
                    wynik.Visibility = System.Windows.Visibility.Visible;
           
                }
                else if (zak == 2)
                {
                    wypisz.Visibility = System.Windows.Visibility.Visible;
                    a.Visibility = System.Windows.Visibility.Visible;
                    blok1.Visibility = System.Windows.Visibility.Visible;
                    submitButton.Visibility = System.Windows.Visibility.Visible;
                    h.Visibility = System.Windows.Visibility.Hidden;
                    blok2.Visibility = System.Windows.Visibility.Hidden;
                    b.Visibility = System.Windows.Visibility.Hidden;
                    blok3.Visibility = System.Windows.Visibility.Hidden;
                    c.Visibility = System.Windows.Visibility.Hidden;
                    blok4.Visibility = System.Windows.Visibility.Hidden;
                    wynikTO.Visibility = System.Windows.Visibility.Visible;
                    wynik.Visibility = System.Windows.Visibility.Visible;
              
                }
                else if (zak == 3)
                {
                    wypisz.Visibility = System.Windows.Visibility.Visible;
                    a.Visibility = System.Windows.Visibility.Visible;
                    blok1.Visibility = System.Windows.Visibility.Visible;
                    submitButton.Visibility = System.Windows.Visibility.Visible;
                    h.Visibility = System.Windows.Visibility.Visible;
                    blok2.Visibility = System.Windows.Visibility.Visible;
                    b.Visibility = System.Windows.Visibility.Hidden;
                    blok3.Visibility = System.Windows.Visibility.Hidden;
                    c.Visibility = System.Windows.Visibility.Hidden;
                    blok4.Visibility = System.Windows.Visibility.Hidden;
                    wynikTO.Visibility = System.Windows.Visibility.Visible;
                    wynik.Visibility = System.Windows.Visibility.Visible;
                   
                }
                else if (zak == 4)
                {
                    wypisz.Visibility = System.Windows.Visibility.Visible;
                    a.Visibility = System.Windows.Visibility.Visible;
                    blok1.Visibility = System.Windows.Visibility.Visible;
                    submitButton.Visibility = System.Windows.Visibility.Visible;
                    h.Visibility = System.Windows.Visibility.Hidden;
                    blok2.Visibility = System.Windows.Visibility.Hidden;
                    b.Visibility = System.Windows.Visibility.Hidden;
                    blok3.Visibility = System.Windows.Visibility.Hidden;
                    c.Visibility = System.Windows.Visibility.Hidden;
                    blok4.Visibility = System.Windows.Visibility.Hidden;
                    wynikTO.Visibility = System.Windows.Visibility.Hidden;
                    wynik.Visibility = System.Windows.Visibility.Hidden;
                    
                }
                else
                {
                    wypisz.Visibility = System.Windows.Visibility.Hidden;
                    a.Visibility = System.Windows.Visibility.Hidden;
                    blok1.Visibility = System.Windows.Visibility.Hidden;
                    submitButton.Visibility = System.Windows.Visibility.Hidden;
                    h.Visibility = System.Windows.Visibility.Hidden;
                    blok2.Visibility = System.Windows.Visibility.Hidden;
                    b.Visibility = System.Windows.Visibility.Hidden;
                    blok3.Visibility = System.Windows.Visibility.Hidden;
                    c.Visibility = System.Windows.Visibility.Hidden;
                    blok4.Visibility = System.Windows.Visibility.Hidden;
                    wynikTO.Visibility = System.Windows.Visibility.Hidden;
                    wynik.Visibility = System.Windows.Visibility.Hidden;
                   
                }
            }
            if (value2 == "Zadanie_7.trojkat")
            {
                dla_trojkat.Visibility = System.Windows.Visibility.Visible;
                dla_kwadrat.Visibility = System.Windows.Visibility.Hidden;
            }else if (value2 == "Zadanie_7.kwadrat")
            {
                dla_trojkat.Visibility = System.Windows.Visibility.Hidden;
                dla_kwadrat.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                dla_trojkat.Visibility = System.Windows.Visibility.Hidden;
                dla_kwadrat.Visibility = System.Windows.Visibility.Hidden;
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
                wypisz.Visibility = System.Windows.Visibility.Visible;
                a.Visibility = System.Windows.Visibility.Visible;
                blok1.Visibility = System.Windows.Visibility.Visible;
                submitButton.Visibility = System.Windows.Visibility.Visible;
                h.Visibility = System.Windows.Visibility.Hidden;
                blok2.Visibility = System.Windows.Visibility.Hidden;
                b.Visibility = System.Windows.Visibility.Visible;
                blok3.Visibility = System.Windows.Visibility.Visible;
                c.Visibility = System.Windows.Visibility.Visible;
                blok4.Visibility = System.Windows.Visibility.Visible;
                wynikTO.Visibility = System.Windows.Visibility.Visible;
                wynik.Visibility = System.Windows.Visibility.Visible;
            }
            else if(zak == 2)
            {
                wypisz.Visibility = System.Windows.Visibility.Visible;
                a.Visibility = System.Windows.Visibility.Visible;
                blok1.Visibility = System.Windows.Visibility.Visible;
                submitButton.Visibility = System.Windows.Visibility.Visible;
                h.Visibility = System.Windows.Visibility.Hidden;
                blok2.Visibility = System.Windows.Visibility.Hidden;
                b.Visibility = System.Windows.Visibility.Hidden;
                blok3.Visibility = System.Windows.Visibility.Hidden;
                c.Visibility = System.Windows.Visibility.Hidden;
                blok4.Visibility = System.Windows.Visibility.Hidden;
                wynikTO.Visibility = System.Windows.Visibility.Visible;
                wynik.Visibility = System.Windows.Visibility.Visible;
            }
            else if (zak == 3)
            {
                wypisz.Visibility = System.Windows.Visibility.Visible;
                a.Visibility = System.Windows.Visibility.Visible;
                blok1.Visibility = System.Windows.Visibility.Visible;
                submitButton.Visibility = System.Windows.Visibility.Visible;
                h.Visibility = System.Windows.Visibility.Visible;
                blok2.Visibility = System.Windows.Visibility.Visible;
                b.Visibility = System.Windows.Visibility.Hidden;
                blok3.Visibility = System.Windows.Visibility.Hidden;
                c.Visibility = System.Windows.Visibility.Hidden;
                blok4.Visibility = System.Windows.Visibility.Hidden;
                wynikTO.Visibility = System.Windows.Visibility.Visible;
                wynik.Visibility = System.Windows.Visibility.Visible;
            }
            else if (zak == 4)
            {
                wypisz.Visibility = System.Windows.Visibility.Visible;
                a.Visibility = System.Windows.Visibility.Visible;
                blok1.Visibility = System.Windows.Visibility.Visible;
                submitButton.Visibility = System.Windows.Visibility.Visible;
                h.Visibility = System.Windows.Visibility.Hidden;
                blok2.Visibility = System.Windows.Visibility.Hidden;
                b.Visibility = System.Windows.Visibility.Hidden;
                blok3.Visibility = System.Windows.Visibility.Hidden;
                c.Visibility = System.Windows.Visibility.Hidden;
                blok4.Visibility = System.Windows.Visibility.Hidden;
                wynikTO.Visibility = System.Windows.Visibility.Hidden;
                wynik.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                wypisz.Visibility = System.Windows.Visibility.Hidden;
                a.Visibility = System.Windows.Visibility.Hidden;
                blok1.Visibility = System.Windows.Visibility.Hidden;
                submitButton.Visibility = System.Windows.Visibility.Hidden;
                h.Visibility = System.Windows.Visibility.Hidden;
                blok2.Visibility = System.Windows.Visibility.Hidden;
                b.Visibility = System.Windows.Visibility.Hidden;
                blok3.Visibility = System.Windows.Visibility.Hidden;
                c.Visibility = System.Windows.Visibility.Hidden;
                blok4.Visibility = System.Windows.Visibility.Hidden;
                wynikTO.Visibility = System.Windows.Visibility.Hidden;
                wynik.Visibility = System.Windows.Visibility.Hidden;
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
            wyswietlDane();
        }

        private void Statr_Button_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["CircleSpin"]).Begin();

        }

        private void Stop_Button_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["CircleSpin"]).Stop();
        }
    }
}
