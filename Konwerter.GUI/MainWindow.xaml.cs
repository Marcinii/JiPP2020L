using Common.Controls;
using KonwerterJednostek.Logic;
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
using static KonwerterJednostek.Logic.Dispatcher;


//using KonwerterJednostek.Logic;

namespace Konwerter.GUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int Length = 5;
        BazaKonwerterEntities DBContext = new BazaKonwerterEntities();
        //
        public MainWindow()
        {
            InitializeComponent();

            combo0.ItemsSource = new KonwerterService().GetConverters();

            ConvertCommand = new RelayCommand(
                obj => DoConvert(),
                obj => combo1.SelectedItem != null && combo2.SelectedItem != null && !string.IsNullOrEmpty(box0.Text)
            );
            button0.Command = ConvertCommand;

            // Wczytaj początkową wartość RateValue
            var query = from o in DBContext.Ocena
                        where o.id == 1
                        select o;
            RateControl.RateValue = query.First().Rating;
            // Podłącz się do zdarzenia RateValueChanged
            RateControl.RateValueChanged += onRateValueChanged;
        
        }
        private void onRateValueChanged(object sender, RateEventArgs e)
        {
            var newRating = new Ocena
            {
                id = 1,
                Rating = e.Value
            };
            (from o in DBContext.Ocena
             where o.id == 1
             select o).First().Rating = e.Value;
            //DBContext.SaveChanges();

        }

        private RelayCommand ConvertCommand;

        private void DoConvert()
        {
            var unitFrom = combo1.Text;
            var unitTo = combo2.Text;
            var TYP = DispatchConvert(unitFrom, unitTo);
            var valueFrom = box0.Text;
            var valueTo = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch(unitFrom, unitTo, double.Parse(valueFrom)).ToString() + unitTo;
            var date = DateTime.Now;
            block0.Text = valueTo;
            var record = new TabelaWynikow
            {
                TYP = TYP.Name,
                Jednostka_przed = unitFrom,
                Jednostka_po = unitTo,
                Date = date,
                Wartosc_przed = valueFrom,
                Wartosc_po = valueTo
            };
            DBContext.TabelaWynikow.Add(record);
           // DBContext.SaveChanges();
        }

        private void converterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            combo0.ItemsSource = ((IKonwerter)combo0.SelectedItem).Units;
            combo0.ItemsSource = ((IKonwerter)combo0.SelectedItem).Units;
        }
        private void UnitConv()
        {
            string inputText = box0.Text;
            string inputValue = inputText; // !! TryParse

            string result = ((IKonwerter)combo0.SelectedItem).UnitConv(
                combo1.SelectedItem.ToString(),
                combo2.SelectedItem.ToString(),
                inputValue);

            block0.Text = result.ToString();
        }

        private void combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            box0.Text = "";
            combo1.ItemsSource = ((IKonwerter)combo0.SelectedItem).Units;
            combo2.ItemsSource = ((IKonwerter)combo0.SelectedItem).Units;
            combo1.SelectedIndex = 0;
            combo2.SelectedIndex = 1;
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            string inputText = box0.Text;

            string result = (combo1.SelectedItem != null && combo2.SelectedItem != null) ? ((IKonwerter)combo0.SelectedItem).UnitConv(
                combo1.SelectedItem.ToString(),
                combo2.SelectedItem.ToString(),
                inputText) : Error.Info();
            block0.Text = result;

            if (((IKonwerter)combo0.SelectedItem).Name == "Zegar")
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

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("c", "f", double.Parse(TextBox1.Text)).ToString();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            TextBlock2.Text = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("f", "c", double.Parse(TextBox2.Text)).ToString();

        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            TextBlock3.Text = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("kg", "lb", double.Parse(TextBox3.Text)).ToString();

        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            TextBlock4.Text = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("lb", "kg", double.Parse(TextBox4.Text)).ToString();

        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            TextBlock5.Text = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("km", "mil", double.Parse(TextBox5.Text)).ToString();

        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            TextBlock6.Text = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("mil", "km", double.Parse(TextBox6.Text)).ToString();

        }
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            TextBlock7.Text = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("Pa", "hPa", double.Parse(TextBox7.Text)).ToString();

        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            TextBlock8.Text = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("hPa", "Pa", double.Parse(TextBox8.Text)).ToString();

        }

        public void TButton24_Click(object sender, RoutedEventArgs e)
        {

            //            TBlock24.ItemsSource = new ConverterService().GetConverters();

            ((Storyboard)Resources["Animacja_Zegarow"]).Stop();//Zatrzymanie animacji startowej

            TBlock24.Text = (string)KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("T24", "T12", TBox24.Text);// wykonanie funkcji 24 to 12
            int godzina1 = int.Parse(TBlock24.Text.Substring(0, TBlock24.Text.IndexOf(":")));
            ClockRotate1.Angle = (godzina1 * 30) - 90;

            int minute1 = int.Parse(TBlock24.Text.Substring(3, TBlock24.Text.IndexOf(":")));
            ClockRotate3.Angle = (minute1 * 6) - 90;

        }

        private void TButton12_Click(object sender, RoutedEventArgs e)
        {

            ((Storyboard)Resources["Animacja_Zegarow"]).Stop();

            TBlock12.Text = (string)KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("T12", "T24", TBox12.Text);// wykonanie funkcji 24 to 12
            int godzina2 = int.Parse(TBlock12.Text.Substring(0, TBlock12.Text.IndexOf(":")));
            ClockRotate2.Angle = (godzina2 * 30) - 90;

            int minute2 = int.Parse(TBlock12.Text.Substring(3, TBlock12.Text.IndexOf(":")));
            ClockRotate4.Angle = (minute2 * 6) - 90;
        }

        private void StarsRater_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadToTable()
        {
            Dispatcher.Invoke(() => { ConvertTable.DataContext = DBContext.TabelaWynikow.ToList(); });
        }

        private void LoadToTableTop3()
        {
            Dispatcher.Invoke(() => { ConvertTableTop3.DataContext = DBContext.TabelaWynikow.Take(3).ToList(); });
        }

        private void Sleep()
        {
            Task.Delay(4000).Wait();
        }

        private void button_zaladuj_dane_Click(object sender, RoutedEventArgs e)
        {
            loadDataRectangle.Visibility = Visibility.Visible;
            var task1 = new Task(LoadToTable);
            task1.Start();
            var task2 = new Task(LoadToTableTop3);
            task2.Start();
            var task3 = new Task(Sleep);
            task3.Start();

            Task.WhenAll(task1, task2, task3).ContinueWith(t =>
            {
                Dispatcher.Invoke(() => { loadDataRectangle.Visibility = Visibility.Hidden; });
            });
        }
    }
}