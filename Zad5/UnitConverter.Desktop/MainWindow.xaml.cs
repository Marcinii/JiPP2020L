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
using UnitConverter.Logic;
using Stats;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            c1.ItemsSource = new ConverterService().GetConverters();
            c1.SelectedIndex = 0;
            c2.SelectedIndex = 0;
            c3.SelectedIndex = 1;

            rate.RateVal = getRate();

            StatCommand = new RelayCommand(obj => ButtonClicked(obj));
            button_stat.Command = StatCommand;

            ConvertCommand = new RelayCommand(obj => but_Click(), obj => 
                c2.SelectedItem != null && c3.SelectedItem != null &&
                string.IsNullOrEmpty(box.Text) != true);
            but.Command = ConvertCommand;
        }

        private RelayCommand StatCommand;
        private RelayCommand ConvertCommand;

        private void c1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            c2.ItemsSource = ((IConverter)c1.SelectedItem).Units;
            c3.ItemsSource = ((IConverter)c1.SelectedItem).Units;
            c2.SelectedIndex = 0;
            c3.SelectedIndex = 1;
            if (c1.SelectedIndex != 4)
            {
                ((Rectangle)r2).Visibility = Visibility.Hidden;
                ((Rectangle)r1).Visibility = Visibility.Hidden;
                ((Ellipse)el).Visibility = Visibility.Hidden;
            }
            else
            {
                ((Rectangle)r2).Visibility = Visibility.Visible;
                ((Rectangle)r1).Visibility = Visibility.Visible;
                ((Ellipse)el).Visibility = Visibility.Visible;
            }
        }


        private void but_Click()
        {
            if (c1.SelectedIndex != 4) 
            { 
                block.Text = (((IConverter)c1.SelectedItem).Convert(c2.Text, c3.Text, double.Parse((box.Text)))).ToString();
                StatsClass.Insert(((IConverter)c1.SelectedItem).Name.ToString(), c2.Text, c3.Text, DateTime.Now, box.Text, block.Text);
            }
            else
            {
                string czas = box.Text;
                double godzina = double.Parse(czas.Substring(0, 2));
                double minuta = double.Parse(czas.Substring(3, 2));
                double newGodzina = ((IConverter)c1.SelectedItem).Convert(c2.Text, c3.Text, godzina);
                string result;
                if (godzina > 11 && godzina < 24)
                {
                    result = newGodzina.ToString() + czas.Substring(2, 3) + "PM";
                }
                else
                {
                    result = newGodzina.ToString() + czas.Substring(2, 3) + "AM";
                }
                if (!(Char.IsNumber(result[1]))){ result = "0" + result; }
                block.Text = result;

                ((Rectangle)r2).RenderTransform = new RotateTransform(newGodzina * 30);
                ((Rectangle)r1).RenderTransform = new RotateTransform(minuta*6);
                StatsClass.Insert(((UnitConverter.Logic.Zegar)c1.SelectedItem).Name.ToString(), c2.Text, c3.Text, DateTime.Now, box.Text, block.Text);
            }
            
        }
        private void ButtonClicked(object sender)
        {
            Window_stat subWindow = new Window_stat();
            subWindow.Show();
        }

        private void rate_RateValueChanged(object sender, Common.Control.RateEventArgs e)
        {
            Stats.Stats stat = new Stats.Stats();
            stat.converter = "RATE";
            stat.unitIn = "rate";
            stat.unitOut = "rate";
            stat.valueIn = rate.RateVal.ToString();
            stat.valueOut = rate.RateVal.ToString();
            Stats.StatsClass.Insert(stat.converter, stat.unitIn, stat.unitOut, DateTime.Now, stat.valueIn, stat.valueOut);
        }
        private int getRate()
        {
            var r = Stats.StatsClass.GetRate();
            int ret = 0;
            foreach(Stats.Stats a in r)
            {
                ret = int.Parse(a.valueIn);
            }
            return ret;
        }
    }
}
