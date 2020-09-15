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

namespace KonwerterJednostek.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string unitFrom, unitTo;
        private int x;
        public MainWindow()
        {
            InitializeComponent();

            comboBox.ItemsSource = new List<string>()
            {
                "C na F",
                "F na C",
                "kg na lb",
                "lb na kg",
                "km na mi",
                "mi na km",
                "km na m",
                "m na km"
            };
        }

        private void actionButton_Click(object sender, RoutedEventArgs e)
        {
            List<IConverter> converters = new List<IConverter>()
            {
                new TemperatureConverter(),
                new LengthConverter(),
                new WeightConverter()
            };
            if (decimal.TryParse(inputTextbox.Text, out decimal value))
            {
                outputTextblock.Text = converters[x].Convert(unitFrom, unitTo, value).ToString() + unitTo.ToUpperInvariant();
            } else
            {
                MessageBox.Show("Wprowadź poprawną wartość.", null, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedItem.Equals("C na F"))
            {
                unitFrom = "c";
                unitTo = "f";
                x = 0;

            } else if (comboBox.SelectedItem.Equals("F na C"))
            {
                unitFrom = "f";
                unitTo = "c";
                x = 0;
            }
            else if (comboBox.SelectedItem.Equals("kg na lb"))
            {
                unitFrom = "kg";
                unitTo = "lb";
                x = 2;
            }
            else if (comboBox.SelectedItem.Equals("lb na kg"))
            {
                unitFrom = "lb";
                unitTo = "kg";
                x = 2;
            }
            else if (comboBox.SelectedItem.Equals("km na mi"))
            {
                unitFrom = "km";
                unitTo = "mi";
                x = 1;
            }
            else if (comboBox.SelectedItem.Equals("mi na km"))
            {
                unitFrom = "mi";
                unitTo = "km";
                x = 1;
            }
            else if (comboBox.SelectedItem.Equals("km na m"))
            {
                unitFrom = "km";
                unitTo = "m";
                x = 1;
            }
            else if (comboBox.SelectedItem.Equals("m na km"))
            {
                unitFrom = "m";
                unitTo = "km";
                x = 1;
            }
        }
    }
}
