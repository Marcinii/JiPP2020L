using Kontakty.Logika;
using Konwerter.Okienko;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kontakty.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window   //((ITypKontaktu)TypKontaktu.SelectedItem).NumerTypu
    {
        public MainWindow()
        {
            InitializeComponent();
            TypKontaktu.ItemsSource = new KontaktySerwis().NazwyTypow();
            TypSearch.ItemsSource = new KontaktySerwis().NazwyTypow2();

            using (ContactsEntities c = new ContactsEntities())
            {
                List<Contacts> pozycje = c.Contacts.ToList();
                Dane.DataContext = pozycje;
            }
            SearchCommand = new RelayCommand(obj => PokazZaladowane(NazwiskoSearch.Text, ((ITypKontaktu)TypSearch.SelectedItem).NazwaTypu, KontaktSearch.Text, Dane));
            SearchButton.Command = SearchCommand;
        }


        private void DodajKontakt_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["animacja"]).Begin();

            using (ContactsEntities c = new ContactsEntities())
            {
                Contacts nowy = new Contacts()
                {
                    Nazwisko = Nazwisko.Text,
                    Kontakt = Kontakt.Text,
                    NazwaTypu = ((ITypKontaktu)TypKontaktu.SelectedItem).NazwaTypu,
                    NumerTypu = ((ITypKontaktu)TypKontaktu.SelectedItem).NumerTypu
                };
                c.Contacts.Add(nowy);
                c.SaveChanges();
            }
            using (ContactsEntities c = new ContactsEntities())
            {
                List<Contacts> pozycje = c.Contacts.ToList();
                Dane.DataContext = pozycje;
            }
        }
        private RelayCommand SearchCommand;


        private void PokazZaladowane(string nazwisko, string typ, string kontakt, DataGrid dane)
        {
            Thread t = new Thread(() => Ladowanie(nazwisko, typ, kontakt, dane));
            t.Start();
        }

        private void Ladowanie(string nazwisko, string typ, string kontakt, DataGrid dane)
        {
            using (ContactsEntities c = new ContactsEntities())
            {
                Dispatcher.Invoke(() => { loaderAnimacja.Visibility = Visibility.Visible; });
                Thread.Sleep(1500);
                StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase;
                List<Contacts> pozycje = c.Contacts.ToList();
                List<Contacts> doPokazania = pozycje.Where(d =>
                                d.Nazwisko.IndexOf(nazwisko, stringComparison) >= 0 &&                      d.NazwaTypu.Contains(typ) &&
                                d.Kontakt.IndexOf(kontakt, stringComparison) >= 0).ToList();
                Dispatcher.Invoke(() =>
                {
                    loaderAnimacja.Visibility = Visibility.Hidden;
                    dane.DataContext = doPokazania.ToList();
                });
            }
        }

        private void Nazwisko_GotFocus(object sender, RoutedEventArgs e)
        {
            Nazwisko.Text = "";
        }

        private void Nazwisko_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Nazwisko.Text))
            {
                Nazwisko.Text = "Imię i nazwisko";
            }
        }

        private void Kontakt_GotFocus(object sender, RoutedEventArgs e)
        {
            Kontakt.Text = "";
        }

        private void Kontakt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Kontakt.Text))
            {
                Kontakt.Text = "kontakt";
            }
        }
    }
}
