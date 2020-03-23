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
      
      IKonwerter_jedn wybranyKonwerter { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            lista_konwerterow.ItemsSource = new List<IKonwerter_jedn>()
            {
                new cisnienia(),
                new masy(),
                new odleglosci(),
                new temperatury() 
            };
        }

        private void Lista_konwerterow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lista_jednostek_z.ItemsSource = ((IKonwerter_jedn)lista_konwerterow.SelectedItem).Jednostki;
            lista_jednostek_do.ItemsSource = ((IKonwerter_jedn)lista_konwerterow.SelectedItem).Jednostki;
        }

        private void Przycisk_konwertuj_Click(object sender, RoutedEventArgs e)
        {
            /* string inputText = text_konwersja_z.Text;
             double.TryParse(text_konwersja_z.Text, out double value);
             ((IKonwerter_jedn)lista_konwerterow.SelectedItem).naWybr(lista_jednostek_z.SelectedItem, lista_jednostek_do.SelectedItem.ToString, value);
             */

            okno_wynik.Text = "";
            if (lista_konwerterow.SelectedItem ==null)
            {
                MessageBox.Show("Wybierz jakas opcje.");
            }
            else
            {
                if (lista_jednostek_z.SelectedItem ==null || lista_jednostek_do ==null)
                {
                    MessageBox.Show("Wybierz jakas opcje.");
                }
                else
                {
                    string Zjakiej = lista_jednostek_z.SelectedItem.ToString();
                    string DOjakiej = lista_jednostek_do.SelectedItem.ToString();
                    string dane = text_konwersja_z.Text;
                    var result = wybranyKonwerter.naWybr(Zjakiej, DOjakiej, dane);
                    okno_wynik.Text = result.ToString();
                }
            }
            /*string Zjakiej = lista_jednostek_z.SelectedItem.ToString();
            string DOjakiej = lista_jednostek_do.SelectedItem.ToString();
            string dane = text_konwersja_z.Text;
            var result = wybranyKonwerter.naWybr(Zjakiej, DOjakiej, dane);
            okno_wynik.Text = result.ToString();*/

        }
    }
}
