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
using unitconverter.logic;

namespace unitconverter.desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<string> unit_list = new List<string>() { };
        List<Iconverter> converters = new List<Iconverter>()
        {
                new c_lenght(),
                new c_temperature(),
                new c_weight(),
                new c_capacity()
        };
        int choosen_converter;
        public MainWindow()
        {
            InitializeComponent();

            unit_from.ItemsSource = unit_list;
            unit_to.ItemsSource = unit_list;
        }

        private List<string> choose_units()
        {
            List<string> list = new List<string>() { };
            return list;
        }

        private void create_objects(int choosen_c)
        {
            unit_from.ItemsSource = unit_list;
            unit_to.ItemsSource = unit_list;
            unit_from.SelectedIndex = 0;
            unit_to.SelectedIndex = 0;
            choosen_converter = choosen_c;
        }

        private void lenght_checked(object sender, RoutedEventArgs e)
        {
            unit_list = new c_lenght().units_names;
            create_objects(0);
        }
        private void temperature_checked(object sender, RoutedEventArgs e)
        {
            unit_list = new c_temperature().units_names;
            create_objects(1);
        }
        private void weight_checked(object sender, RoutedEventArgs e)
        {
            unit_list = new c_weight().units_names;
            create_objects(2);
        }
        private void capacity_checked(object sender, RoutedEventArgs e)
        {
            unit_list = new c_capacity().units_names;
            create_objects(3);
        }

        private void count(object sender, RoutedEventArgs e)
        {
            string from = unit_from.SelectedItem.ToString();
            string to = unit_to.SelectedItem.ToString();
            string value_to_convert = value.Text;
            decimal converted_value = parse.convert_string_to_decimal(value_to_convert);
            if (converted_value == 0)
            {
                MessageBox.Show("Podaj prawidłową wartość!");
            }
            decimal conversion_result = converters[choosen_converter].operation(from, to, converted_value);
            result.Inlines.Add(new Run(conversion_result+" "));
        }
    }
}
