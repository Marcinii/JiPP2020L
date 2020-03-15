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
using konwerter.logic;

namespace konwerter.deskop
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
        }

        public List<string> converters => new List<string>()
        {
            "Temperatura",
            "Długosci",
            "Masa",
            "Dane",
        };



        

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

          


            //MessageBox.Show("Użytkownik wybrał: " + combobox.SelectedItem);


        }

        private void buttonPrzelicz_Click(object sender, RoutedEventArgs e)
        {
            
            

            string unitFrom = InputText.Text;
            string unitTo = InputText2.Text;
            string inputValue = InputText3.Text;


             decimal value = decimal.Parse(inputValue);

            // decimal result = nowy.Convert(unitFrom, unitTo, value);

            //OutputText.Text = combobox.ItemsSource.ToString();

            string input = combobox.Text;

            switch(input)
            {
                case "Temperatura":
                    decimal result1 = new temp_converter().Convert(unitFrom, unitTo, value);
                    OutputText.Text = result1.ToString();
                    break;
                case "Długosci":
                    decimal result2 = new length_conventer().Convert(unitFrom, unitTo, value);
                    OutputText.Text = result2.ToString();
                    break;
                case "Masa":
                    decimal result3 = new weight_conventer().Convert(unitFrom, unitTo, value);
                    OutputText.Text = result3.ToString();
                    break;
                case "Dane":
                    decimal result4 = new data_conventer().Convert(unitFrom, unitTo, value);
                    OutputText.Text = result4.ToString();
                    break;

            }

            
            
            


        }

       
    }
}
