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

namespace Converter.Desktop
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

            LoadingPanel.Visibility = Visibility.Hidden;
            arrows.Visibility = Visibility.Hidden;

            Category.ItemsSource= new List<IConverter>()
            {
                new Temperatura(),
                new Dystans(),
                new Masa(),
                new Powierzchnia(),
                new Zegar()
            };
            FiltrTyp.ItemsSource = Category.ItemsSource;

            using (converterEntities context = new converterEntities())
            {
                List<Rate> rate = context.Rate.ToList();
                if (rate.Count > 0)
                {
                    Console.WriteLine(rate.Last().rate1);
                    rateControl.RateV = rate.Last().rate1.GetValueOrDefault(0); 
                }
                
            };
            
                

            Tarcza.Visibility = Visibility.Hidden;
            Godzinowa.Visibility = Visibility.Hidden;
            Minutowa.Visibility = Visibility.Hidden;


            convertCommand = new RelayCommand(obj => Convert(), obj => UnitFrom.SelectedItem != null && UnitTo.SelectedItem != null && 
                String.IsNullOrEmpty(Toconvert.Text) != true);
            Makeit.Command = convertCommand;

            refreshCommand = new RelayCommand(obj => RefreshClicked());
            RefreshButton.Command = refreshCommand;

            pagebackCommand = new RelayCommand(obj => pageback());
            back.Command = pagebackCommand;

            pagenextCommand = new RelayCommand(obj => pagenext());
            next.Command = pagenextCommand;

            showtop3Command = new RelayCommand(obj => showtop3());
            Top3.Command = showtop3Command;
        }



        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UnitFrom.ItemsSource = ((IConverter)Category.SelectedItem).Units;
            UnitTo.ItemsSource = ((IConverter)Category.SelectedItem).Units;

            Tarcza.Visibility = Visibility.Hidden;
            Godzinowa.Visibility = Visibility.Hidden;
            Minutowa.Visibility = Visibility.Hidden;

            if (((IConverter)Category.SelectedItem).Name == "Zegar")
            {
                Tarcza.Visibility = Visibility.Visible;
                Godzinowa.Visibility = Visibility.Visible;
                Minutowa.Visibility = Visibility.Visible;
                Storyboard sb = this.FindResource("TarczaStory") as Storyboard;
                Storyboard.SetTarget(sb, Tarcza);
                sb.Begin();
            }
        }

        private RelayCommand convertCommand;
        private void Convert()
        {
            if (((IConverter)Category.SelectedItem).Name == "Zegar")
            {
                TimeSpan.TryParse(Toconvert.Text, out TimeSpan ts);
                int hours = ts.Hours;
                int minutes = ts.Minutes;

                string res;
                double hoursConverted = ((Zegar)Category.SelectedItem).convert(hours, UnitFrom.Text, UnitTo.Text);
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
                Minutowa.RenderTransform = new RotateTransform(360/60*minutes);
                Godzinowa.RenderTransform = new RotateTransform(360/12*hours+360.0/60/12*minutes);
            }
            else
            {
                double.TryParse(Toconvert.Text, out double value);
                Converted.Content = ((IConverter)Category.SelectedItem).convert(value, UnitFrom.Text, UnitTo.Text);
            }

            using (converterEntities context = new converterEntities())
            {
                Log log = new Log()
                {

                    typ = ((IConverter)Category.SelectedItem).ToString(),
                    jednostkaz = UnitFrom.Text,
                    jednostkado = UnitTo.Text,
                    data = System.DateTime.Now,
                    wartoscprzed = Toconvert.Text,
                    wartoscpo = Converted.Content.ToString()
                };

                context.Log.Add(log);
                context.SaveChanges();
            }
        }

        private RelayCommand refreshCommand;

        private void RefreshClicked()
        {
            LoadingPanel.Visibility = Visibility.Visible;

            arrows.Visibility = Visibility.Visible;

            Storyboard sb = this.FindResource("LoadingStory") as Storyboard;
            Storyboard.SetTarget(sb, arrows);
            sb.Begin();

            Task t1 = new Task(() => Refresh());

            t1.Start();
        }

        private void Refresh()
        {

            Task.Delay(5000).Wait();

            using (converterEntities context = new converterEntities())
            {
                
                Dispatcher.Invoke(() => {
                    List<Log> logi = zwrocOdfiltrowaneLogi(context).ToList();
                    LogList.ItemsSource = logi.Take(logperpage);
                    maxpage = logi.Count() / 10;
                    LoadingPanel.Visibility = Visibility.Hidden;
                    arrows.Visibility = Visibility.Hidden;
                });              
            }
            strona = 0;
        }

        private void LogList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private RelayCommand pagebackCommand;
        private void pageback()
        {
            strona--;

            using (converterEntities context = new converterEntities())
            {
                LogList.ItemsSource = zwrocOdfiltrowaneLogi(context).ToList().Skip(strona*10).Take(logperpage);
            }
        }

        private RelayCommand pagenextCommand;
        private void pagenext()
        {
            if (strona != maxpage)
            {
                strona++;
            }
            
            using (converterEntities context = new converterEntities())
            {
                LogList.ItemsSource = zwrocOdfiltrowaneLogi(context).ToList().Skip(strona*10).Take(logperpage);
            }
        }

        private RelayCommand showtop3Command;
        private void showtop3()
        {
            using (converterEntities context = new converterEntities())
            {
                LogList.ItemsSource = zwrocOdfiltrowaneLogi(context).GroupBy(l => new { l.typ, l.jednostkaz, l.jednostkado })
                    .Select(g => new { g.Key.typ, g.Key.jednostkaz, g.Key.jednostkado, count = g.Count() })
                    .OrderByDescending(g => g.count)
                    .ToList()
                    .Take(3);
            }
        }

        private IQueryable<Log> zwrocOdfiltrowaneLogi(converterEntities context)
        {
            IQueryable<Log> log = context.Log.Where(l => l.typ == l.typ);
            if (((IConverter)FiltrTyp.SelectedItem) != null)
            {
                string typ = ((IConverter)FiltrTyp.SelectedItem).ToString();
                log = log.Where(l => l.typ == typ);
            }

            if (Zakresod.ToString() != null && Zakresod.ToString() != "")
            {
                DateTime zakresod = DateTime.Parse(Zakresod.ToString());
                log = log.Where(l => l.data > zakresod);
            }

            if (Zakresdo.ToString() != null && Zakresdo.ToString() != "")
            {
                DateTime zakresdo = DateTime.Parse(Zakresdo.ToString());
                log = log.Where(l => l.data <= zakresdo);
            }

            return log;
        }

        private void RateControl_RateChanged(object sender, Converter.Controls.RateArgs e)
        {
            using (converterEntities context = new converterEntities())
            {
                Rate r = new Rate()
                {
                    rate1 = e.Value
                };

                context.Rate.Add(r);
                context.SaveChanges();
            }
        }
    }
}
