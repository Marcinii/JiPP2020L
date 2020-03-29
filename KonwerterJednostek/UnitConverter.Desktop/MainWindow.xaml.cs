using KonwerterJednostek;
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
using UnitConverter.Logic;

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
            converterCombobox.ItemsSource = new ConverterService().GetConverters();
        }

        private void ConverterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string timeConverterName = new TimeConverter().Name;
            string selectedItemName = ((IConverter)converterCombobox.SelectedItem).Name.ToString();
            if (selectedItemName.Equals(timeConverterName))
            {
                ((Storyboard)Resources["clockVisibility"]).Begin();
            }
            else
            {
                ((Storyboard)Resources["clockVisibility"]).AutoReverse = true;
                ((Storyboard)Resources["clockVisibility"]).Begin(this, true);
                ((Storyboard)Resources["clockVisibility"]).Seek(this, new TimeSpan(0, 0, 0), TimeSeekOrigin.Duration);
            }

            fromCombobox.ItemsSource =
                ((IConverter)converterCombobox.SelectedItem).Units;
            toCombobox.ItemsSource =
                ((IConverter)converterCombobox.SelectedItem).Units;
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = inputTextbox.Text;
            double inputValue;
            Double.TryParse(inputText, out inputValue);

            double result = ((IConverter)converterCombobox.SelectedItem).Convert(
                ((IConverter)converterCombobox.SelectedItem).Units
                .IndexOf((string)fromCombobox.SelectedItem),
                ((IConverter)converterCombobox.SelectedItem).Units
                .IndexOf((string)toCombobox.SelectedItem),
                inputValue);

            resultTextblock.Text = result.ToString();

            double hourArrowValue = result > 12 ? result - 12 : result;
            double minuteArrowValue = (hourArrowValue - (int)hourArrowValue) * 100;

            hourRotation.Angle = ((hourArrowValue / 12) * 360) + 90;
            minuteRotation.Angle = ((minuteArrowValue / 60) * 360) + 90;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["circleStoryboard"]).Begin();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["circleStoryboard"]).Stop();
        }
    }
}
