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

namespace KonwerterJednostek.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            comboboxTempJednZ.ItemsSource = new List<string>()
            {
                "C",
                "F",
                "K"
            };

            comboboxTempJednDo.ItemsSource = new List<string>()
            {
                "C",
                "F",
                "K"
            };
        }

       







        

        private void przyciskKonwersjaTemp_Click(object sender, RoutedEventArgs e)
        {
            KonwerterTemperatura konw = new KonwerterTemperatura();

            string wejscie = textBoxWartoscTemp.Text;
            double wejscieL = Convert.ToDouble(wejscie);
            //MessageBox.Show("Brawo!" + liczba);
            
            double wynikL = konw.Konwertuj(comboboxTempJednZ.Text, comboboxTempJednDo.Text, wejscieL); 
            textblockWynikTemp.Text = Convert.ToString(wynikL);
        }

        private void ComboBoxJednostkaDlugosc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboboxTempJednZ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void comboboxTempJednDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
