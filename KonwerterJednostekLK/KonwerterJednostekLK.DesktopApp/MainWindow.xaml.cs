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

namespace KonwerterJednostekLK.DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            List<IConverter> converters = new List<IConverter>()
            {
                new TemperatureConverter(),
                new LenghtConverter(),
                new MassConverter(),
                new UnitConverter()

            };
            konwerteryComboBox.ItemsSource = new List<string>()
            {
             converters[0].getName, // temperatury
             converters[1].getName, // dlugosci
             converters[2].getName, // masy
             converters[3].getName, // jednostek
            };
            int index = konwerteryComboBox.SelectedIndex;
        }

        

    

        private void countButton_Click(object sender, RoutedEventArgs e){
            int converter = konwerteryComboBox.SelectedIndex;
            int from = fromComboBox.SelectedIndex;
            int to = ToComboBox.SelectedIndex;
           
            
            string inputValue = ValueTextBox.Text.ToString();
            float value = float.Parse(inputValue);

            if (converter == 0)
            {
                float result = new TemperatureConverter().Convert(from, to, value);
                Wynik.Text = result.ToString();
            }
            else if (converter == 1)
            {
                float result = new LenghtConverter().Convert(from, to, value);
                Wynik.Text = result.ToString();
            }
            else if (converter == 2)
            {
                float result = new MassConverter().Convert(from, to, value);
                Wynik.Text = result.ToString();
            }

            else if (converter == 3)
            {
                float result = new UnitConverter().Convert(from, to, value);
                Wynik.Text = result.ToString();
            }


        }

        private void konwerteryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int pointer = konwerteryComboBox.SelectedIndex;
            fromComboBox.Items.Clear();  /// czyszczenie bufora

            if (pointer == 0)
            {
                fromComboBox.Items.Add("Celcjusze");
                fromComboBox.Items.Add("Farenhajty");
            }

            else if (pointer == 1)
            {
                fromComboBox.Items.Add("Mile");
                fromComboBox.Items.Add("Kilometry");
                fromComboBox.Items.Add("Jardy");
            }
            else if (pointer == 2)
            {
                fromComboBox.Items.Add("Funty");
                fromComboBox.Items.Add("Kilogramy");
            }
            else if (pointer == 3)
            {
                fromComboBox.Items.Add("Metry");
                fromComboBox.Items.Add("Centymetry");
            }
            
        }

        private void fromComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int pointer = konwerteryComboBox.SelectedIndex;
            ToComboBox.Items.Clear();  /// czyszczenie bufora

            if (pointer == 0)
            {
                ToComboBox.Items.Add("Celcjusze");
                ToComboBox.Items.Add("Farenhajty");
            }

            else if (pointer == 1)
            {
                ToComboBox.Items.Add("Mile");
                ToComboBox.Items.Add("Kilometry");
                ToComboBox.Items.Add("Jardy");
            }
            else if (pointer == 2)
            {
                ToComboBox.Items.Add("Funty");
                ToComboBox.Items.Add("Kilogramy");
            }
            else if (pointer == 3)
            {
                ToComboBox.Items.Add("Metry");
                ToComboBox.Items.Add("Centymetry");
            }

        }

        private void ValueTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ToComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

    

