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
using UnitConverter;

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
            List<IConverter> converters = new List<IConverter>()
            {
                new TemperatureConverter(),
                new LenghtConverter(),
                new WeightConverter(),
                new SpeedConverter()

            };
            firstList.ItemsSource = new List<string>()
            {
             converters[0].Name,
             converters[1].Name,
             converters[2].Name,
             converters[3].Name,


            };
            int index = firstList.SelectedIndex;

        }
        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            int firstListindex = firstList.SelectedIndex;
            int secondListindex = secondList.SelectedIndex;
            int thirdListindex = thirdList.SelectedIndex;
            string inputValue = inputTextBox.Text.ToString();


            decimal Value = decimal.Parse(inputValue);
            if (firstListindex == 0)
            {
                decimal result = new TemperatureConverter().Convert(secondListindex, thirdListindex, Value);
                resultTextBlock.Text = result.ToString();
            }
            else if (firstListindex == 1)
            {
                decimal result = new LenghtConverter().Convert(secondListindex, thirdListindex, Value);
                resultTextBlock.Text = result.ToString();
            }
            else if (firstListindex == 2)
            {
                decimal result = new WeightConverter().Convert(secondListindex, thirdListindex, Value);
                resultTextBlock.Text = result.ToString();
            }

            else if (firstListindex == 3)
            {
                decimal result = new SpeedConverter().Convert(secondListindex, thirdListindex, Value);
                resultTextBlock.Text = result.ToString();
            }


        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            secondList.Items.Clear();
            inputTextBox.Text = "";
            resultTextBlock.Text = "";
            int index1 = firstList.SelectedIndex;

            if (index1 == 0)
            {
                secondList.Items.Add("Kelvin");
                secondList.Items.Add("Celsjusz");
                secondList.Items.Add("Farenhait");
            }

            else if (index1 == 1)
            {
                secondList.Items.Add("Kilometry");
                secondList.Items.Add("Mile");

            }
            else if (index1 == 2)
            {
                secondList.Items.Add("Kilogramy");
                secondList.Items.Add("Funty");

            }
            else if (index1 == 3)
            {
                secondList.Items.Add("KM/H");
                secondList.Items.Add("MPH");

            }

        }

        private void comboboxSecond_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            thirdList.Items.Clear();
            int index2 = firstList.SelectedIndex;


            if (index2 == 0)
            {
                thirdList.Items.Add("Kelvin");
                thirdList.Items.Add("Celsjusz");
                thirdList.Items.Add("Farenhait");
            }

            else if (index2 == 1)
            {
                thirdList.Items.Add("Kilometry");
                thirdList.Items.Add("Mile");

            }
            else if (index2 == 2)
            {
                thirdList.Items.Add("Kilogramy");
                thirdList.Items.Add("Funty");

            }
            else if (index2 == 3)
            {
                thirdList.Items.Add("KM/H");
                thirdList.Items.Add("MPH");

            }
        }

        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
