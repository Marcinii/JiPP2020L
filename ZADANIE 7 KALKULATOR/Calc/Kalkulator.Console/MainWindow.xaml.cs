using Kalkulator.Logic;
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

namespace Kalkulator.Console
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ConverterCombobox.ItemsSource = new ActionService().GetDzialanies();

            RateContol.RateValue = 2;

            RateContol.RateValueChanged += RateContol_RateValueChanged;

        }


        private void RateContol_RateValueChanged(int value)
        {
            DodajOcene.OcenaDodaj(value, DateTime.Now);
        }
              
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            loaderPanel.Visibility = Visibility.Visible;
            ellipse.Visibility = Visibility.Visible;
            komunikat.Visibility = Visibility.Visible;


            ((Storyboard)Resources["CircleStoryboard"]).Begin();
            Thread Opoznij = new Thread(() => WyswietlOceny());
            Opoznij.Start();
        }
        private void WyswietlOceny()
        {
            Model Ocena = new Model();
            var wyswietl = from a in Ocena.Ocenki.OrderBy(e => e.ID) select a;
            Thread.Sleep(5000);
            Dispatcher.Invoke(() =>
            {
                statisticDataGrid.ItemsSource = wyswietl.ToList();

                loaderPanel.Visibility = Visibility.Hidden;
                ellipse.Visibility = Visibility.Hidden;
                komunikat.Visibility = Visibility.Hidden;

                ((Storyboard)Resources["CircleStoryboard"]).Stop();

            });
        }
           

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            BazaCalcManagementDBEntities db = new BazaCalcManagementDBEntities();
            var statsy = from d in db.DaneCalcs
                         select new
                         {
                             FirstPick = d.PierwszaLicz,
                             SecondPick = d.DrugaLicz,
                             Actions = d.TypDzial,
                             Result = d.WynikDzial
                         };

            foreach (var item in statsy)
            {
                System.Console.WriteLine(item.FirstPick);
                System.Console.WriteLine(item.SecondPick);
                System.Console.WriteLine(item.Actions);
                System.Console.WriteLine(item.Result);
            }

            this.kalkstats.ItemsSource = statsy.ToList();
        }
    


        private void ConverterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //pojawianie się elementów obrazow dla dodawanie itd
            var dane = this.ConverterCombobox.SelectedItem.ToString();
            if (ConverterCombobox.SelectedIndex == 0)
            {
                ps.Visibility = Visibility.Visible;
                ms.Visibility = Visibility.Hidden;
                dl.Visibility = Visibility.Hidden;
                ry.Visibility = Visibility.Hidden;
            }
            else if (ConverterCombobox.SelectedIndex == 1)
            {
                ps.Visibility = Visibility.Hidden;
                ms.Visibility = Visibility.Visible;
                dl.Visibility = Visibility.Hidden;
                ry.Visibility = Visibility.Hidden;
            }
            else if (ConverterCombobox.SelectedIndex == 2)
            {
                ps.Visibility = Visibility.Hidden;
                ms.Visibility = Visibility.Hidden;
                dl.Visibility = Visibility.Hidden;
                ry.Visibility = Visibility.Visible;
            }
            else if (ConverterCombobox.SelectedIndex == 3)
            {
                ps.Visibility = Visibility.Hidden;
                ms.Visibility = Visibility.Hidden;
                dl.Visibility = Visibility.Visible;
                ry.Visibility = Visibility.Hidden;
            }
        }
            private void ObliczButton_Click(object sender, RoutedEventArgs e)
        {
            string first = inputFirst.Text;
            string second = inputSecond.Text;
            double wartosc1 = double.Parse(first);
            double wartosc2 = double.Parse(second);

            double wynik = ((IDzialanie)ConverterCombobox.SelectedItem).Oblicz(wartosc1, wartosc2);

            outputTextblock.Text = wynik.ToString();

        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["squareStoryboard"]).Begin();
            ((Storyboard)Resources["Square2Storyboard"]).Begin();
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["squareStoryboard"]).Stop();
            ((Storyboard)Resources["Square2Storyboard"]).Stop();
        }


    }
}
