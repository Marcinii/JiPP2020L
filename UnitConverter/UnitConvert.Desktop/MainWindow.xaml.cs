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

namespace UnitConvert.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new TemperatureConverter().Convert("C", "K", value);

            outputTextBlock.Text = result.ToString();
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox1.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new TemperatureConverter().Convert("C", "F", value);

            outputTextBlock1.Text = result.ToString();
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox2.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new TemperatureConverter().Convert("F", "C", value);

            outputTextBlock2.Text = result.ToString();
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox3.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new TemperatureConverter().Convert("F", "K", value);

            outputTextBlock3.Text = result.ToString();
        }
        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox4.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new TemperatureConverter().Convert("K", "C", value);

            outputTextBlock4.Text = result.ToString();
        }
        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox5.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new TemperatureConverter().Convert("K", "F", value);

            outputTextBlock5.Text = result.ToString();
        }
        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox6.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new KonwerterIlosci().Convert("tuzin", "mendel", value);

            outputTextBlock6.Text = result.ToString();
        }
        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox7.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new KonwerterIlosci().Convert("tuzin", "kopa", value);

            outputTextBlock7.Text = result.ToString();
        }
        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox8.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new KonwerterIlosci().Convert("mendel", "kopa", value);

            outputTextBlock8.Text = result.ToString();
        }
        private void Button_Click9(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox9.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new KonwerterIlosci().Convert("mendel", "tuzin", value);

            outputTextBlock9.Text = result.ToString();
        }
        private void Button_Click10(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox10.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new KonwerterIlosci().Convert("kopa", "tuzin", value);

            outputTextBlock10.Text = result.ToString();
        }
        private void Button_Click11(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox11.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new KonwerterIlosci().Convert("kopa", "mendel", value);

            outputTextBlock11.Text = result.ToString();
        }
        private void Button_Click12(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox12.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new WeightConverter().Convert("kg", "g", value);

            outputTextBlock12.Text = result.ToString();
        }
        private void Button_Click13(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox13.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new WeightConverter().Convert("kg", "f", value);

            outputTextBlock13.Text = result.ToString();
        }
        private void Button_Click14(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox14.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new WeightConverter().Convert("g", "kg", value);

            outputTextBlock14.Text = result.ToString();
        }
        private void Button_Click15(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox15.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new WeightConverter().Convert("g", "f", value);

            outputTextBlock15.Text = result.ToString();
        }
        private void Button_Click16(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox16.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new WeightConverter().Convert("f", "g", value);

            outputTextBlock16.Text = result.ToString();
        }
        private void Button_Click17(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox17.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new WeightConverter().Convert("f", "kg", value);

            outputTextBlock17.Text = result.ToString();
        }
        private void Button_Click18(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox18.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new UnitConverter.LengthConverter().Convert("m", "km", value);

            outputTextBlock18.Text = result.ToString();
        }
        private void Button_Click19(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox19.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new UnitConverter.LengthConverter().Convert("m", "mil", value);

            outputTextBlock19.Text = result.ToString();
        }
        private void Button_Click20(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox20.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new UnitConverter.LengthConverter().Convert("mil", "km", value);

            outputTextBlock20.Text = result.ToString();
        }
        private void Button_Click21(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox21.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new UnitConverter.LengthConverter().Convert("mil", "m", value);

            outputTextBlock21.Text = result.ToString();
        }
        private void Button_Click22(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox22.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new UnitConverter.LengthConverter().Convert("km", "m", value);

            outputTextBlock22.Text = result.ToString();
        }
        private void Button_Click23(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox23.Text;

            double value = double.Parse(inputValue); // TryParse!

            double result = new UnitConverter.LengthConverter().Convert("km", "mil", value);

            outputTextBlock23.Text = result.ToString();
        }
    }
}
