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
using UniConverter;

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
            List<Iconventer> calculator = new List<Iconventer>()
            {
               new temp(),
            new lenght(),
            new speed()

            };
            combobox.ItemsSource = new List<string>()
            {
             calculator[0].Name,
             calculator[1].Name,
             calculator[2].Name,

            };
            int index = combobox.SelectedIndex;

            comboboxSecond.ItemsSource = new List<string>()
            {
             calculator[0].Units[0],
             calculator[0].Units[1],
             calculator[1].Units[0],
             calculator[1].Units[1],
             calculator[2].Units[0],
             calculator[2].Units[1],
             calculator[2].Units[2],
           


            };

            comboboxThird.ItemsSource = new List<string>()
            {
             calculator[0].Units[0],
             calculator[0].Units[1],
             calculator[1].Units[0],
             calculator[1].Units[1],
             calculator[2].Units[0],
             calculator[2].Units[1],
             calculator[2].Units[2],


            };

        }
        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            
            int index1 = combobox.SelectedIndex;
            int index2 = comboboxSecond.SelectedIndex;
            int index3 = comboboxThird.SelectedIndex;
            int first = 0;
            int second = 0;
            if (index2 == 0)
            {
                 first = 0;
            }
            else if (index2 == 1)
            {
                 first = 1;
            }
            else if (index2 == 2)
            {
                 first = 0;
            }
            else if (index2 == 3)
            {
                 first = 1;
            }
            else if (index2 == 4)
            {
                 first = 0;
            }
            else if (index2 == 5)
            {
                 first = 1;
            }
            else if (index2 == 6)
            {
                 first = 2;
            }

            if (index3 == 0)
            {
                 second = 0;
            }
            else if (index3 == 1)
            {
                 second = 1;
            }
            else if (index3 == 2)
            {
                 second = 0;
            }
            else if (index3 == 3)
            {
                 second = 1;
            }
            else if (index3 == 4)
            {

                 second = 0;
            }
            else if (index3 == 5)
            {
                 second = 1;
            }
            else if (index3 == 6)
            {
                 second = 2;
            }
            string inputValue = inputTextBox.Text.ToString();
            decimal Value = decimal.Parse(inputValue);
           if(index1 == 0)
            {
                decimal result = new temp().converterCalculator(first, second, Value);
                resultTextBlock.Text = result.ToString();
            }
            if (index1 == 1)
            {
                decimal result = new lenght().converterCalculator(first, second, Value);
                resultTextBlock.Text = result.ToString();
            }
            if (index1 == 2)
            {
                decimal result = new speed().converterCalculator(first, second, Value);
                resultTextBlock.Text = result.ToString();
            }
           

        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = combobox.SelectedIndex;


        }
    }
}