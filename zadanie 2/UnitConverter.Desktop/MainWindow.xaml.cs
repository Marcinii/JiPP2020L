using System;
using System.Collections.Generic;
using System.Globalization;
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
using unitConverterv2;
using UnitConverterv2.Logic;

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

            firstList.ItemsSource = new ConverterService().getConverters();
            int index = firstList.SelectedIndex;
            /*clockMarker.Angle = 50;
*/
        }
        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = inputTextBox.Text;
            inputText = inputText.ToString().Replace(':', '.');
            decimal inputValue = decimal.Parse(inputText, CultureInfo.InvariantCulture);

            decimal result = decimal.Round(((IConvert)firstList.SelectedItem).Convert(secondList.SelectedIndex, thirdList.SelectedIndex, inputValue), 6);
            string resultToString;

            if (((IConvert)firstList.SelectedItem).Name == "Clock Converter")
            {
                resultToString = result.ToString().Replace(',', ':');
            }
            else
            {
                resultToString = result.ToString();
            }

            resultTextBlock.Text = resultToString;

            if (resultTextBlock.Text != "")
            {
                resultTextBlock.Background = Brushes.BlanchedAlmond;
            }

            if (((IConvert)firstList.SelectedItem).Name == "Clock Converter")
            {
             
                if (result - (int)result > (decimal)0.60)
                {
                    MessageBox.Show("Podane minuty większe od 60");
                    throw new System.ArgumentException("Wartość nie może być większa od 24 i od 0 ");
                }
                secondDot.Angle = (double)result * 30;
                clockMarker.Angle = (double)Math.Floor(result) * 30;
              
                if (inputValue > 24 || inputValue < 0)
                {
                    MessageBox.Show("Wartość nie może być większa od 24 i mniejsza od 0");
                    throw new System.ArgumentException("Wartość nie może być większa od 24 i od 0 ");
                }
                if (inputValue < 13) resultTextBlock.Text += " AM";
                else resultTextBlock.Text += " PM";
            }
            else
            {
                resultTextBlock.Text += " " + thirdList.SelectedItem.ToString();
            }

            inputTextBox.Text = "";

        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            secondList.ItemsSource = ((IConvert)firstList.SelectedItem).Units;
            thirdList.ItemsSource = ((IConvert)firstList.SelectedItem).Units;


            if (((IConvert)firstList.SelectedItem).Name == "Clock Converter")
            {
                secondList.SelectedIndex = 1;
                thirdList.SelectedIndex = 0;
                

            }
           

        }

        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string inputText = inputTextBox.Text;
            decimal inputValue;
            bool success = decimal.TryParse(inputText, out inputValue);
            if (success)
            {

                if (((IConvert)firstList.SelectedItem).Name == "Clock Converter")
                {
                    if (inputValue > 24 || inputValue < 0)
                    {
                        inputTextBox.Background = Brushes.Red;
                    }
                    else
                    {
                        inputTextBox.Background = Brushes.Green;
                    }
                }
            }
            else
            {
                inputTextBox.Background = Brushes.White;
            }
        }
    }
}


