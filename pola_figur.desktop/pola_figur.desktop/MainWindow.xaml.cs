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
using pola_figur.logic;
using SugestieCustomControl;

namespace pola_figur.desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool weryfikacja = false;
        public MainWindow()
        {
            InitializeComponent();            

            wybor_figura_ComboBox.ItemsSource = new kalkulator_service().DajKonwertery();

            ObliczCommand = new RelayCommand(obj => Oblicz(), obj =>
            string.IsNullOrEmpty(wartosc_TextBox.Text) != true &&
            string.IsNullOrEmpty(wybor_figura_ComboBox.SelectedItem.ToString()) != true &&
            string.IsNullOrEmpty(wybor_obliczen_ComboBox.SelectedItem.ToString()) != true && weryfikacja != false);
            Oblicz_Button.Command = ObliczCommand;

            PoprzedniaCommand = new RelayCommand(obj => Poprzednia(), obj =>
            int.Parse(Strona.Content.ToString()) != 1);
            Poprzednia_Button.Command = PoprzedniaCommand;

            NastepnaCommand = new RelayCommand(obj => Nastepna(), obj =>
            History_DataGrid.Columns.Count != 0);
            Nastepna_Button.Command = NastepnaCommand;
        }
        private void wybor_figura_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wybor_obliczen_ComboBox.ItemsSource = ((IPola_figur)wybor_figura_ComboBox.SelectedItem).obliczenia;
            wartosc_TextBox.Clear();
            KoloKolorowe.Visibility = Visibility.Hidden;
            KwadratNiebieski.Visibility = Visibility.Hidden;
            if (((IPola_figur)wybor_figura_ComboBox.SelectedItem).Name == "Koło")
            {
                opis_Wartosci.Content = "Podaj promień koła >";
                KoloKolorowe.Visibility = Visibility.Visible;                
            }
            if (((IPola_figur)wybor_figura_ComboBox.SelectedItem).Name == "Kwadrat")
            {
                opis_Wartosci.Content = "Podaj wymiar boku >";
                KwadratNiebieski.Visibility = Visibility.Visible;                
            }            
        }               
        private RelayCommand ObliczCommand;
        private void Oblicz()
        {
            decimal x = 0;
            if (wybor_obliczen_ComboBox.SelectedItem.ToString() == "Pole")
            {
                if (decimal.TryParse(wartosc_TextBox.Text.ToString(), out x))
                {
                    wynik_TextBlock.Text = ((IPola_figur)wybor_figura_ComboBox.SelectedItem).Licz_pole(x).ToString();
                }
                else
                {
                    MessageBox.Show("Podaj poprawną partość");
                }
            }
            if (wybor_obliczen_ComboBox.SelectedItem.ToString() == "Obwód")
            {
                if (decimal.TryParse(wartosc_TextBox.Text.ToString(), out x))
                {
                    wynik_TextBlock.Text = ((IPola_figur)wybor_figura_ComboBox.SelectedItem).Licz_obwod(x).ToString();
                }
                else
                {
                    MessageBox.Show("Podaj poprawną partość");
                }
            }
            using (HistoryDataEntities context = new HistoryDataEntities())
            {
                Kistoria_Obliczen rec = new Kistoria_Obliczen()
                {
                    Data = System.DateTime.Now,
                    Figura = ((IPola_figur)wybor_figura_ComboBox.SelectedItem).Name,
                    Obliczanie = wybor_obliczen_ComboBox.Text.ToString(),
                    Wartosc = x,
                    Wynik = decimal.Parse(wynik_TextBlock.Text)
                };
                context.Kistoria_Obliczen.Add(rec);
                context.SaveChanges();
            }
        }
        public void Daj_historie(int biezaca)
        {
            using (var historia = new HistoryDataEntities())
            {
                var dane = historia.Kistoria_Obliczen.AsQueryable();
                var x = dane.OrderBy(LP => LP.ID).Skip(13 * (biezaca - 1)).Take(13).ToList();
                Dispatcher.Invoke(() =>
                {
                    History_DataGrid.ItemsSource = x;
                });
            }
        }
        private void PokazHistorie_Button_Click(object sender, RoutedEventArgs e)
        {
            int biezaca;
            biezaca = int.Parse(Strona.Content.ToString());
            Task t1 = new Task(() => Daj_historie(biezaca));
            t1.Start();
            Task.WhenAll(t1).ContinueWith(t =>
            {                
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private RelayCommand PoprzedniaCommand;
        private void Poprzednia()
        {
            int biezaca;
            biezaca = int.Parse(Strona.Content.ToString());
            if (biezaca > 1)
            {
                Strona.Content = biezaca - 1;
            }
            Daj_historie(biezaca - 1);
        }
        private RelayCommand NastepnaCommand;
        private void Nastepna()
        {
            int biezaca;
            biezaca = int.Parse(Strona.Content.ToString());            
            Strona.Content = biezaca + 1;
            Daj_historie(biezaca + 1);
        }

        private void Weryfikacja_Changed(object sender, UserControl1.RateEventArgs e)
        {
            weryfikacja = e.Value;            
        }
    }
}
