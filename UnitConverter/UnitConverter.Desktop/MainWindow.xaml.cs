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
using UnitConverter.Logic;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            c1.ItemsSource = new ConverterService().GetConverters();
            c1.SelectedIndex = 0;
            c2.SelectedIndex = 0;
            c3.SelectedIndex = 1;
        }

        private void c1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            c2.ItemsSource = ((IConverter)c1.SelectedItem).Units;
            c3.ItemsSource = ((IConverter)c1.SelectedItem).Units;
            c2.SelectedIndex = 0;
            c3.SelectedIndex = 1;
            if (c1.SelectedIndex != 4)
            {
                ((Rectangle)r2).Visibility = Visibility.Hidden;
                ((Rectangle)r1).Visibility = Visibility.Hidden;
                ((Ellipse)el).Visibility = Visibility.Hidden;
            }
            else
            {
                ((Rectangle)r2).Visibility = Visibility.Visible;
                ((Rectangle)r1).Visibility = Visibility.Visible;
                ((Ellipse)el).Visibility = Visibility.Visible;
            }
        }

        private void but_Click(object sender, RoutedEventArgs e)
        {
            if (c1.SelectedIndex != 4) { block.Text = (((IConverter)c1.SelectedItem).Convert(c2.Text, c3.Text, double.Parse((box.Text)))).ToString(); }
            else
            {
                string czas = box.Text;
                double godzina = double.Parse(czas.Substring(0, 2));
                double minuta = double.Parse(czas.Substring(3, 2));
                double newGodzina = ((IConverter)c1.SelectedItem).Convert(c2.Text, c3.Text, godzina);
                string result;
                if (godzina > 11 && godzina < 24)
                {
                    result = newGodzina.ToString() + czas.Substring(2, 3) + "PM";
                }
                else
                {
                    result = newGodzina.ToString() + czas.Substring(2, 3) + "AM";
                }
                if (!(Char.IsNumber(result[1]))){ result = "0" + result; }
                block.Text = result;

                ((Rectangle)r2).RenderTransform = new RotateTransform(newGodzina * 30);
                ((Rectangle)r1).RenderTransform = new RotateTransform(minuta*6);
            }
        }
    }
}
