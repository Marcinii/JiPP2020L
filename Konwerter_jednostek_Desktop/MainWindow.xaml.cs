using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
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

namespace Konwerter_jednostek
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window
    {
        public int str { get; set; }

        public MainWindow()
        {

            str = 0;
            InitializeComponent();

            CBOpcja.ItemsSource = new KonwerterSerwis().GetConverters();
            SKonwerter.ItemsSource = new KonwerterSerwis().GetConverters();



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

        private void Button1_Click(object sender, RoutedEventArgs e)
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



        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            using (BazaDanych context = new BazaDanych())
            {
                str = 0;
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

                Tabela2.ItemsSource = context.Konwersje
                .Where(v => v.RodzajKonwertera == (((IKonwerter)SKonwerter.SelectedItem).Nazwa))
                .Where(v => v.DataKonwersji >= d1)
                .Where(v => v.DataKonwersji <= d2)
                .GroupBy(v => new { v.RodzajKonwertera, v.JednostkaZ, v.JednostkaNa })
                .Select(v => new { v.Key.RodzajKonwertera, v.Key.JednostkaZ, v.Key.JednostkaNa, Krotnosc = v.Count() })
                .OrderByDescending(v => v.Krotnosc)
                .Take(3)
                .ToList();
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
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

        private void Button4_Click(object sender, RoutedEventArgs e)
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
    }
}
