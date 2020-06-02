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
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Media.Animation;

namespace AplikacjaBryly
{

    public partial class MainWindow : Window
    {
        public int str { get; set; }
        public int strMax { get; set; }
        public int WielkoscTablicy1 { get; set; }

        public MainWindow()
        {
            str= 0;
            strMax = 0;
            WielkoscTablicy1 = 3;


            InitializeComponent();

            OpcjaB.ItemsSource = new BrylaSerwis().GetBrylas();

            OpcjaF.ItemsSource = new FiguraSerwis().GetFiguras();

            ObliczCommand = new RelayCommand(obj => Oblicz(), obj =>
                 OpcjaB.SelectedItem != null && OpcjaB.SelectedItem != null && string.IsNullOrEmpty(TBoxBok1.Text) != true && string.IsNullOrEmpty(TBoxH.Text) != true);
            Button1.Command = ObliczCommand;

            PoprzedniaCommand = new RelayCommand(obj => Poprzednia(), obj => str > 0);
            Button4.Command = PoprzedniaCommand;

            NastepnaCommand = new RelayCommand(obj => Nastepna(), obj => strMax > str);
            Button3.Command = NastepnaCommand;


        }

        //private void OpcjaB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        private void OpcjaF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch (((IFigura)OpcjaF.SelectedItem).NazwaF)
            {
                case "Kwadrat":
                    Napis3.Visibility = Visibility.Visible;
                    TBoxBok1.Visibility = Visibility.Visible;
                    Napis4.Visibility = Visibility.Hidden;
                    TBoxBok2.Visibility = Visibility.Hidden;
                    Napis5.Visibility = Visibility.Hidden;
                    TBoxh.Visibility = Visibility.Hidden;
                    break;
                case "Prostokąt":
                    Napis3.Visibility = Visibility.Visible;
                    TBoxBok1.Visibility = Visibility.Visible;
                    Napis4.Visibility = Visibility.Visible;
                    TBoxBok2.Visibility = Visibility.Visible;
                    Napis5.Visibility = Visibility.Hidden;
                    TBoxh.Visibility = Visibility.Hidden;
                    break;
                case "Trójkąt":
                    Napis3.Visibility = Visibility.Visible;
                    TBoxBok1.Visibility = Visibility.Visible;
                    Napis4.Visibility = Visibility.Hidden;
                    TBoxBok2.Visibility = Visibility.Hidden;
                    Napis5.Visibility = Visibility.Visible;
                    TBoxh.Visibility = Visibility.Visible;
                    break;

            }
        }

        private RelayCommand ObliczCommand;
        private void Oblicz()
        {
            double pp, ob;
            pp = ((IFigura)OpcjaF.SelectedItem).PolePow(TBoxBok1.Text, TBoxBok2.Text, TBoxh.Text);
            ob = ((IBryla)OpcjaB.SelectedItem).Objetosc(pp, TBoxH.Text);
            if (ob == 0) MessageBox.Show("Błędne dane");
            else
            {
                TBlockWynik.Text = ob.ToString("F");
                WstawRekordDoBD(((IBryla)OpcjaB.SelectedItem).NazwaB, ((IFigura)OpcjaF.SelectedItem).NazwaF, TBoxBok1.Text, TBoxBok2.Text, TBoxh.Text, TBoxH.Text, ob);
            }
        }


        public static void WstawRekordDoBD(string B, string F, string b1, string b2, string hf, string HB, double Obj)
        {
            using (StatystykiBaza context = new StatystykiBaza())
            {
                StatystykiBryly NowyRekord = new StatystykiBryly()
                {
                    Data = DateTime.Now,
                    Bryla = B,
                    Figura = F,
                    Bok1 = b1,
                    Bok2 = b2,
                    hFigury = hf,
                    HBryly = HB,
                    Objetosc = Obj
                };

                context.SBryly.Add(NowyRekord);
                context.SaveChanges();
            }
        }
        
        public void WyswietlTabele1(CancellationToken ct)
        {

            using (StatystykiBaza context = new StatystykiBaza())
            {
                strMax = context.SBryly
                .GroupBy(v => new { v.Bryla, v.Figura })
                .Count();
                if (strMax % WielkoscTablicy1 == 0) strMax = strMax / WielkoscTablicy1 - 1;
                else strMax = strMax / WielkoscTablicy1;

                if (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();
                }

                var DaneTab1 = context.SBryly
                .GroupBy(v => new { v.Bryla, v.Figura })
                .Select(v => new { v.Key.Bryla, Podstawa = v.Key.Figura, Krotnosc = v.Count() })
                .OrderByDescending(v => v.Krotnosc)
                .Skip(str * WielkoscTablicy1)
                .Take(WielkoscTablicy1)
                .ToList();

                Dispatcher.Invoke(() => Tabela1.ItemsSource = DaneTab1); 
            }
        }

        public void WyswietlTabele1a()
        {

            using (StatystykiBaza context = new StatystykiBaza())
            {
                var DaneTab1 = context.SBryly
                .GroupBy(v => new { v.Bryla, v.Figura })
                .Select(v => new { v.Key.Bryla, Podstawa = v.Key.Figura, Krotnosc = v.Count() })
                .OrderByDescending(v => v.Krotnosc)
                .Skip(str * WielkoscTablicy1)
                .Take(WielkoscTablicy1)
                .ToList();

                Dispatcher.Invoke(() => Tabela1.ItemsSource = DaneTab1);
            }
        }

        public void PokazPanel()
        {
            LadowaniePanel.Visibility = Visibility.Visible;
            ((Storyboard)Resources["circleStoryboard"]).Begin();
        }

        public void UkryjPanel()
        {
            LadowaniePanel.Visibility = Visibility.Hidden;
            ((Storyboard)Resources["circleStoryboard"]).Stop();
        }

        private void ButtonS_Click(object sender, RoutedEventArgs e)
        {
            tokenSource = new CancellationTokenSource();
            PokazPanel();
            str = 0;
            Task t1 = new Task(() => WyswietlTabele1(tokenSource.Token), tokenSource.Token);
            t1.Start();
            Task.WhenAll(t1).ContinueWith(t =>
            {
                if (t.IsFaulted) { MessageBox.Show("Wystąpił błąd"); }
                UkryjPanel();
            }, TaskScheduler.FromCurrentSynchronizationContext());

        }

        private RelayCommand PoprzedniaCommand;
        private void Poprzednia()
        {
            //poporzednia strona
            if (str != 0)
            {
                str--;
                PokazPanel();
                Task t1 = new Task(() => WyswietlTabele1a());
                t1.Start();
                Task.WhenAll(t1).ContinueWith(t =>
                {
                    if (t.IsFaulted) { MessageBox.Show("Wystąpił błąd"); }
                    UkryjPanel();
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private RelayCommand NastepnaCommand;
        private void Nastepna()
        {
            //nastepna strona
            str++;
            PokazPanel();
            Task t1 = new Task(() => WyswietlTabele1a());
            t1.Start();
            Task.WhenAll(t1).ContinueWith(t =>
            {
                if (t.IsFaulted) { MessageBox.Show("Wystąpił błąd"); }
                UkryjPanel();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        CancellationTokenSource tokenSource;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tokenSource.Cancel();
        }
    }
}
