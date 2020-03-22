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

            var result = new KonwerterCelcjusza().Convert("Celcjusza", "Fahrenheita", inputValue);

            outputTextBlock.Text = result.ToString();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox1.Text;

            var result = new KonwerterFahrenheita().Convert("Fahrenheita", "Celcjusza", inputValue);

            outputTextBlock1.Text = result.ToString();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox2.Text;

            var result = new KonwerterKilkometrow().Convert("Kilomertrów", "Mile", inputValue);

            outputTextBlock2.Text = result.ToString();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox3.Text;

            var result = new KonwerterMil().Convert("Mil", "Kilometrów", inputValue);

            outputTextBlock3.Text = result.ToString();
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox4.Text;

            var result = new KonwerterKilogramow().Convert("Kilogramów", "Funty", inputValue);

            outputTextBlock4.Text = result.ToString();
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox5.Text;

            var result = new KonwerterFuntow().Convert("Funtów", "Kilogramy", inputValue);

            outputTextBlock5.Text = result.ToString();

        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox6.Text;

            var result = new KonwerterCali().Convert("Cali", "Centymetrów", inputValue);

            outputTextBlock6.Text = result.ToString();
        }
        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTextBox7.Text;
            var result = new KonwerterCzasu().Convert("24H", "12H", inputValue);

            outputTextBlock7.Text = result.ToString();
        }
    }
}
