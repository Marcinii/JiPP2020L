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

            DisplayBananas(Bananas, BananasPopular);

            // odczytać z bazy danych wartośc oceny
            //rateControl.RateValue = 2;
            int tmp;
            using (CarEntities context = new CarEntities())
            {
                List<Cars> c = context.Cars.ToList();
                Cars cc = c.LastOrDefault();
                tmp = cc.ocena;
            }
            rateControl.RateValue = tmp;

            ConvertCommand1 = new RelayCommand(obj => Convert(), obj =>
                                             Lista.SelectedItem != null &&
                                             string.IsNullOrEmpty(Wartosc.Text) != true);
            Oblicz.Command = ConvertCommand1;

            ConvertCommand2 = new RelayCommand(obj => DisplayBananasFilter(rodzaj2.Text, int.Parse(strona2.Text), (DateTime)dataOD2.SelectedDate, (DateTime)dataDO2.SelectedDate, Bananas, BananasPopular), obj =>
                                             dataOD2.SelectedDate != null &&
                                             dataDO2.SelectedDate != null &&
                                             //string.IsNullOrEmpty(rodzaj2.Text) != true &&
                                             string.IsNullOrEmpty(strona2.Text) != true);
            filtruj.Command = ConvertCommand2;
        }
        private RelayCommand ConvertCommand1;
        private RelayCommand ConvertCommand2;

        private static void InsertBananas(string rodzaj, string jednostki, string wartosc, string wynik)
        {
            using (BananasEntities context = new BananasEntities())
            {
                Bananas NowyRekord = new Bananas()
                {
                    rodzaj = rodzaj,
                    jednostki = jednostki,
                    wartosc = wartosc,
                    wynik = wynik,
                    data = DateTime.Now
                };
                context.Bananas.Add(NowyRekord);
                context.SaveChanges();
            }
        }
        private static void DisplayBananas(DataGrid Bananas, DataGrid BananasPopular)
        {
            using (BananasEntities context=new BananasEntities())
            {
                List<Bananas> rekordy = context.Bananas.ToList();
                Bananas.DataContext = rekordy.Take(20).ToList();
                BananasPopular.ItemsSource=rekordy.GroupBy(b => new { b.rodzaj}).Select(c => new { c.Key.rodzaj, count = c.Count() }).OrderByDescending(d => d.count).ToList().Take(3);
            }
        }

        private static void DisplayBananasFilter(string rodzaj, int strona, DateTime dataOD, DateTime dataDO, DataGrid Bananas, DataGrid BananasPopular)
        {
            using (BananasEntities context = new BananasEntities())
            {
                List<Bananas> rekordy = context.Bananas.ToList();
                List<Bananas> filtrowane = rekordy.Where(a => a.rodzaj.StartsWith(rodzaj) && a.data < dataDO && a.data >= dataOD).ToList();
                Bananas.DataContext = filtrowane.Skip((strona - 1) * 20).Take(20).ToList(); ;
                BananasPopular.ItemsSource = filtrowane.GroupBy(b => new { b.rodzaj }).Select(c => new { c.Key.rodzaj, count = c.Count() }).OrderByDescending(d => d.count).ToList().Take(3);
            }
        }

        private void Convert()
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
                if (b > 11 && b < 24) { znak = "PM"; }
                else { znak = "AM"; }
                string poczatek = "";
                if (wynikowa < 10) { poczatek = "0"; }
                Wynik.Text = poczatek + wynikowa.ToString() + a.Substring(2, 3) + " " + znak;

                double katGodz = wynikowa * 30;
                double katMin = double.Parse(a.Substring(3, 2)) * 6;

                godzina.RenderTransform = new RotateTransform(katGodz);
                minuta.RenderTransform = new RotateTransform(katMin);
            }
            InsertBananas(((Ikonwenter)Lista.SelectedItem).Nazwa, ((Ikonwenter)Lista.SelectedItem).Nazwa, Wartosc.Text, Wynik.Text);
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
        private bool WczytanieOcenyPoWlaczeniuAplikacji = true;
        private void rateControl_RateValueChanged(object sender, Common.Controls.RateEventArgs e)
        {
            // zapisać do bazy danych zmienioną wartośc oceny e.Value
            int poprzednia;
            using(CarEntities context=new CarEntities())
            {
                int tmp;
                using (CarEntities context2 = new CarEntities())
                {
                    List<Cars> c = context2.Cars.ToList();
                    Cars cc = c.LastOrDefault();
                    tmp = cc.ocena;
                }
                poprzednia = tmp;
                Cars nowy = new Cars()
                {
                    ocena = e.Value
                };
                context.Cars.Add(nowy);
                context.SaveChanges();
            }
            if(!WczytanieOcenyPoWlaczeniuAplikacji && poprzednia == e.Value)
            {
                rateControl.Zeruj();
                using (CarEntities context = new CarEntities())
                {
                    List<Cars> c = context.Cars.ToList();
                    Cars cc = c.FirstOrDefault();
                    cc.ocena = 0;
                    context.SaveChanges();
                }
            }
            WczytanieOcenyPoWlaczeniuAplikacji = false;
        }
    }
}
