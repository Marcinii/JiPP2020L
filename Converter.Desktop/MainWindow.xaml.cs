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

            Category.ItemsSource= new List<IConverter>()
            {
                new Temperatura(),
                new Dystans(),
                new Masa(),
                new Powierzchnia(),
                new Zegar()
            };

            Tarcza.Visibility = Visibility.Hidden;
            Godzinowa.Visibility = Visibility.Hidden;
            Minutowa.Visibility = Visibility.Hidden;
        }

        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UnitFrom.ItemsSource = ((IConverter)Category.SelectedItem).Units;
            UnitTo.ItemsSource = ((IConverter)Category.SelectedItem).Units;

            Tarcza.Visibility = Visibility.Hidden;
            Godzinowa.Visibility = Visibility.Hidden;
            Minutowa.Visibility = Visibility.Hidden;

            if (((IConverter)Category.SelectedItem).Name == "Zegar")
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
            if (((IConverter)Category.SelectedItem).Name == "Zegar")
            {
                TimeSpan.TryParse(Toconvert.Text, out TimeSpan ts);
                int hours = ts.Hours;
                int minutes = ts.Minutes;

                string res;
                double hoursConverted = ((Zegar)Category.SelectedItem).convert(hours, UnitFrom.Text, UnitTo.Text);
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
                Minutowa.RenderTransform = new RotateTransform(360/60*minutes);
                Godzinowa.RenderTransform = new RotateTransform(360/12*hours+360.0/60/12*minutes);

            }
            else
            {
                double.TryParse(Toconvert.Text, out double value);
                Converted.Content = ((IConverter)Category.SelectedItem).convert(value, UnitFrom.Text, UnitTo.Text);
            }
        }
    }
}
