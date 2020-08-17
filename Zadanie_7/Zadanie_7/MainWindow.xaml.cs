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
        }

        private void WybierzFigura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            coLiczysz.ItemsSource = ((Ifigury)wybierzFigura.SelectedItem).what;

            // wrunek do pokazania figury
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
           
            wynik.Text = value2;
        
        }
    }
}
