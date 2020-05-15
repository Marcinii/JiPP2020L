using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
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

namespace Konwerter_jednostek
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window
    {
        public int str { get; set; }
        public int strMax { get; set; }

        public MainWindow()
        {

            str = 0;
            strMax = 0;
            InitializeComponent();

            CBOpcja.ItemsSource = new KonwerterSerwis().GetConverters();
            SKonwerter.ItemsSource = new KonwerterSerwis().GetConverters();


            using (BazaDanychOcena context = new BazaDanychOcena())
            {
                List<OcenaBaza> oc = context.OcenaDB
                    .Where(x => x.Id == context.OcenaDB.Count())
                    .ToList();
                ocenaControl.OcenaWartosc = oc[0].Ocena;
            }
            

            ConvertCommand = new RelayCommand(obj => Convert(),obj =>
                CBZ.SelectedItem != null && CBNa.SelectedItem !=null && string.IsNullOrEmpty(TBoxWartosc.Text) != true);
            Button1.Command = ConvertCommand;

            StatystykiCommand = new RelayCommand(obj => Statystyki1(), obj => SKonwerter.SelectedItem != null);
            Button2.Command = StatystykiCommand;

            PoprzedniaCommand = new RelayCommand(obj => Poprzednia(), obj => str > 0);
            Button4.Command = PoprzedniaCommand;

            NastepnaCommand = new RelayCommand(obj => Nastepna(), obj => strMax > str);
            Button3.Command = NastepnaCommand;
        }



        private void CBOpcja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBZ.ItemsSource = ((IKonwerter)CBOpcja.SelectedItem).Jednostki;
            CBNa.ItemsSource = ((IKonwerter)CBOpcja.SelectedItem).Jednostki;
            if (((IKonwerter)CBOpcja.SelectedItem).Nazwa == "Czas")
            {
                ((Storyboard)Resources["StoryboardMin"]).Begin();
                ((Storyboard)Resources["StoryboardGodz"]).Begin();
            }
        }

        private RelayCommand ConvertCommand;
        private void Convert()
        {

            string WartoscWe = TBoxWartosc.Text;
            string wartosc = WartoscWe;

            TBlockWynik.Text = (((IKonwerter)CBOpcja.SelectedItem).Konwerter(CBZ.Text, CBNa.Text, wartosc));//.ToString("F");
            if (((IKonwerter)CBOpcja.SelectedItem).Nazwa == "Czas")
            {
                ((Storyboard)Resources["StoryboardMin"]).Stop();
                ((Storyboard)Resources["StoryboardGodz"]).Stop();
                if (int.TryParse(String.Concat(TBlockWynik.Text[3], TBlockWynik.Text[4]), out int a1)) a1 *= 6; else a1 = 0;
                RotacjaMin.Angle = a1;
                if (int.TryParse(String.Concat(TBlockWynik.Text[0], TBlockWynik.Text[1]), out int a2)) a2 *= 30; else a2 = 0;
                RotacjaGodz.Angle = a2 + a1 / 12.0;
            }
            WstawRekordDoBD(((IKonwerter)CBOpcja.SelectedItem).Nazwa, CBZ.Text, wartosc, CBNa.Text, TBlockWynik.Text);
        }

        public static void WstawRekordDoOceny(int ocena)
        {
            using (BazaDanychOcena context = new BazaDanychOcena())
            {
                OcenaBaza NowyRekord = new OcenaBaza()
                {
                    Ocena = ocena
                };
                context.OcenaDB.Add(NowyRekord);
                context.SaveChanges();
            }
        }

        public static void WstawRekordDoBD(string RK, string JZ, string WDK, string JN, string WPK)
        {
            using (BazaDanych context = new BazaDanych())
            {
                Konwersja NowyRekord = new Konwersja()
                {
                    DataKonwersji = DateTime.Now,
                    RodzajKonwertera = RK,
                    JednostkaZ = JZ,
                    WartoscDoKonwersji = WDK,
                    JednostkaNa = JN,
                    WartoscPoKonwersji = WPK
                };

                context.Konwersje.Add(NowyRekord);
                context.SaveChanges();
            }


        }



        private RelayCommand StatystykiCommand;

        private void Statystyki1()
        {
            tokenSource = new CancellationTokenSource();
            LadowaniePanel.Visibility = Visibility.Visible;
            ((Storyboard)Resources["circleStoryboard"]).Begin();
            if (DateTime.TryParse(TBoxData1.Text, out DateTime d1)) { } else d1 = new DateTime(2020, 01, 01);
            if (DateTime.TryParse(TBoxData2.Text, out DateTime d2)) { d2 = new DateTime(d2.Year, d2.Month, d2.Day, 23, 59, 59); } else d2 = DateTime.Now;
            string ik1 = (((IKonwerter)SKonwerter.SelectedItem).Nazwa);

            Task t1 = new Task(() => Statystyki(tokenSource.Token, d1, d2, ik1), tokenSource.Token);
            t1.Start();
            Task.WhenAll(t1).ContinueWith(t =>
          {
              if (t.IsFaulted) { MessageBox.Show("Wystąpił błąd"); }
              Dispatcher.Invoke(() => LadowaniePanel.Visibility = Visibility.Hidden);
              ((Storyboard)Resources["circleStoryboard"]).Stop();
          });
        }

        private void Statystyki(CancellationToken ct, DateTime d1, DateTime d2, string ik1)
        { 
            using (BazaDanych context = new BazaDanych())
            {
                str = 0;
 
                List<Konwersja> kon = context.Konwersje
                    .Where(k => k.RodzajKonwertera == ik1)
                    .Where(k => k.DataKonwersji >= d1)
                    .Where(k => k.DataKonwersji <= d2)
                    .OrderBy(k => k.DataKonwersji)
                    .Skip(str * 10)
                    .Take(10)
                    .ToList();

                Dispatcher.Invoke(() => Tabela1.ItemsSource = kon);

                if (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();
                }

                Dispatcher.Invoke(() => Tabela2.ItemsSource = context.Konwersje
                .Where(v => v.RodzajKonwertera == ik1)
                .Where(v => v.DataKonwersji >= d1)
                .Where(v => v.DataKonwersji <= d2)
                .GroupBy(v => new { v.RodzajKonwertera, v.JednostkaZ, v.JednostkaNa })
                .Select(v => new { v.Key.RodzajKonwertera, v.Key.JednostkaZ, v.Key.JednostkaNa, Krotnosc = v.Count() })
                .OrderByDescending(v => v.Krotnosc)
                .Take(3)
                .ToList());

                if (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();
                }

                strMax = context.Konwersje
                .Where(m => m.RodzajKonwertera == ik1)
                .Where(m => m.DataKonwersji >= d1)
                .Where(m => m.DataKonwersji <= d2)
                .Count();
                if (strMax % 10 == 0) strMax = strMax / 10 - 1;
                else strMax = strMax / 10;


            }
            for (int i = 1; i < 6; i++)
            {
                if (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();
                }
                Task.Delay(1000).Wait();
            }
        }

        private RelayCommand NastepnaCommand;
        private void Nastepna()
        {
            str++;
            using (BazaDanych context = new BazaDanych())
            {
                if (DateTime.TryParse(TBoxData1.Text, out DateTime d1)) { } else d1 = new DateTime(2020, 01, 01);
                if (DateTime.TryParse(TBoxData2.Text, out DateTime d2)) { d2 = new DateTime(d2.Year, d2.Month, d2.Day, 23, 59, 59); } else d2 = DateTime.Now;
                List<Konwersja> kon = context.Konwersje
                .Where(k => k.RodzajKonwertera == (((IKonwerter)SKonwerter.SelectedItem).Nazwa))
                .Where(k => k.DataKonwersji >= d1)
                .Where(k => k.DataKonwersji <= d2)
                .OrderBy(k => k.DataKonwersji)
                .Skip(str * 10)
                .Take(10)
                .ToList();

                Tabela1.ItemsSource = kon;
                
            }

        }

        private RelayCommand PoprzedniaCommand;
        private void Poprzednia()
        {
            using (BazaDanych context = new BazaDanych())
            {
                if (str != 0) str--;
                if (DateTime.TryParse(TBoxData1.Text, out DateTime d1)) { } else d1 = new DateTime(2020, 01, 01);
                if (DateTime.TryParse(TBoxData2.Text, out DateTime d2)) { d2 = new DateTime(d2.Year, d2.Month, d2.Day, 23, 59, 59); } else d2 = DateTime.Now;
                List<Konwersja> kon = context.Konwersje
                .Where(k => k.RodzajKonwertera == (((IKonwerter)SKonwerter.SelectedItem).Nazwa))
                .Where(k => k.DataKonwersji >= d1)
                .Where(k => k.DataKonwersji <= d2)
                .OrderBy(k => k.DataKonwersji)
                .Skip(str * 10)
                .Take(10)
                .ToList();

                Tabela1.ItemsSource = kon;
                
            }
        }

        private void ocenaControl_OcenaWartoscZmiana(object sender, Common.Controls.ocena.RateEventArgs e)
        {
            WstawRekordDoOceny(e.Value);
        }

        CancellationTokenSource tokenSource;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tokenSource.Cancel();
        }
    }
}
