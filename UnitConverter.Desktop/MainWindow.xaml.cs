using Project1;
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

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<IConverter> converters = new List<IConverter>()
            {
                new TemperatureConverter(),
                new Project1.LengthConverter(),
                new WeightConverter(),
                new TimeConverter()
            };

        int choice = 1;
        string unitFrom;
        string unitTo;

        public MainWindow()
        {
            InitializeComponent();


            List<string> converterNames = new List<string>();

            for (int i = 0; i < converters.Count; i++)
            {
                converterNames.Add(converters[i].Name);
            }

            comboboxConverter.ItemsSource = converterNames;

        }

        private void comboboxConverter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (comboboxConverter.SelectedItem == "Temperatura")
            {
                List<string> units = new List<string>()
                {
                    "C",
                    "F"
                };
                comboboxUnitFrom.ItemsSource = units;
                choice = 1;
            }
            else if (comboboxConverter.SelectedItem == "Długość")
            {
                List<string> units = new List<string>()
                {
                    "km",
                    "mi"
                };
                comboboxUnitFrom.ItemsSource = units;
                choice = 2;
            }
            else if (comboboxConverter.SelectedItem == "Masa")
            {
                List<string> units = new List<string>()
                {
                    "kg",
                    "g",
                    "lb"
                };
                comboboxUnitFrom.ItemsSource = units;
                choice = 3;
            }
            else if (comboboxConverter.SelectedItem == "Czas")
            {
                List<string> units = new List<string>()
                {
                    "min",
                    "s"
                };
                comboboxUnitFrom.ItemsSource = units;
                choice = 4;
            }

        }


        private void comboboxUnitFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (comboboxUnitFrom.SelectedItem == "C")
            {
                unitFrom = "c";
                unitTo = "f";
            }
            else if (comboboxUnitFrom.SelectedItem == "F")
            {
                unitFrom = "f";
                unitTo = "c";
            }
            else if (comboboxUnitFrom.SelectedItem == "km")
            {
                unitFrom = "km";
                unitTo = "mi";
            }
            else if (comboboxUnitFrom.SelectedItem == "mi")
            {
                unitFrom = "mi";
                unitTo = "km";
            }
            else if (comboboxUnitFrom.SelectedItem == "kg")
            {
                unitFrom = "kg";
                unitTo = "lb";
            }
            else if (comboboxUnitFrom.SelectedItem == "g")
            {
                unitFrom = "kg";
                unitTo = "lb";
            }
            else if (comboboxUnitFrom.SelectedItem == "lb")
            {
                unitFrom = "lb";
                unitTo = "kg";
            }
            else if (comboboxUnitFrom.SelectedItem == "min")
            {
                unitFrom = "min";
                unitTo = "s";
            }
            else if (comboboxUnitFrom.SelectedItem == "s")
            {
                unitFrom = "s";
                unitTo = "min";
            }
            else
            {
                unitFrom = "c";
                unitTo = "f";
            }
        }

        private void inputTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal value = decimal.Parse(inputTextbox.Text);

            decimal result = converters[choice - 1].Convert(unitFrom, unitTo, value);

            resultTextblock.Text = result.ToString();
        }
    }
}
