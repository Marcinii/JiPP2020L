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
            combo0.ItemsSource = new ConverterService().GetConverters();
            combo0.SelectedIndex = 4;

            //Watch t = new Watch();
            //int hour = (DateTime.Now).Hour;
            //int minute = (DateTime.Now).Minute;
            //int second = (DateTime.Now).Second;

            //string s1 = hour < 10 ? "0" + hour : hour.ToString();
            //string s2 = minute < 10 ? "0" + minute : minute.ToString();
            //string time = s1 + ":" + s2;

            //string result = t.UnitConv("f", "t", time);

            //bool success0 = double.TryParse(result.Substring(3, 2), out double deg0);
            //if (!success0) { deg0 = 0; }
            //deg0 *= 6;
            //Path pt0 = minutes;
            //RotateTransform rot0 = new RotateTransform(deg0);
            //pt0.RenderTransform = rot0;

            //bool success1 = double.TryParse(result.Substring(0, 2), out double deg1);
            //if (!success1) { deg1 = 0; }
            //deg1 *= 30;
            //deg1 += (deg0 / 12);
            //Path pt1 = hours;
            //RotateTransform rot1 = new RotateTransform(deg1);
            //pt1.RenderTransform = rot1;

            //double deg2 = second * 6;
            //Path pt2 = seconds;
            //RotateTransform rot2 = new RotateTransform(deg2);
            //pt2.RenderTransform = rot2;

            
        }
        
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
            if (((IConverter)combo0.SelectedItem).Name != "Zegar")
            {
                int hour = (DateTime.Now).Hour;
                int minute = (DateTime.Now).Minute;
                int second = (DateTime.Now).Second;
                string s1 = hour < 10 ? "0" + hour : hour.ToString();
                string s2 = minute < 10 ? "0" + minute : minute.ToString();
                string time = s1 + ":" + s2;

                string result = t.UnitConv("f", "t", time);

                bool success0 = double.TryParse(result.Substring(3, 2), out double deg0);
                if (!success0) { deg0 = 0; }
                deg0 *= 6;
                Path pt0 = minutes;
                RotateTransform rot0 = new RotateTransform(deg0);
                pt0.RenderTransform = rot0;

                bool success1 = double.TryParse(result.Substring(0, 2), out double deg1);
                if (!success1) { deg1 = 0; }
                deg1 *= 30;
                deg1 += (deg0 / 12);
                Path pt1 = hours;
                RotateTransform rot1 = new RotateTransform(deg1);
                pt1.RenderTransform = rot1;

                double deg2 = second * 6;
                Path pt2 = seconds;
                RotateTransform rot2 = new RotateTransform(deg2);
                pt2.RenderTransform = rot2;
            }
            else if (((IConverter)combo0.SelectedItem).Name == "Zegar")
            {
                Path pt0 = minutes;
                RotateTransform rot0 = new RotateTransform(0);
                pt0.RenderTransform = rot0;

                Path pt1 = hours;
                RotateTransform rot1 = new RotateTransform(0);
                pt1.RenderTransform = rot1;
                
                Path pt2 = seconds;
                RotateTransform rot2 = new RotateTransform(0);
                pt2.RenderTransform = rot2;
            }
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            string inputText = box0.Text;

            string result = (combo1.SelectedItem!=null && combo2.SelectedItem!=null) ? ((IConverter)combo0.SelectedItem).UnitConv(
                combo1.SelectedItem.ToString(),
                combo2.SelectedItem.ToString(),
                inputText) : Error.Info();
            block0.Text = result;

            if(((IConverter)combo0.SelectedItem).Name == "Zegar")
            {
                bool success0 = double.TryParse(block0.Text.Substring(3, 2), out double deg0);
                if (!success0) { deg0 = 0; }
                deg0 *= 6;
                Path pt0 = minutes;
                RotateTransform rot0 = new RotateTransform(deg0);
                pt0.RenderTransform = rot0;

                bool success1 = double.TryParse(block0.Text.Substring(0, 2), out double deg1);
                if (!success1) { deg1 = 0; }
                deg1 *= 30;
                deg1 += (deg0 / 12);
                Path pt1 = hours;
                RotateTransform rot1 = new RotateTransform(deg1);
                pt1.RenderTransform = rot1;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
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
    }
}
