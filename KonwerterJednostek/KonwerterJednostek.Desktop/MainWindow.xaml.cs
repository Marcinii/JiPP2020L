using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using KonwerterJednostek.Logic;

namespace KonwerterJednostek.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();



            //mozemy odczytac z bazy danych wartosc oceny
            int rate;
            using (RateModel context = new RateModel())
            {
                Rate tmp = context.Rate.First(a => a.id == 1);
                rate = tmp.value;
            }
                
            rateControl.RateValue = rate;

            ConvertCommand = new RelayCommand(obj => Convert(),
                            obj => combo1.SelectedItem != null &&
                            combo2.SelectedItem != null &&
                            string.IsNullOrEmpty(box0.Text) != true);
            button0.Command = ConvertCommand;

            cc1 = new RelayCommand(obj => Button1(),
                                    obj => string.IsNullOrEmpty(block0.Text) != true);
            button1.Command = cc1;

            
            cc2 = new RelayCommand(obj => SubmitFilters1(),
                                obj => string.IsNullOrEmpty(page.Text) != true &&
                                int.TryParse(page.Text, out int pageNumber) == true &&
                                pageNumber > 0);
            pageBut.Command = cc2;

            cc3 = new RelayCommand(obj => SubmitFilters1(),
                                obj => float.TryParse(type.Text, out float term) != true);
            typeBut.Command = cc3;

            cc4 = new RelayCommand(obj => SubmitFilters1(),
                                obj => fromDate.SelectedDate != null &&
                                toDate.SelectedDate != null);
            dateBut.Command = cc4;

            if (true)
            {
                Watch t = new Watch();
                int hour = (DateTime.Now).Hour;
                int minute = (DateTime.Now).Minute;

                Clock_online();

                combo0.ItemsSource = new ConverterService().GetConverters();
                combo0.SelectedIndex = 0;



                string s1 = hour < 10 ? "0" + hour : hour.ToString();
                string s2 = minute < 10 ? "0" + minute : minute.ToString();
                string time = s1 + ":" + s2;

                string result = t.UnitConv("f", "t", time);

                bool success0 = double.TryParse(result.Substring(3, 2), out double deg0);
                if (!success0) { deg0 = 0; }
                deg0 *= 6;

                bool success1 = double.TryParse(result.Substring(0, 2), out double deg1);
                if (!success1) { deg1 = 0; }
                //InsertTEST();

                DateTime from = new DateTime(1980, 1, 1);
                DateTime to = new DateTime(2050, 1, 1);

                int.TryParse(page.Text, out int pageINT);
                DisplayDataUsingEF(popular, dg, pageINT, from, to, type.Text);
            }
        }

        private RelayCommand ConvertCommand;
        private RelayCommand cc1;
        private RelayCommand cc2;
        private RelayCommand cc3;
        private RelayCommand cc4;

        bool zegarBefore = false;
        private void combo0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            box0.Text = "";
            Watch t = new Watch();
            if (combo0.SelectedItem.ToString() == t.ToString())
            {
                combo1.ItemsSource = new List<string>()
                {
                    ((IConverter)combo0.SelectedItem).Units[0]
                };
                combo2.ItemsSource = new List<string>()
                {
                    ((IConverter)combo0.SelectedItem).Units[1]
                };
                combo1.SelectedIndex = 0;
                combo2.SelectedIndex = 0;
            }
            else
            {
                combo1.ItemsSource = ((IConverter)combo0.SelectedItem).Units;
                combo2.ItemsSource = ((IConverter)combo0.SelectedItem).Units;
                combo1.SelectedIndex = 0;
                combo2.SelectedIndex = 1;
            }
            if (((IConverter)combo0.SelectedItem).Name == "Zegar" && !zegarBefore)
            {
                zegarBefore = true;
                Clock_online_stop();
            }
            else if (((IConverter)combo0.SelectedItem).Name!="Zegar" && zegarBefore)
            {
                zegarBefore = false;
                Clock_online_restart();
            }
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            Convert();
            
            
        }
        private void Convert()
        {
            string inputText = box0.Text;

            string result = (combo1.SelectedItem != null && combo2.SelectedItem != null) ? ((IConverter)combo0.SelectedItem).UnitConv(
                combo1.SelectedItem.ToString(),
                combo2.SelectedItem.ToString(),
                inputText) : Error.Info();
            block0.Text = result;

            if (((IConverter)combo0.SelectedItem).Name == "Zegar")
            {
                bool success0 = double.TryParse(block0.Text.Substring(3, 2), out double deg0);
                if (!success0) { deg0 = 0; }
                deg0 *= 6;
                Path pt0 = minutes1;
                RotateTransform rot0 = new RotateTransform(deg0);
                pt0.RenderTransform = rot0;

                bool success1 = double.TryParse(block0.Text.Substring(0, 2), out double deg1);
                if (!success1) { deg1 = 0; }
                deg1 *= 30;
                deg1 += (deg0 / 12);
                Path pt1 = hours1;
                RotateTransform rot1 = new RotateTransform(deg1);
                pt1.RenderTransform = rot1;
            }
            if (false) { }
            InsertDataUsingEF
                (((IConverter)combo0.SelectedItem).Name,
                combo1.SelectedItem.ToString(),
                combo2.SelectedItem.ToString(),
                box0.Text,
                block0.Text);
        }
        private void Button1()
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void SubmitFilters1()
        {
            int.TryParse(page.Text, out int pageINT);
            DisplayDataUsingEF(popular, dg, pageINT, (DateTime)fromDate.SelectedDate, (DateTime)toDate.SelectedDate, type.Text);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Button1();
        }

        private void box0_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                button0_Click(null, null);
            }
            else if (e.Key == Key.Escape)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }
        
        public void Clock_online()
        {
            int hour = (DateTime.Now).Hour;
            int minute = (DateTime.Now).Minute;
            int second = (DateTime.Now).Second;

            EasingDoubleKeyFrame keyFrame0 = ((this.Resources["sb0"]
            as Storyboard).Children[0]
            as DoubleAnimationUsingKeyFrames).KeyFrames[0]
            as EasingDoubleKeyFrame;

            EasingDoubleKeyFrame keyFrame1 = ((this.Resources["sb0"]
            as Storyboard).Children[0]
            as DoubleAnimationUsingKeyFrames).KeyFrames[1]
            as EasingDoubleKeyFrame;

            second += 1;
            keyFrame0.Value = second * 6;
            keyFrame1.Value = second * 6 + 360;

            EasingDoubleKeyFrame keyFrame2 = ((this.Resources["msb0"]
            as Storyboard).Children[0]
            as DoubleAnimationUsingKeyFrames).KeyFrames[0]
            as EasingDoubleKeyFrame;

            EasingDoubleKeyFrame keyFrame3 = ((this.Resources["msb0"]
            as Storyboard).Children[0]
            as DoubleAnimationUsingKeyFrames).KeyFrames[1]
            as EasingDoubleKeyFrame;

            keyFrame2.Value = minute * 6;
            keyFrame3.Value = minute * 6 + 6;
            keyFrame3.KeyTime = TimeSpan.FromSeconds(60 - second);

            EasingDoubleKeyFrame keyFrame4 = ((this.Resources["msb1"]
            as Storyboard).Children[0]
            as DoubleAnimationUsingKeyFrames).KeyFrames[0]
            as EasingDoubleKeyFrame;

            EasingDoubleKeyFrame keyFrame5 = ((this.Resources["msb1"]
            as Storyboard).Children[0]
            as DoubleAnimationUsingKeyFrames).KeyFrames[1]
            as EasingDoubleKeyFrame;

            EasingDoubleKeyFrame keyFrame6 = ((this.Resources["msb1"]
            as Storyboard).Children[0]
            as DoubleAnimationUsingKeyFrames).KeyFrames[2]
            as EasingDoubleKeyFrame;

            keyFrame4.Value = minute * 6 + 6;
            keyFrame4.KeyTime = new TimeSpan(0, 0, 0, 0);
            keyFrame5.Value = minute * 6 + 6;
            keyFrame5.KeyTime = new TimeSpan(0, 0, 0, 60 - second);
            keyFrame6.Value = minute * 6 + 366;
            keyFrame6.KeyTime = new TimeSpan(0, 1, 0, 60 - second);

            EasingDoubleKeyFrame keyFrame7 = ((this.Resources["hsb0"]
            as Storyboard).Children[0]
            as DoubleAnimationUsingKeyFrames).KeyFrames[0]
            as EasingDoubleKeyFrame;

            EasingDoubleKeyFrame keyFrame8 = ((this.Resources["hsb0"]
            as Storyboard).Children[0]
            as DoubleAnimationUsingKeyFrames).KeyFrames[1]
            as EasingDoubleKeyFrame;

            keyFrame7.Value = hour * 30 + minute * 6 / 12;
            keyFrame8.Value = hour * 30 + minute * 6 / 12 + 0.5;
            keyFrame8.KeyTime = TimeSpan.FromSeconds(60 - second);

            EasingDoubleKeyFrame keyFrame9 = ((this.Resources["hsb1"]
            as Storyboard).Children[0]
            as DoubleAnimationUsingKeyFrames).KeyFrames[0]
            as EasingDoubleKeyFrame;

            EasingDoubleKeyFrame keyFrame10 = ((this.Resources["hsb1"]
            as Storyboard).Children[0]
            as DoubleAnimationUsingKeyFrames).KeyFrames[1]
            as EasingDoubleKeyFrame;

            EasingDoubleKeyFrame keyFrame11 = ((this.Resources["hsb1"]
            as Storyboard).Children[0]
            as DoubleAnimationUsingKeyFrames).KeyFrames[2]
            as EasingDoubleKeyFrame;

            keyFrame9.Value = hour * 30 + minute * 6 / 12 + 0.5;
            keyFrame9.KeyTime = new TimeSpan(0, 0, 0, 0);
            keyFrame10.Value = hour * 30 + minute * 6 / 12 + 0.5;
            keyFrame10.KeyTime = new TimeSpan(0, 0, 0, 60 - second);
            keyFrame11.Value = hour * 30 + minute * 6 / 12 + 360.5;
            keyFrame11.KeyTime = new TimeSpan(0, 24, 0, 60 - second);
        }
        public void Clock_online_stop()
        {
            Path sec = seconds;
            Path m = minutes;
            Path h = hours;
            Path m1 = minutes1;
            Path h1 = hours1;
            sec.Visibility = Visibility.Hidden;
            m.Visibility = Visibility.Hidden;
            h.Visibility = Visibility.Hidden;
            m1.Visibility = Visibility.Visible;
            h1.Visibility = Visibility.Visible;

        }
        public void Clock_online_restart()
        {
            Path sec = seconds;
            Path m = minutes;
            Path h = hours;
            Path m1 = minutes1;
            Path h1= hours1;
            sec.Visibility = Visibility.Visible;
            m.Visibility = Visibility.Visible;
            h.Visibility = Visibility.Visible;
            m1.Visibility = Visibility.Hidden;
            h1.Visibility = Visibility.Hidden;

            Path pt0 = minutes1;
            RotateTransform rot0 = new RotateTransform(0);
            pt0.RenderTransform = rot0;

            Path pt1 = hours1;
            RotateTransform rot1 = new RotateTransform(0);
            pt1.RenderTransform = rot1;
        }

        public static void DisplayDataUsingEF(DataGrid popular, DataGrid dg, int page, DateTime fromDate, DateTime toDate, string Type)
        {
            using (StatsEntities context = new StatsEntities())
            {
                List<Stats> stats = context.Stats
                    .Where(s => s.Date >= fromDate && s.Date < toDate && s.Type.StartsWith(Type))
                    .OrderBy(s => s.Id)
                    .Skip((page - 1) * 10)
                    .Take(10)
                    .ToList();
                dg.DataContext = stats;

                List<Stats> term = context.Stats
                    .Where(s => s.Date >= fromDate && s.Date < toDate && s.Type.StartsWith(Type))
                    .ToList();

                List<string> pop = term.Select(s => s.Type).ToList();

                popular.ItemsSource = term.GroupBy(l => new { l.Type, l.UnitFrom, l.UnitTo })
                    .Select(g => new { g.Key.Type, g.Key.UnitFrom, g.Key.UnitTo, count = g.Count() })
                    .OrderByDescending(g => g.count)
                    .ToList()
                    .Take(3);
            }
        }
        public static void InsertDataUsingEF(string Type,string UnitFrom, string UnitTo, string Value, string Result)
        {
            using (StatsEntities context = new StatsEntities())
            {
                Stats newConversion = new Stats()
                {
                    Type = Type,
                    UnitFrom = UnitFrom,
                    UnitTo = UnitTo,
                    Date = DateTime.Now,
                    Value = Value,
                    Result = Result
                };
                context.Stats.Add(newConversion);
                context.SaveChanges();
            }
        }
        public static void InsertTEST()
        {
            using (StatsEntities context = new StatsEntities())
            {
                Stats newConversion = new Stats()
                {
                    Type = "Waga",
                    UnitFrom = "24-hour",
                    UnitTo = "12-hour",
                    Date = new DateTime(2020,1,22),
                    Value = "15:15",
                    Result = "03:15PM"
                };
                context.Stats.Add(newConversion);
                context.SaveChanges();
            }
        }
        private void submitFilters(object sender,RoutedEventArgs e)
        {
            SubmitFilters1();
        }
        private void submitFilters_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                submitFilters(null, null);
            }
        }

        private void rateControl_RateValueChanged(object sender, Common.Controls.RateMe.RateEventArgs e)
        {
            // e.Value
            //zapisać do bazy zmieniona wartosc do bazy
            using (RateModel context = new RateModel())
            {
                var rate = context.Rate.First(a => a.id == 1);
                if (rate.value != e.Value) { rate.value = e.Value; }
                else { rate.value = 0; }
                context.SaveChanges();
            }
        }
    }
}
