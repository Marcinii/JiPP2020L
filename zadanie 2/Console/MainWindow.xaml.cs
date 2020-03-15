using przelicznik;
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

namespace Console
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            combobox.ItemsSource = converters;
            string input = combobox.Text;
            double liczba = Double.Parse(liczba_poczatkowa.Text);
            switch (input)
            {
                case "1 - Ze stopni Celsjusza na stopnie Farenheita":
                    TemperatureConverter conv1 = new TemperatureConverter();
                    double second = 1;
                    wynik.Text = ($"Twój wynik: {conv1.Convert(second, liczba, 0)} ");

                    break;


            }
        }

        public List<string> converters => new List<string>()
        {


            "1- Ze stopni Celsjusza na stopnie Farenheita", 
            "2- Ze stopni Farenheita na stopnie Celsjusza", 
            "3- Ze stopni Celsjusza na stopnie Kelwina",
            "4- kilogramy na funty",
            "5- funty na kilogramy", 
            "6- kilogramy na tony",
            "7- Z kilometrów na mile", 
            "8- Z mili na kilometry", 
            "9- Z kilometrów na metry",
            "10- sekundy na minuty",
            "11- minuty na godziny",
            "12-godziny na dni"

           
        };
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}