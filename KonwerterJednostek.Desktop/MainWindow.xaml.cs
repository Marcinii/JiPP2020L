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
            comboboxWybor.ItemsSource = new List<string>()
            {
                "wyb 1",
                "wyb 2",
                "wyb 3"
            };
        }

        private void przyciskKonwersja_Click(object sender, RoutedEventArgs e)
        {
            string wejscie = textboxWejscie.Text;
            string wyjscie = "Witaj " + wejscie;
            textblockWynik.Text = wyjscie;
        }

        private void comboboxWybor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Wybrales: " + comboboxWybor.SelectedItem);
        }
    }
}
