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

namespace Konwerter.Okienko
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Lista.ItemsSource = new KonwerterSerwis().NazwyK();
        }

        private void Oblicz_Click(object sender, RoutedEventArgs e)
        {
            string a = Wartosc.Text;
            if (Lista.Text != "Konwerter.Logika.Zegar_24na12")
            {
                double b = double.Parse(a);
                double wynikowa = ((Ikonwenter)Lista.SelectedItem).Konwer("a", "b", b);
                Wynik.Text = wynikowa.ToString();

            }
            else
            {
                double b = double.Parse(a.Substring(0, 2));
                double wynikowa = ((Ikonwenter)Lista.SelectedItem).Konwer("a", "b", b);
                string znak;
                if(b>11 && b < 24) { znak = "PM"; }
                else { znak = "AM"; }
                string poczatek = "";
                if(wynikowa < 10) { poczatek = "0"; }
                Wynik.Text = poczatek + wynikowa.ToString() + a.Substring(2, 3) + " " + znak;

                double katGodz = wynikowa * 30;
                double katMin = double.Parse(a.Substring(3, 2)) * 6;

                godzina.RenderTransform = new RotateTransform(katGodz);
                minuta.RenderTransform = new RotateTransform(katMin);
            }

        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
