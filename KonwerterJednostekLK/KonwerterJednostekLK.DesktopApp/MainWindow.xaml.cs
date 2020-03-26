using KonwerterJednostekLK.Logic;
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
            List<IConverter> converters = new ConverterService().GetConverters();
            konwerteryComboBox.ItemsSource = new List<string>()
            { 
             converters[0].getName, // temperatury
             converters[1].getName, // dlugosci
             converters[2].getName, // masy
             converters[3].getName, // jednostek        
            };


            List<string> time = new List<string>()
            {
                "system 24h na 12h",
            };
            timeComboBox.ItemsSource = time;
        }


        private void timeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string input = hourTextBox.Text;
            float x = float.Parse(input);
            if (timeComboBox.SelectedItem.ToString() == "system 24h na 12h"){ 
                    float result = new TimeConverter().Convert(0, 1, x);
                    string type;
                    if (x > 12)
                        type = "PM";
                    else
                        type = "AM";
                    timeResultBlock.Text = result.ToString() + ":" + minuteTextBox.Text + type;
             }
        }

      


        private void countButton_Click(object sender, RoutedEventArgs e)
{
            int converter = konwerteryComboBox.SelectedIndex;
            int from = fromComboBox.SelectedIndex;
            int to = toComboBox.SelectedIndex;
           
            
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

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["KolorowyZegar"]).Stop();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["KolorowyZegar"]).Begin();
        }

        private void fromComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int pointer = konwerteryComboBox.SelectedIndex;
            toComboBox.Items.Clear();  /// czyszczenie bufora

            if (pointer == 0)
            {
                toComboBox.Items.Add("Celcjusze");
                toComboBox.Items.Add("Farenhajty");
            }

            else if (pointer == 1)
            {
                toComboBox.Items.Add("Mile");
                toComboBox.Items.Add("Kilometry");
                toComboBox.Items.Add("Jardy");
            }
            else if (pointer == 2)
            {
                toComboBox.Items.Add("Funty");
                toComboBox.Items.Add("Kilogramy");
            }
            else if (pointer == 3)
            {
                toComboBox.Items.Add("Metry");
                toComboBox.Items.Add("Centymetry");
            }
          
        }

       

        private void ValueTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ToComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
    }
}

    

