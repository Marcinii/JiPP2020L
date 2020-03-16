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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            combobox.ItemsSource = new List<string>()
            {
                "km -> mi",
                "mi -> km"
            };
            combobox0.ItemsSource = new List<string>()
            {
                "kJ -> kWh",
                "kWh -> kJ"
            };
            combobox1.ItemsSource = new List<string>()
            {
                "C -> F",
                "F -> C",
                "C -> K",
                "K -> C",
                "F -> K",
                "K -> F"
            };
            combobox2.ItemsSource = new List<string>()
            {
                "kg -> lb",
                "lb -> kg"
            };
        }

        private void actionButton_Click(object sender, RoutedEventArgs e)
        {
            //Temp conv = new Temp();
            //string input = inputTextbox.Text;
            //string output = "witaj " + input;
            //outputTextblock.Text = output;
            System.Windows.Application.Current.Shutdown();
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Length conv = new Length();
            string output = "";
            double number;
            if (inputTextbox.Text == "") { number = 0; }
            else { number = Convert.ToDouble(inputTextbox.Text); }
            if (combobox.Text == "km -> mi") { output = conv.UnitConv(0, number); }
            else if (combobox.Text == "mi -> km") { output = conv.UnitConv(1, number); }
            else { output = conv.UnitConv(-1, number); }
            outputTextblock.Text = output;
        }
        private void Submit0_Click(object sender, RoutedEventArgs e)
        {
            Energy conv = new Energy();
            string output = "";
            double number;
            if (inputTextbox0.Text == "") { number = 0; }
            else { number = Convert.ToDouble(inputTextbox0.Text); }
            if (combobox0.Text == "kJ -> kWh") { output = conv.UnitConv(0, number); }
            else if (combobox0.Text == "kWh -> kJ") { output = conv.UnitConv(1, number); }
            else { output = conv.UnitConv(-1, number); }
            outputTextblock0.Text = output;
        }

        private void Submit1_Click(object sender, RoutedEventArgs e)
        {
            Temp conv = new Temp();
            string output = "";
            double number;
            if (inputTextbox1.Text == "") { number = 0; }
            else { number = Convert.ToDouble(inputTextbox1.Text); }
            if (combobox1.Text == "C -> F") { output = conv.UnitConv(0, number); }
            else if (combobox1.Text == "F -> C") { output = conv.UnitConv(1, number); }
            else if (combobox1.Text == "C -> K") { output = conv.UnitConv(2, number); }
            else if (combobox1.Text == "K -> C") { output = conv.UnitConv(3, number); }
            else if (combobox1.Text == "F -> K") { output = conv.UnitConv(4, number); }
            else if (combobox1.Text == "K -> F") { output = conv.UnitConv(5, number); }
            else { output = conv.UnitConv(-1, number); }
            outputTextblock1.Text = output;
        }

        private void Submit2_Click(object sender, RoutedEventArgs e)
        {
            Weight conv = new Weight();
            string output = "";
            double number;
            if (inputTextbox2.Text == "") { number = 0; }
            else { number = Convert.ToDouble(inputTextbox2.Text); }
            if (combobox2.Text == "kg -> lb") { output = conv.UnitConv(0, number); }
            else if (combobox2.Text == "lb -> kg") { output = conv.UnitConv(1, number); }
            else { output = conv.UnitConv(-1, number); }
            outputTextblock2.Text = output;
        }
    }
}
