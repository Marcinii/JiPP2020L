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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();

            KonwerterComboBox.ItemsSource = new List<IKonwerter>()
            {
                new Temperatura(),
                new Odleglosc(),
                new Masa(),
                new Energia(),
                new Czas()
            };
            clockRotation1.Angle = 0;

            StatystykaCombobox.ItemsSource = new List<IKonwerter>()
            {
                new Temperatura(),
                new Odleglosc(),
                new Masa(),
                new Energia(),
                new Czas()
            };
        }

        private void KonwerterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ZComboBox.ItemsSource = ((IKonwerter)KonwerterComboBox.SelectedItem).Unit;
            DoComboBox.ItemsSource = ((IKonwerter)KonwerterComboBox.SelectedItem).Unit;
        }

        private void actionButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = WartoscTextBox.Text;

            string wynik = ((IKonwerter)KonwerterComboBox.SelectedItem).Konwert(
                ZComboBox.SelectedItem.ToString(),
                DoComboBox.SelectedItem.ToString(),
                inputText);

            WynikTextBlock.Text = wynik.ToString();

            InstertDataToDB(); //TOOO

            if (Convert.ToString(ZComboBox.SelectedItem) == "24h")
            {
                double hour, minutes, h, min;

                int index = wynik.IndexOf(":");
                if (index == 1)
                {
                    h = Convert.ToDouble(wynik.Substring(0, 1));
                    min = Convert.ToDouble(wynik.Substring(2, 2));
                }
                else
                {
                    h = Convert.ToDouble(wynik.Substring(0, 2));
                    min = Convert.ToDouble(wynik.Substring(3, 2));
                }
                hour = h * 30 + 90;
                minutes = min * 6 + 90;

                clockRotation1.Angle = hour;
                clockRotation2.Angle = minutes;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["Storyboard1"]).Begin();
        }

        public void Sortowanie()
        {
            string konwerers = StatystykaCombobox.SelectedItem.ToString();

            using (BazaDanychEntities context = new BazaDanychEntities())
            {
                List<BazaDanych> statystyka = context.BazaDanyches.ToList();
                statystyka = context.BazaDanyches.Where(k => k.Konwertor == konwerers).OrderByDescending(el => el.Id).ToList();
                BazaStatystyk.ItemsSource = statystyka;
            }
        }

        private void StatystykaCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sortowanie();
        }


        private void leftbtn_Click(object sender, RoutedEventArgs e)
        {
            using (BazaDanychEntities context = new BazaDanychEntities())
            {
                List<BazaDanych> statystyka = context.BazaDanyches.ToList();
                statystyka = context.BazaDanyches.OrderBy(i => i.Id).Take(20).ToList();
                BazaStatystyk.ItemsSource = statystyka;
            }
        }

        private void rightbtn_Click(object sender, RoutedEventArgs e)
        {
            using (BazaDanychEntities context = new BazaDanychEntities())
            {
                List<BazaDanych> statystyka = context.BazaDanyches.ToList();
                statystyka = context.BazaDanyches.OrderBy(i=>i.Id).Skip(20).Take(20).ToList();
                BazaStatystyk.ItemsSource = statystyka;
            }
        }

        private void Filtruj_Click(object sender, RoutedEventArgs e)
        {
            DateTime DataOd1 = DateTime.Parse(DataOd.Text);
            DateTime DataDo1 = DateTime.Parse(DataDo.Text);

            using (BazaDanychEntities context = new BazaDanychEntities())
            {
              
                List<BazaDanych> statystyka = context.BazaDanyches.ToList();
                statystyka = context.BazaDanyches.Where(f => f.Data > DataOd1).Where(f =>f.Data<DataDo1).ToList();
                BazaStatystyk.ItemsSource = statystyka;
            }
        }

 

        private void DataOd_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataDo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void WartoscTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void getStats(int ShowPage = 0, string bySelectedItem = "")
        {
            using (BazaDanychEntities context = new BazaDanychEntities())
            {
                List<BazaDanych> statystyka = context.BazaDanyches.ToList();
                statystyka = context.BazaDanyches.Take(20).ToList();
                BazaStatystyk.ItemsSource = statystyka;
            }
        }

        public void InstertDataToDB() // TOOOOOOOOO
        {
            using (BazaDanychEntities context = new BazaDanychEntities())
            {
                BazaDanych konwerterstats = new BazaDanych()
                {
                    Konwertor = KonwerterComboBox.Text.ToString(),
                    Z = ZComboBox.Text.ToString(),
                    Do = DoComboBox.Text.ToString(),
                    WartoscWejsciowa = WartoscTextBox.Text.ToString(),
                    WartoscWyjsciowa = WynikTextBlock.Text.ToString(),
                    Data = DateTime.Now
                };
                context.BazaDanyches.Add(konwerterstats);
                context.SaveChanges();
            }
            //getStats(page, "");
        }

        private void Najczestrsze_Click(object sender, RoutedEventArgs e)
        {
            getStats();
        }

        private void ZComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Top3_Click(object sender, RoutedEventArgs e)
        {
            DateTime DataOd1 = DateTime.Parse(DataOd.Text);
            DateTime DataDo1 = DateTime.Parse(DataDo.Text);

            using (BazaDanychEntities context = new BazaDanychEntities())
            {
                List<BazaDanych> statystyka = context.BazaDanyches.ToList();
                statystyka = context.BazaDanyches.Where(f => f.Data > DataOd1).Where(f => f.Data < DataDo1).ToList();

                List<BazaDanych> term = context.BazaDanyches.Where(f => f.Data > DataOd1).Where(f => f.Data < DataDo1).ToList();

                List<string> pop = term.Select(T => T.Konwertor).ToList();

                BazaStatystyk.ItemsSource = term.GroupBy(l => new
                {
                    l.Konwertor,
                }).Select(g => new
                {
                    g.Key.Konwertor,
                    count = g.Count()
                })
                .OrderByDescending(g => g.count)
                .ToList()
                .Take(3);
            }
            //using (BazaDanychEntities context = new BazaDanychEntities())
            //{
            //    List<BazaDanych> term = context.BazaDanyches.ToList();

            //    List<string> pop = term.Select(T => T.Konwertor).ToList();

            //    BazaStatystyk.ItemsSource = term.GroupBy(l => new
            //    {
            //        l.Konwertor,
            //    }).Select(g => new
            //    {
            //        g.Key.Konwertor,
            //        count = g.Count()
            //    })
            //    .OrderByDescending(g => g.count)
            //    .ToList()
            //    .Take(3);
            //}

        }
    }
}
