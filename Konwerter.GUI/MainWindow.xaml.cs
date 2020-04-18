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
//using KonwerterJednostek.Logic;

namespace Konwerter.GUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int Length = 5;

        public MainWindow()
        {
            InitializeComponent();
            // static Regex t24regex = new Regex(@"(\d+):(\d+)");
            //KonwerterJednostek.Logic.IKonwerter.Convert;
            //var match = t24regex.Match(valueToConvert);
           // var hour = int.Parse(match.Groups[1].Value);
           // var minute = int.Parse(match.Groups[2].Value);

           // ClockRotate1.Angle = 6750;//24 na 12  Ustawione na wzkazówke 12
           // ClockRotate2.Angle = 4950;//12 na 24  Ustawione na wzkazówke malych 12
            

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

            TBlock24.Text = (string) KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("T24", "T12", TBox24.Text);// wykonanie funkcji 24 to 12
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

        private void PM_Click(object sender, RoutedEventArgs e)
        {
            TBox12.Text = TBox12.Text + "PM";
        }

        private void AM_Click(object sender, RoutedEventArgs e)
        {
            TBox12.Text = TBox12.Text + "AM";
        }

        private void CLEAN_Click(object sender, RoutedEventArgs e)
        {
            TBox12.Text = string.Empty;
            TBox12.Clear();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
