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
using unitConverterv2;

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
            List<IConvert> converters = new List<IConvert>()
            {
                new tempConverter(),
                new lengthCon(),
                new weightConverter(),
                new SurfaceConvert()

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
            if(firstListindex == 0)
            {
                decimal result = new tempConverter().Convert(secondListindex, thirdListindex, Value);
                resultTextBlock.Text = result.ToString();
            }
            else if(firstListindex == 1)
            {
                decimal result = new lengthCon().Convert(secondListindex, thirdListindex, Value);
                resultTextBlock.Text = result.ToString();
            }
            else if(firstListindex == 2)
            {
                decimal result = new weightConverter().Convert(secondListindex, thirdListindex, Value);
                resultTextBlock.Text = result.ToString();
            }

            else if(firstListindex == 3)
            {
                decimal result = new SurfaceConvert().Convert(secondListindex, thirdListindex, Value);
                resultTextBlock.Text = result.ToString();
            }
           

        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            secondList.Items.Clear();
            inputTextBox.Text = "";
            resultTextBlock.Text = "";
            int index1 = firstList.SelectedIndex;
           
            if(index1 == 0)
            {
                secondList.Items.Add("Celvin");
                secondList.Items.Add("Celcius");
                secondList.Items.Add("Faranhait");
            }

            else if(index1 == 1)
            {
                secondList.Items.Add("Kilometers");
                secondList.Items.Add("Miles");
                
            }
            else if (index1 == 2)
            {
                secondList.Items.Add("Kilograms");
                secondList.Items.Add("Funty");
              
            }
            else if (index1 == 3)
            {
                secondList.Items.Add("acres");
                secondList.Items.Add("square meters");
                
            }

        }

        private void comboboxSecond_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            thirdList.Items.Clear();
            int index2 = firstList.SelectedIndex;
           
            
            if (index2 == 0)
            {
                thirdList.Items.Add("Celvin");
                thirdList.Items.Add("Celcius");
                thirdList.Items.Add("Faranhait");
            }

            else if (index2 == 1)
            {
                thirdList.Items.Add("Kilometers");
                thirdList.Items.Add("Miles");

            }
            else if (index2 == 2)
            {
                thirdList.Items.Add("Kilograms");
                thirdList.Items.Add("Funty");

            }
            else if (index2 == 3)
            {
                thirdList.Items.Add("acres");
                thirdList.Items.Add("square meters");

            }
        }
    }
}


