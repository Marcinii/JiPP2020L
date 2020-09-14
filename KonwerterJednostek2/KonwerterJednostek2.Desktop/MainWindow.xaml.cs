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

namespace KonwerterJednostek2.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int strona = 0;
        int logperpage = 10;
        int maxpage = 0;

        public MainWindow()
        {
            InitializeComponent();

            Category.ItemsSource = new List<iKonwerter>()
            {
                new KonwerterTemperatury(),
                new KonwerterDystansu(),
                new KonwerterMasy(),
                new KonwerterPowierzchni(),
                new KonwerterZegar()
            };
            FiltrTyp.ItemsSource = Category.ItemsSource;




            Tarcza.Visibility = Visibility.Hidden;
            Godzinowa.Visibility = Visibility.Hidden;
            Minutowa.Visibility = Visibility.Hidden;
        }

        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UnitFrom.ItemsSource = ((iKonwerter)Category.SelectedItem).Units;
            UnitTo.ItemsSource = ((iKonwerter)Category.SelectedItem).Units;

            Tarcza.Visibility = Visibility.Hidden;
            Godzinowa.Visibility = Visibility.Hidden;
            Minutowa.Visibility = Visibility.Hidden;

            if (((iKonwerter)Category.SelectedItem).Name == "KonwerterZegar")
            {
                Tarcza.Visibility = Visibility.Visible;
                Godzinowa.Visibility = Visibility.Visible;
                Minutowa.Visibility = Visibility.Visible;
                Storyboard sb = this.FindResource("TarczaStory") as Storyboard;
                Storyboard.SetTarget(sb, Tarcza);
                sb.Begin();
            }
        }

        private void Convert(object sender, RoutedEventArgs e)
        {
            if (((iKonwerter)Category.SelectedItem).Name == "KonwerterZegar")
            {
                TimeSpan.TryParse(Toconvert.Text, out TimeSpan ts);
                int hours = ts.Hours;
                int minutes = ts.Minutes;

                string res;
                double hoursConverted = ((KonwerterZegar)Category.SelectedItem).convert(hours, UnitFrom.Text, UnitTo.Text);
                if (hours > 11)
                {
                    res = String.Concat(hoursConverted, ":", minutes, " PM");
                }
                else if (hours == 0)
                {
                    res = String.Concat("12:", minutes, " AM");
                }
                else
                {
                    res = String.Concat(hoursConverted, ":", minutes, " AM");
                }

                Converted.Content = res;
                Minutowa.RenderTransform = new RotateTransform(360 / 60 * minutes);
                Godzinowa.RenderTransform = new RotateTransform(360 / 12 * hours + 360.0 / 60 / 12 * minutes);
            }
            else
            {
                double.TryParse(Toconvert.Text, out double value);
                Converted.Content = ((iKonwerter)Category.SelectedItem).convert(value, UnitFrom.Text, UnitTo.Text);
            }

            using (converterEntities context = new converterEntities())
            {
                Log log = new Log()
                {

                    Typ = ((iKonwerter)Category.SelectedItem).ToString(),
                    JednostkaZ = UnitFrom.Text,
                    JednostkaDo = UnitTo.Text,
                    Data = System.DateTime.Now,
                    WartoscPrzed = Toconvert.Text,
                    WartoscPo = Converted.Content.ToString()
                };

                context.Log.Add(log);
                context.SaveChanges();
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            using (converterEntities context = new converterEntities())
            {
                List<Log> logi = zwrocOdfiltrowaneLogi(context).ToList();
                LogList.ItemsSource = logi.Take(logperpage);
                maxpage = logi.Count() / 10;
            }

            strona = 0;

        }

        private void pageback(object sender, RoutedEventArgs e)
        {
            strona--;

            using (converterEntities context = new converterEntities())
            {
                LogList.ItemsSource = zwrocOdfiltrowaneLogi(context).ToList().Skip(strona * 10).Take(logperpage);
            }
        }

        private void pagenext(object sender, RoutedEventArgs e)
        {
            if (strona != maxpage)
            {
                strona++;
            }

            using (converterEntities context = new converterEntities())
            {
                LogList.ItemsSource = zwrocOdfiltrowaneLogi(context).ToList().Skip(strona * 10).Take(logperpage);
            }
        }

        private void showtop3(object sender, RoutedEventArgs e)
        {
            using (converterEntities context = new converterEntities())
            {
                LogList.ItemsSource = zwrocOdfiltrowaneLogi(context).GroupBy(l => new { l.Typ, l.JednostkaZ, l.JednostkaDo })
                    .Select(g => new { g.Key.Typ, g.Key.JednostkaZ, g.Key.JednostkaDo, count = g.Count() })
                    .OrderByDescending(g => g.count)
                    .ToList()
                    .Take(3);
            }
        }

        private IQueryable<Log> zwrocOdfiltrowaneLogi(converterEntities context)
        {
            IQueryable<Log> log = context.Log.Where(l => l.Typ == l.Typ);
            if (((iKonwerter)FiltrTyp.SelectedItem) != null)
            {
                string typ = ((iKonwerter)FiltrTyp.SelectedItem).ToString();
                log = log.Where(l => l.Typ == typ);
            }

            if (Zakresod.ToString() != null && Zakresod.ToString() != "")
            {
                DateTime zakresod = DateTime.Parse(Zakresod.ToString());
                log = log.Where(l => l.Data > zakresod);
            }

            if (Zakresdo.ToString() != null && Zakresdo.ToString() != "")
            {
                DateTime zakresdo = DateTime.Parse(Zakresdo.ToString());
                log = log.Where(l => l.Data <= zakresdo);
            }

            return log;
        }

        private void LogList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}