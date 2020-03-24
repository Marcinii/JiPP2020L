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
using Konwerter_jedn;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            combobox_konwertery.ItemsSource = new List<IKonwerter_jedn>()
            {
                new cisnienia(),
                new masy(),
                new odleglosci(),
                new temperatury()
            };
        }

        private void Combobox_konwertery_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            combobox_jednostki_z.ItemsSource = ((IKonwerter_jedn)combobox_konwertery.SelectedItem).Jednostki;
            combobox_jednostki_do.ItemsSource = ((IKonwerter_jedn)combobox_konwertery.SelectedItem).Jednostki;
        }

        private void Button_konwertuj_Click(object sender, RoutedEventArgs e)
        {
            string wpisanaWartoscText = textbox_wpisz_wartosc.Text;

            if (!double.TryParse(wpisanaWartoscText, out double wpisanaWartoscDouble))
            {
                MessageBox.Show("Nieprawidlowa wartosc!");
            }
            else
            {
                double wynik = (
                (IKonwerter_jedn)combobox_konwertery.SelectedItem).naWybr(combobox_jednostki_z.SelectedItem.ToString(),
                combobox_jednostki_do.SelectedItem.ToString(),
                wpisanaWartoscDouble); 

                textbox_wynik.Text = wynik.ToString();
            }
        }
    }
}
