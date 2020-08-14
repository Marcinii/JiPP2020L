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
using UnitConverter;

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

            Unit.ItemsSource = new List<string>()
            {
                new TemperatureConverter().Name,
                new LenghtConverter().Name,
                new WeightConverter().Name,
                new TimeConverter().Name,
            };

            Clock.Visibility = Visibility.Hidden;
            ClockHour.Visibility = Visibility.Hidden;
            ClockMinute.Visibility = Visibility.Hidden;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            List<IConverter> Converters = new List<IConverter>()
            {
                new TemperatureConverter(),
                new LenghtConverter(),
                new WeightConverter(),
                new TimeConverter(),
            };

            string InputValue = Input.Text;
            string UnitValue = Unit.Text;
            string FromValue = From.Text;
            string ToValue = To.Text;
            string AnswerValue = "";
            for (int i = 0; i < Converters.Count; i++)
            {
                if (Converters[i].Name == UnitValue)
                {
                    AnswerValue = Converters[i].Convert(FromValue, ToValue, InputValue) + "";
                }
            }
            Answer.Text = AnswerValue;

            if ((string)Unit.SelectedItem == "Czas")
            {
                DateTime Time = DateTime.Parse(AnswerValue);

                double Minute = double.Parse(Time.Minute.ToString());
                double MinuteAngle = 6 * Minute;

                double Hour = double.Parse(Time.Hour.ToString());
                double HourAngle = 0.5 * (60 * Minute + Hour);

                clockHourRotation.Angle = HourAngle;
                clockMinuteRotation.Angle = MinuteAngle;
            }
        }

        private void Unit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clock.Visibility = Visibility.Hidden;
            ClockHour.Visibility = Visibility.Hidden;
            ClockMinute.Visibility = Visibility.Hidden;

            List<IConverter> Converters = new List<IConverter>()
            {
                new TemperatureConverter(),
                new LenghtConverter(),
                new WeightConverter(),
                new TimeConverter(),
            };

            List<string> Measurement = new List<string>();

            for (int i = 0; i < Converters.Count; i++)
            {
                if ((string)Unit.SelectedItem == Converters[i].Name)
                {
                    for (int j = 0; j < Converters[i].Units.Count; j++)
                    {
                        Measurement.Add(Converters[i].Units[j]);
                    }
                }
            }
            From.ItemsSource = Measurement;
            To.ItemsSource = Measurement;

            if ((string)Unit.SelectedItem == new TimeConverter().Name)
            {
                Clock.Visibility = Visibility.Visible;
                ClockHour.Visibility = Visibility.Visible;
                ClockMinute.Visibility = Visibility.Visible;
                ((Storyboard)Resources["ClockStart"]).Begin();
            }
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Window_stat subWindow = new Window_stat();
            subWindow.Show();
        }
    }
}