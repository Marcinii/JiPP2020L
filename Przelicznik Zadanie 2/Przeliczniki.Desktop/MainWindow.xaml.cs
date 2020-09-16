using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Przelicznik.Logic;
using System.Collections.Generic;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace Przeliczniki.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        PrzelicznikI obecnyPrzelicznik;
        bool czyPrzelicznikCzasu = false;
        string jednostkaZ, jednostkaDo;

        List<PrzelicznikI> Przeliczniki = new List<PrzelicznikI>
        {
            new Czasu(),
            new Długości(),
            new Prędkość(),
            new Temperatury(),
            new Masa(),
        };

        public MainWindow()
        {
            InitializeComponent();
            WyborKonwerterComboBox.ItemsSource = Przeliczniki;
            
        }

        private void WyborKonwerterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((PrzelicznikI)WyborKonwerterComboBox.SelectedItem).Name == "Przelicznik czasu")
            {
                czyPrzelicznikCzasu = true;
                ZegarUklad.Visibility = Visibility.Visible;
                var animacja = (Storyboard)FindResource("ZegarPokaz");
                animacja.Begin();
            }
            else
            {
                czyPrzelicznikCzasu = false;
                ZegarUklad.Visibility = Visibility.Hidden;
            }

            obecnyPrzelicznik = (PrzelicznikI)WyborKonwerterComboBox.SelectedItem;

            WyborJednostkaWejscComboBox.ItemsSource = obecnyPrzelicznik.jednostka;
            WyborJednostkaWyjscComboBox.ItemsSource = obecnyPrzelicznik.jednostka;
        }

        private void WyborJednostkaWyjscComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WyborJednostkaWyjscComboBox.SelectedItem != null)
            {
                jednostkaDo = WyborJednostkaWyjscComboBox.SelectedItem.ToString();
            }
        }

        private void ObliczPrzycisk_Click(object sender, RoutedEventArgs e)
        {
            if (czyPrzelicznikCzasu && PoleWejsciowe.Text != "")
            {
                PoleWyjsciowe.Text = obecnyPrzelicznik.przeliczCzas(PoleWejsciowe.Text);
                var wartosc = "";
                if (PoleWejsciowe.Text.Split(' ').Length == 2)
                {
                    wartosc = PoleWejsciowe.Text.Split(' ')[0];
                }
                else
                {
                    wartosc = PoleWejsciowe.Text;
                }

                RotateTransform obrot = new RotateTransform(int.Parse(wartosc) * 30);
                WskazowkaSciezka.RenderTransform = obrot;
            }
            else
            {
                if (jednostkaZ != "" && jednostkaDo != "" && PoleWejsciowe.Text != "")
                {
                    var wyjscie = obecnyPrzelicznik.przelicz(jednostkaZ, jednostkaDo, Double.Parse(PoleWejsciowe.Text));
                    PoleWyjsciowe.Text = wyjscie.ToString() + " " + jednostkaDo;
                }
            }
        }

        private void WyborJednostkaWejscComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WyborJednostkaWejscComboBox.SelectedItem != null)
            {
                jednostkaZ = WyborJednostkaWejscComboBox.SelectedItem.ToString();
            }
        }
    }
}
