using Common.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using UnitConverter_M2.Logic;

namespace UnitConverter_M2.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ModulStatystyk ms;

        private RelayCommand przeliczCommand, wLewoCommand, wPrawoCommand, filtrujCommand, wyczyscFiltryCommand;

        public MainWindow()
        {
            InitializeComponent();
            typKonwersji.ItemsSource = new ConvertersAvailable().getConverters();
            filtrowanieTypu.ItemsSource = new ConvertersAvailable().getConverters();
            ms = new ModulStatystyk(tabelaDanych);


            // odczytac z bazy
            wczytajOceneZBazy();


            /* komendy dla przyciskow */
            przeliczCommand = new RelayCommand(obj => przelicz_komenda(), obj =>
                typKonwersji.SelectedItem != null && jednostka1.SelectedItem != null &&
                string.IsNullOrEmpty(wartosc.Text) != true);
            przelicz.Command = przeliczCommand;

            wLewoCommand = new RelayCommand(obj => wLewoKomenda());
            wLewoButton.Command = wLewoCommand;

            wPrawoCommand = new RelayCommand(obj => wPrawoKomenda());
            wPrawoButton.Command = wPrawoCommand;

            filtrujCommand = new RelayCommand(obj => filtrujKomenda());
            FiltrujButton.Command = filtrujCommand;

            wyczyscFiltryCommand = new RelayCommand(obj => wyczyscFiltryKomenda());
            WyczyscFiltryButton.Command = wyczyscFiltryCommand;
        }

        private void wczytajOceneZBazy()
        {
            using (konwersjeEntities context = new konwersjeEntities())
            {
                /* jesli tabela jest pusta */
                if (!context.oceny.Any())
                    return;

                int result = context.oceny.OrderByDescending(p => p.id).FirstOrDefault().ocena;

                rateControl.RateValue = result;
            }
        }

        private void rateControl_RateValueChanged(object sender, Common.Controls.RateEventArgs e)
        {

            /* umieszeczenie nowej oceny do bazy */
            using (konwersjeEntities context = new konwersjeEntities())
            {
                oceny nowaOcena = new oceny()
                {
                    ocena = rateControl.RateValue
                };
            
                context.oceny.Add(nowaOcena);
                context.SaveChanges();
            }

        }


    private void typKonwersji_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((IConv)typKonwersji.SelectedItem).ToString() == "Czas")
            {
                jednostka1.ItemsSource = new List<string>() { "24h" };
                jednostka2.ItemsSource = new List<string>() { "12h" };
                return;
            }

            jednostka1.ItemsSource = ((IConv)typKonwersji.SelectedItem).units;
            jednostka2.ItemsSource = ((IConv)typKonwersji.SelectedItem).units;
        }

        private void przelicz_komenda()
        {

            decimal wartoscLiczbowa = 0;
            bool czyPrzeliczono = false;

            string wartoscTekstowa = wartosc.Text;

            if (((IConv)typKonwersji.SelectedItem).ToString() == "Czas")
            {
                wartoscTekstowa = wartoscTekstowa.Replace(":", ".");
            } 
           
            czyPrzeliczono = decimal.TryParse(wartoscTekstowa, NumberStyles.Any, CultureInfo.InvariantCulture, out wartoscLiczbowa);


            if (!czyPrzeliczono)
            {
                wynik.Text = "Blad w wejsciu!";
                return;
            }


            wynik.Text = ((IConv)typKonwersji.SelectedItem).convert(jednostka1.SelectedItem.ToString(),
                                                                    jednostka2.SelectedItem.ToString(),
                                                                    wartoscLiczbowa);


            /* umieszczenie nowych konwersji do bazy */
            using (konwersjeEntities context = new konwersjeEntities())
            {
                logi nowyLog = new logi()
                {
                    rodzaj = ((IConv)typKonwersji.SelectedItem).ToString(),
                    jednostka_z = jednostka1.SelectedItem.ToString(),
                    jednostka_do = jednostka2.SelectedItem.ToString(),
                    wartosc_z = wartoscLiczbowa.ToString("0.0000"),
                    wartosc_do = wynik.Text,
                    data = DateTime.Now
                };

                context.logi.Add(nowyLog);
                context.SaveChanges();
            }


            // ustawianie zegara
            if (((IConv)typKonwersji.SelectedItem).ToString() == "Czas")
            {
                ((Storyboard)Resources["PojawienieZegara"]).Begin();

                string godzinaDoWyswietlenia = wynik.Text.ToLower().Replace("am", "").Replace("pm", "");

                int godzina = Int32.Parse(godzinaDoWyswietlenia.Split(new char[] { ':' })[0]);
                int minuta = Int32.Parse(godzinaDoWyswietlenia.Split(new char[] { ':' })[1]);

                rotacjaMinuty.Angle = 6 * minuta;
                rotacjaGodziny.Angle = ((double)360 / 43200) * (3600 * godzina + 60 * minuta);
            }


        }

        private void wLewoKomenda()
        {
            ms.wLewo();
        }

        private void wPrawoKomenda()
        {
            ms.wPrawo();
        }

        private void filtrujKomenda()
        {
            /* ustaw parametry filtrow */
            if (dataOd.SelectedDate != null)
            {
                ms.ustawOd(dataOd.SelectedDate.Value);
            }

            if (dataDo.SelectedDate != null)
            {
                ms.ustawDo(dataDo.SelectedDate.Value);
            }

            if (filtrowanieTypu.SelectedIndex != -1)
            {
                ms.ustawFiltrTypu(filtrowanieTypu.SelectedItem.ToString());
            }

            /* top 3 */
            if (top3radio.IsChecked == true)
            {
                ms.wlTop3();
            } else
            {
                ms.wylTop3();
            }

            ms.wyswietl();
        }

        private void wyczyscFiltryKomenda()
        {
            top3radio.IsChecked = false;
            dataOd.SelectedDate = null;
            dataDo.SelectedDate = null;
            filtrowanieTypu.SelectedIndex = -1;

            ms.setStronaZero();
            ms.wyczyscFiltry();
            ms.wyswietl();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
