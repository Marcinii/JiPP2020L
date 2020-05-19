using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
using Konwerter_jedn;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //statystyki
        private DBManager db;

        public MainWindow()
        {
            InitializeComponent();
            combobox_konwertery.ItemsSource = new List<IKonwerter_jedn>()
            {
                new cisnienia(),
                new masy(),
                new odleglosci(),
                new temperatury(),
                new zegar(),
            };

            selectConverter.ItemsSource = new List<string>()
            {
                "Wszystkie",
                new cisnienia().ToString(),
                new masy().ToString(),
                new odleglosci().ToString(),
                new temperatury().ToString(),
                new zegar().ToString(),
            };

            Tarcza_Zegara.Visibility = Visibility.Hidden;
            Wskazowka_Godzinowa.Visibility = Visibility.Hidden;
            Wskazowka_Minutowa.Visibility = Visibility.Hidden;

            using (KASETY_412_15Entities context = new KASETY_412_15Entities())
            {
                var ocena = context.rate
                                    .OrderByDescending(r => r.id)
                                    .FirstOrDefault();
                button_ocen.RateValue = ocena.rate1;
            }

            //statystyki
            db = new DBManager();
            dataGrid.ItemsSource = db?.Filter("Wszystkie", dateFrom.SelectedDate, dateTo.SelectedDate);

            //komendy Relay Command
            KonwertujCommand = new RelayCommand(obj => Konwertuj());
            button_konwertuj.Command = KonwertujCommand;

            FiltrujCommand = new RelayCommand(obj => Filtruj());
            Filtruj_button.Command = FiltrujCommand;

            PrevCommand = new RelayCommand(obj => Prev_Click());
            Prev.Command = PrevCommand;

            NextCommand = new RelayCommand(obj => Next_Click());
            Next.Command = NextCommand;

            Top_KonwersjeCommand = new RelayCommand(obj => Top_Konwersje_Click());
            Top_Konwersje.Command = Top_KonwersjeCommand;
        }
        //komendy
        public RelayCommand KonwertujCommand;
        public RelayCommand FiltrujCommand;
        public RelayCommand PrevCommand;
        public RelayCommand NextCommand;
        public RelayCommand Top_KonwersjeCommand;

        private void Combobox_konwertery_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            combobox_jednostki_z.ItemsSource = ((IKonwerter_jedn)combobox_konwertery.SelectedItem).Jednostki;
            combobox_jednostki_do.ItemsSource = ((IKonwerter_jedn)combobox_konwertery.SelectedItem).Jednostki;

            switch (((IKonwerter_jedn)combobox_konwertery.SelectedItem).Nazwa)
            {
                case "zegar":
                    Tarcza_Zegara.Visibility = Visibility.Visible;
                    Wskazowka_Godzinowa.Visibility = Visibility.Visible;
                    Wskazowka_Minutowa.Visibility = Visibility.Visible;
                    ((Storyboard)FindResource("Zegar_Pokaz")).Begin();
                    break;
                default:
                    ((Storyboard)FindResource("Zegar_Ukryj")).Begin();
                    break;

            }
        }

        //komendy
        private void Konwertuj()
        {
            
            if (!double.TryParse(textbox_wpisz_wartosc.Text, out double wpisanaWartoscDouble) &&
                ((IKonwerter_jedn)combobox_konwertery.SelectedItem).Nazwa != "zegar")
            {
                MessageBox.Show("Nieprawidlowa wartosc!");
            }
            else
            {
                string wynik = (
                (IKonwerter_jedn)combobox_konwertery.SelectedItem).naWybr(combobox_jednostki_z.SelectedItem.ToString(),
                combobox_jednostki_do.SelectedItem.ToString(),
                textbox_wpisz_wartosc.Text); 

                textbox_wynik.Text = wynik.ToString();

                
                if (((IKonwerter_jedn)combobox_konwertery.SelectedItem).Nazwa =="zegar")
                {
                    if (DateTime.TryParse(wynik, out DateTime czas_na_zegarze))
                    {
                        MinuteRotation.Angle = (czas_na_zegarze.Minute * 6.0)+90;
                        HourRotation.Angle = (czas_na_zegarze.Hour * 30.0) + (czas_na_zegarze.Minute / 60.0 * 30.0)+90;
                    }
                }
            }
            db.SaveToDB(new Statistics() //zapisywanie do bazy danych
            {
                conversion_date = DateTime.Now,
                converter_type = combobox_konwertery.SelectedItem.ToString(),
                unit_from = combobox_jednostki_z.SelectedItem.ToString(),
                unit_to = combobox_jednostki_do.SelectedItem.ToString(),
                insert_data = textbox_wpisz_wartosc.Text,
                output_data = textbox_wynik.Text,
             }, dataGrid);
            

        }

        private void Button_ocen_RateValueChanged(object sender, Common.Controls.RateMe.RateEventArgs e)
        {
            using (KASETY_412_15Entities context = new KASETY_412_15Entities())
            {
                var ocena = new rate()
                {
                    rate1 = e.Value
                };
                context.rate.Add(ocena);
                context.SaveChanges();
            }
        }

        private void SelectConverter_SelectionChanged(object sender, SelectionChangedEventArgs e) //wybrany konwerter
        {
         //   string konwerter = ((IKonwerter_jedn)combobox_konwertery.SelectedItem).Nazwa;
           // dataGrid.ItemsSource = db?.Filter(konwerter, dateFrom.SelectedDate, dateTo.SelectedDate);
        }

        private void Filtruj() //filtruj button
        {   /*
            string konwerter = selectConverter.SelectedItem.ToString();
            dataGrid.ItemsSource = db?.Filter(konwerter, this.dateFrom.SelectedDate, this.dateTo.SelectedDate);
            */

            // Pokazujesz ekran ladowania
            //StatsWindowLoadingScreen.Visibility = Visibility.Visible;

            Task task1 = new Task(() => ZaladujStatystyki());
            task1.Start();

            Task.WhenAll(task1).ContinueWith(t =>
            {
                // Ukrywasz ekran ladowania
                //Dispatcher.Invoke(() => StatsWindowLoadingScreen.Visibility = Visibility.Hidden);
                MessageBox.Show("Ukrywam ekran ladowania!");
            });
        }
        private void ZaladujStatystyki()
        {
            Task.Delay(3000).Wait();

            string konwerter = selectConverter.SelectedItem.ToString();

            Dispatcher.Invoke(() =>
            {
                dataGrid.ItemsSource = db?.Filter(konwerter, this.dateFrom.SelectedDate, this.dateTo.SelectedDate);
            });
        }

        private void Prev_Click() //poprzednia strona
        {
            dataGrid.ItemsSource = db.TakePrev();
        }

        private void Next_Click() //nastepna strona
        {
            dataGrid.ItemsSource = db.TakeNext();
        }

        private void Top_Konwersje_Click() //top 3 konwersje
        {
            topKonwersje.ItemsSource = db.Top3c();
        }


    }
}
