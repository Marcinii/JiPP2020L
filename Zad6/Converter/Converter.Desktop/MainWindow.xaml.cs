using Converter.Logic;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

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

            //ODCZYTUJE OCENE
            rateControl.RateValue = PodajOceneZBazy();
        }

        public static int PodajOceneZBazy()
        {
            using (DreamsEntities context = new DreamsEntities())
            {
                List<Dreams> dreams = context.Dreams.ToList();
                Dreams d = dreams.LastOrDefault();
                return d.Rate;
            }
            return 0;
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            ((Storyboard)FindResource("animuj_ladowanie")).Begin();
            ladowanie.Visibility = Visibility.Visible;
            ladowanie_napis.Visibility = Visibility.Visible;
            var konwerter = ((IConverter)combo.SelectedItem);
            var tekst = box.Text;
            Thread t = new Thread(() =>
            {
                Convert(konwerter, tekst);
            });
            t.Start();
        }
        private void Convert(IConverter konwerter, string tekst)
        {
            Thread.Sleep(2000);

            if (konwerter.ToString() == "Converter.Logic.zegar")
            {
                int g = int.Parse((wynik.Text).Substring(0, 2));
                int m = int.Parse((wynik.Text).Substring(3, 2));

                Dispatcher.Invoke(() =>
                {
                    big.RenderTransform = new RotateTransform(g * 30);
                    small.RenderTransform = new RotateTransform(m * 6);
                });
            }
            Dispatcher.Invoke(() =>
            {
                ladowanie_napis.Visibility = Visibility.Hidden;
                ladowanie.Visibility = Visibility.Hidden;
                wynik.Text = konwerter.Konwertuj(tekst);
            });
        }
        private void button_Click(object sender, RoutedEventArgs e) // 
        {
            wynik.Text = ((IConverter)combo.SelectedItem).Konwertuj(box.Text);

            if (((IConverter)combo.SelectedItem).ToString() == "Converter.Logic.zegar")
            {
                int g = int.Parse((wynik.Text).Substring(0, 2));
                int m = int.Parse((wynik.Text).Substring(3, 2));

                big.RenderTransform = new RotateTransform(g * 30);
                small.RenderTransform = new RotateTransform(m * 6);
            };
        }
        private bool _isFirst = true;
        private void rateControl_RateValueChanged(object sender, Common.Controls.RateEventArgs e)
        {
            //ZAPISUJE DO BAZY NOWA WARTOSC OCENY
            int stara;
            using (DreamsEntities context = new DreamsEntities())
            {
                stara = PodajOceneZBazy();
                Dreams newDream = new Dreams()
                {
                    Rate = e.Value
                };
                context.Dreams.Add(newDream);
                context.SaveChanges();
            }
            if (!_isFirst && stara == e.Value)
            {
                rateControl.Odznacz();
                using (DreamsEntities context = new DreamsEntities())
                {
                    List<Dreams> dreams = context.Dreams.ToList();
                    Dreams d = dreams.LastOrDefault();
                    d.Rate = 0;
                    context.SaveChanges();
                }
            }
            _isFirst = false;
        }


    }
}
