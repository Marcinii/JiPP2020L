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

namespace KonwerterJednostek.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Category.ItemsSource = new List<IKonwerter>()
            {
                new KonwerterTemperatury(),
                new KonwerterDlugosci(),
                new KonwerterMasy(),
                new KonwerterCzasu(),
                new KonwerterZegar()
            };

            Tarcza.Visibility = Visibility.Hidden;
            Godzinowa.Visibility = Visibility.Hidden;
            Minutowa.Visibility = Visibility.Hidden;
        }

        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UnitFrom.ItemsSource = ((IKonwerter)Category.SelectedItem).Units;
            UnitTo.ItemsSource = ((IKonwerter)Category.SelectedItem).Units;

            Tarcza.Visibility = Visibility.Hidden;
            Godzinowa.Visibility = Visibility.Hidden;
            Minutowa.Visibility = Visibility.Hidden;

            if (((IKonwerter)Category.SelectedItem).Name == "Zegar")
            {
                Tarcza.Visibility = Visibility.Visible;
                Godzinowa.Visibility = Visibility.Visible;
                Minutowa.Visibility = Visibility.Visible;
                Storyboard sb = this.FindResource("TarczaStory") as Storyboard;
                Storyboard.SetTarget(sb, Tarcza);
                sb.Begin();
            }
        }

        private void Convert(object sender, RoutedEventArgs e)
        {
            if (((IKonwerter)Category.SelectedItem).Name == "Zegar")
            {
                TimeSpan.TryParse(Toconvert.Text, out TimeSpan ts);
                int hours = ts.Hours;
                int minutes = ts.Minutes;

                string res;
                decimal hoursConverted = ((KonwerterZegar)Category.SelectedItem).Konwerter(UnitFrom.Text, UnitTo.Text, hours);
                if (hours > 11)
                {
                    res = String.Concat(hoursConverted, ":", minutes, " PM");
                }
                else if (hours == 0)
                {
                    res = String.Concat("12:", minutes, " AM");
                }
                else
                {
                    res = String.Concat(hoursConverted, ":", minutes, " AM");
                }

                Converted.Content = res;
                Minutowa.RenderTransform = new RotateTransform(360 / 60 * minutes);
                Godzinowa.RenderTransform = new RotateTransform(360 / 12 * hours + 360.0 / 60 / 12 * minutes);

            }
            else
            {
                decimal.TryParse(Toconvert.Text, out decimal value);
                Converted.Content = ((IKonwerter)Category.SelectedItem).Konwerter(UnitFrom.Text, UnitTo.Text, value);
            }
        }

    }
}