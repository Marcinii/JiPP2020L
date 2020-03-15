using Konwerter_jednostek_wersja2;
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

namespace Konwerterjednostek.Pulpit
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

            double value = double.Parse(inputValue); 

            double result = new KonwerterCelcjusza().Convert("Celcjusz", "Kelwin", value);

            outputTextBlock.Text = result.ToString();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox1.Text;

            double value = double.Parse(inputValue);

            double result = new KonwerterFahrenheita().Convert("Celcjusz", "Kelwin", value);

            outputTextBlock1.Text = result.ToString();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox2.Text;

            double value = double.Parse(inputValue);

            double result = new KonwerterKilkometrow().Convert("Celcjusz", "Kelwin", value);

            outputTextBlock2.Text = result.ToString();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox3.Text;

            double value = double.Parse(inputValue);

            double result = new KonwerterMil().Convert("Celcjusz", "Kelwin", value);

            outputTextBlock3.Text = result.ToString();
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox4.Text;

            double value = double.Parse(inputValue);

            double result = new KonwerterKilogramow().Convert("Celcjusz", "Kelwin", value);

            outputTextBlock4.Text = result.ToString();
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox5.Text;

            double value = double.Parse(inputValue);

            double result = new KonwerterFuntow().Convert("Celcjusz", "Kelwin", value);

            outputTextBlock5.Text = result.ToString();

        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox6.Text;

            double value = double.Parse(inputValue);

            double result = new KonwerterCali().Convert("Celcjusz", "Kelwin", value);

            outputTextBlock6.Text = result.ToString();
        }
    }
}
