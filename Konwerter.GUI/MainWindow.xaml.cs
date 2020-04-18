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
            Watch t = new Watch();
            int hour = (DateTime.Now).Hour;
            int minute = (DateTime.Now).Minute;
            int second = (DateTime.Now).Second;

            Clock_online();

            combo0.ItemsSource = new KonwerterService().GetConverters();
            combo0.SelectedIndex = 0;



            string s1 = hour < 10 ? "0" + hour : hour.ToString();
            string s2 = minute < 10 ? "0" + minute : minute.ToString();
            string time = s1 + ":" + s2;

            string result = t.UnitConv("f", "t", time);

            bool success0 = double.TryParse(result.Substring(3, 2), out double deg0);
            if (!success0) { deg0 = 0; }
            deg0 *= 6;
            //Path pt0 = minutes;
            //RotateTransform rot0 = new RotateTransform(deg0);
            //pt0.RenderTransform = rot0;

            bool success1 = double.TryParse(result.Substring(0, 2), out double deg1);
            if (!success1) { deg1 = 0; }
            deg1 *= 30;
            deg1 += (deg0 / 12);
            //Path pt1 = hours;
            //RotateTransform rot1 = new RotateTransform(deg1);
            //pt1.RenderTransform = rot1;

            //double deg2 = second * 6;
            //Path pt2 = seconds;
            //RotateTransform rot2 = new RotateTransform(deg2);
            //pt2.RenderTransform = rot2;


        }
        bool zegarBefore = false;
        private void combo0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            box0.Text = "";
            Watch t = new Watch();
            if (combo0.SelectedItem.ToString() == t.ToString())
            {
                combo1.ItemsSource = new List<string>()
                {
                    ((IKonwerter)combo0.SelectedItem).Units[0]
                };
                combo2.ItemsSource = new List<string>()
                {
                    ((IKonwerter)combo0.SelectedItem).Units[1]
                };
                combo1.SelectedIndex = 0;
                combo2.SelectedIndex = 0;
            }
            else
            {
                combo1.ItemsSource = ((IKonwerter)combo0.SelectedItem).Units;
                combo2.ItemsSource = ((IKonwerter)combo0.SelectedItem).Units;
                combo1.SelectedIndex = 0;
                combo2.SelectedIndex = 1;
            }
            if (((IKonwerter)combo0.SelectedItem).Name == "Zegar" && !zegarBefore)
            {
                zegarBefore = true;
                Clock_online_stop();
            }
            else if (((IKonwerter)combo0.SelectedItem).Name != "Zegar" && zegarBefore)
            {
                zegarBefore = false;
                Clock_online_restart();
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
            Path sec = Seconds;
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
            Path h1 = hours1;
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
    }
}