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

namespace ZAD2.WPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            RodzajKonwertera.ItemsSource = new List<IProgram>()
            {

                new Masa(),
                new Odleglosc(),
                new Temperatura(),
                new Objetosc()
            };
        }
        private void RodzajKonwertera_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            JednostkaZ.ItemsSource = ((IProgram)RodzajKonwertera.SelectedItem).j_;
            JednostkaDo.ItemsSource = ((IProgram)RodzajKonwertera.SelectedItem).j_;
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            string DaneText = DaneWpisz.Text;
            double DaneLiczba = double.Parse(DaneText);

            double wynikLiczba = ((IProgram)RodzajKonwertera.SelectedItem).Konwersja(
                JednostkaZ.SelectedItem.ToString(),
                JednostkaDo.SelectedItem.ToString(),
                DaneLiczba);
            WynikText.Text = wynikLiczba.ToString();

        }
    }
}
