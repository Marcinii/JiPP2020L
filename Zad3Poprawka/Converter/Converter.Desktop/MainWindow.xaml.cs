using Converter.Logic;
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

namespace Converter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            converterComboBox.ItemsSource = new List<IConverter>()
            {
                new LenghtConverter(),
                new TemperatureConverter(),
                new QuantityConverter(),
                new WeightConverter(),
            
        };
            List<string> time = new List<string>()
            {
                "24h na 12h",
                "12h na 24h"
            };
            timeComboBox.ItemsSource = time;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFromComboBox.ItemsSource = ((IConverter)converterComboBox.SelectedItem).Units;
            unitToComboBox.ItemsSource = ((IConverter)converterComboBox.SelectedItem).Units;
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = inputTextBox.Text;
            decimal inputValue = decimal.Parse(inputText);

            decimal result = ((IConverter)converterComboBox.SelectedItem).Convert(
                unitFromComboBox.SelectedItem.ToString(),
                unitToComboBox.SelectedItem.ToString(),
                inputValue);

            outputTextBlock.Text = result.ToString();
        }

       

        private void timeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string input = hourTextBox.Text;
            decimal x = decimal.Parse(input);
            decimal result=1;
            string type="";
            if (timeComboBox.SelectedItem.ToString() == "12h na 24h")
            {
                result = new TimeConverter().Convert("Am", "Pm", x);
                type = " Pm";
                
            }
            else if(timeComboBox.SelectedItem.ToString() == "24h na 12h")
            {
                result = new TimeConverter().Convert("Pm", "Am", x);
                type = " Am";
            }
            timeOutput.Text = result + ":" + minuteTextBox.Text + type;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["rotatingClock"]).Begin();
        }
    }
}
