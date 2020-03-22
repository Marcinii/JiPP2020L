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

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            KonwerterComboBox.ItemsSource = new List<IKonwerter>()
            {
                new Temperatura(),
                new Odleglosc(),
                new Masa(),
                new Energia()
            };
        }

        private void KonwerterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ZComboBox.ItemsSource = ((IKonwerter)KonwerterComboBox.SelectedItem).Unit;
            DoComboBox.ItemsSource = ((IKonwerter)KonwerterComboBox.SelectedItem).Unit;
        }

        private void actionButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = WartoscTextBox.Text;
            double wartosc = double.Parse(inputText);

            double wynik = ((IKonwerter)KonwerterComboBox.SelectedItem).Konwert(
                ZComboBox.SelectedItem.ToString(),
                DoComboBox.SelectedItem.ToString(),
                wartosc);
            WynikTextBlock.Text = wynik.ToString();
        }
    }
}
