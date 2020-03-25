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
            ComboBoxJednostkaDlugosc.ItemsSource = new List<string>()
            {
                "km",
                "m"
            };
        }

        private void ComboBoxJednostkaDlugosc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            MessageBox.Show("Wybrales: " + ComboBoxJednostkaDlugosc.SelectedItem);
        }







        private void przyciskKonwersja_Click(object sender, RoutedEventArgs e)
        {
            string wejscie = textboxWejscie_Dlugosc.Text;
            string wyjscie = "Witaj " + wejscie;
            textblockWynik_Dlugosc.Text = wyjscie;
        }

    
    }
}
