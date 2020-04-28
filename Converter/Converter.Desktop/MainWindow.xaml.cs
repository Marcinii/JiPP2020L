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
using Converter.Logic;

namespace Converter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            combo.ItemsSource = new ConverterService().GetNames();
            konwerter.ItemsSource = new ConverterService().GetNames();
        }

        private void button_Click(object sender, RoutedEventArgs e) // 
        {
            wynik.Text = ((IConverter)combo.SelectedItem).Konwertuj(box.Text);
            using (var baza = new konwerteryEntities1())
            {
                baza.danes.Add(new dane
                {
                    data = DateTime.Now,
                    konwerter = ((IConverter)combo.SelectedItem).Name,
                    wejscie = float.Parse(box.Text),
                    wyjscie = float.Parse(wynik.Text),
                });
                baza.SaveChanges();
            }
            if (combo.ItemsSource.ToString() == "czas 24h na 12h")
            {
                int g = int.Parse((wynik.Text).Substring(0, 2));
                int m = int.Parse((wynik.Text).Substring(3, 2));

                big.RenderTransform = new RotateTransform(g * 30);
                small.RenderTransform = new RotateTransform(m * 6);
            }


            /*
            box11.Text = box.Text;
            bnabit a1 = new bnabit();
            box12.Text = a1.Konwertuj(box.Text);

            box21.Text = box.Text;
            bitnab a2 = new bitnab();
            box22.Text = a2.Konwertuj(box.Text);

            box31.Text = box.Text;
            cnaf a3 = new cnaf();
            box32.Text = a3.Konwertuj(box.Text);

            box41.Text = box.Text;
            fnac a4 = new fnac();
            box42.Text = a4.Konwertuj(box.Text);

            box51.Text = box.Text;
            cnakm a5 = new cnakm();
            box52.Text = a5.Konwertuj(box.Text);

            box61.Text = box.Text;
            kmnac a6 = new kmnac();
            box62.Text = a6.Konwertuj(box.Text);

            box71.Text = box.Text;
            kmnam a7 = new kmnam();
            box72.Text = a7.Konwertuj(box.Text);

            box81.Text = box.Text;
            mnakm a8 = new mnakm();
            box82.Text = a8.Konwertuj(box.Text);

            box91.Text = box.Text;
            mnac a9 = new mnac();
            box92.Text = a9.Konwertuj(box.Text);

            box101.Text = box.Text;
            cnam a10 = new cnam();
            box102.Text = a10.Konwertuj(box.Text);

            box111.Text = box.Text;
            kgnaf a11 = new kgnaf();
            box112.Text = a11.Konwertuj(box.Text);

            box121.Text = box.Text;
            fnakg a12 = new fnakg();
            box122.Text = a12.Konwertuj(box.Text);
            */
        }
        private void odswiez_dane()
        {
            var obecna = int.Parse(strona.Content.ToString());
            using (var baza = new konwerteryEntities1())
            {
                var dane = baza.danes.AsQueryable();
                if (datastart.SelectedDate != null)
                {
                    dane = dane.Where(x => x.data >= datastart.SelectedDate);
                }
                if (datakoniec.SelectedDate != null)
                {
                    dane = dane.Where(x => x.data <= datakoniec.SelectedDate);
                }
                if (konwerter.SelectedItem != null)
                {
                    dane = dane.Where(x => x.konwerter == ((IConverter)konwerter.SelectedItem).Name);
                }
                bazadane.ItemsSource = dane.OrderBy(x => x.id).Skip(20 * (obecna - 1)).Take(20).ToList();
            }
        }
        private void pokaz_Click(object sender, RoutedEventArgs e)
        {
            odswiez_dane();
        }

        private void top_Checked(object sender, RoutedEventArgs e)
        {
            using (var baza = new konwerteryEntities1())
            {
                var dane = baza.danes.GroupBy(x => new { x.konwerter, x.data, x.wejscie, x.wyjscie });
                if (datastart.SelectedDate != null)
                {
                    dane = dane.Where(x => x.Key.data >= datastart.SelectedDate);
                }
                if (datakoniec.SelectedDate != null)
                {
                    dane = dane.Where(x => x.Key.data <= datakoniec.SelectedDate);
                }
                if (konwerter.SelectedItem != null)
                {
                    dane = dane.Where(x => x.Key.konwerter == ((IConverter)konwerter.SelectedItem).Name);
                }
                var top = dane.Select(x => new { ile = x.Count(), x.Key.konwerter, x.Key.data, x.Key.wejscie, x.Key.wyjscie })
                    .OrderByDescending(x => x.ile)
                    .Take(3);
                bazadane.ItemsSource = top.ToList();
            }
        }

        private void top_Unchecked(object sender, RoutedEventArgs e)
        {
            odswiez_dane();

        }

        private void poprzednia_Click(object sender, RoutedEventArgs e)
        {
            var obecna = int.Parse(strona.Content.ToString());
            if (obecna > 1)
            {
                strona.Content = obecna - 1;
            }
            odswiez_dane();
        }

        private void nastepna_Click(object sender, RoutedEventArgs e)
        {
            var obecna = int.Parse(strona.Content.ToString());
            strona.Content = obecna + 1;
            odswiez_dane();
        }
    }
}
