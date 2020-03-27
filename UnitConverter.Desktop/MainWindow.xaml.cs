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
using System.Windows.Media.Animation;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ellipse Clock = new Ellipse();
        Line Hours = new Line();
        Line Minutes = new Line();

        private Storyboard toggleClock;

        public MainWindow()
        {
            InitializeComponent();
            typeComboBox.ItemsSource = new List<IConverter>()
            {
                new TemperatureConverter(),
                new WeightConverter(),
                new LengthConverter(),
                new TimeConverter(),
                new ClockConverter(),
            };
            UnitFrom.Focusable = false;
            UnitTo.Focusable = false;
            UnitFrom.IsHitTestVisible = false;
            UnitTo.IsHitTestVisible = false;

            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromRgb(255, 255, 255);
            Clock.Fill = mySolidColorBrush;
            Clock.Height = 88;
            Clock.Width = 88;
            Clock.Stroke = Brushes.Black;
            Clock.Name = "Clock";
            Thickness margin = Clock.Margin;
            margin.Left = 289;
            Clock.Margin = margin;

            Minutes.Stroke = Brushes.Black;
            Minutes.HorizontalAlignment = HorizontalAlignment.Left;
            Minutes.VerticalAlignment = VerticalAlignment.Center;
            Minutes.X1 = 337;
            Minutes.X2 = 337;
            Minutes.Y1 = 0;
            Minutes.Y2 = -40;
            Minutes.StrokeThickness = 2;

            Hours.Stroke = Brushes.Black;
            Hours.HorizontalAlignment = HorizontalAlignment.Left;
            Hours.VerticalAlignment = VerticalAlignment.Center;
            Hours.X1 = 337;
            Hours.X2 = 337;
            Hours.Y1 = 0;
            Hours.Y2 = -25;
            Hours.StrokeThickness = 4;
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Main.Width = 300;
            Grid.Children.Remove(Clock);
            Grid.Children.Remove(Minutes);
            Grid.Children.Remove(Hours);

            UnitToValue.Text = "";
            UnitFromValue.Text = "";
            UnitFrom.ItemsSource = ((IConverter)typeComboBox.SelectedItem).Units;
            UnitTo.ItemsSource = ((IConverter)typeComboBox.SelectedItem).Units;
            UnitFrom.SelectedItem = ((IConverter)typeComboBox.SelectedItem).Units.First();
            UnitTo.SelectedItem = ((IConverter)typeComboBox.SelectedItem).Units.First();
            UnitFrom.Focusable = true;
            UnitTo.Focusable = true;
            UnitFrom.IsHitTestVisible = true;
            UnitTo.IsHitTestVisible = true;
            if (typeComboBox.SelectedItem.ToString() == "UnitConverter.ClockConverter")
            {
                Main.Width = 400;
                UnitFrom.ItemsSource = new List<string> { "24-hour" };
                UnitFrom.SelectedItem = "24-hour";
                UnitFrom.Focusable = false;
                UnitFrom.IsHitTestVisible = false;

                Grid.Children.Add(Clock);
                Grid.Children.Add(Minutes);
                Grid.Children.Add(Hours);
            }
        }

        private void UnitFromValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (typeComboBox.SelectedItem.ToString() == "UnitConverter.ClockConverter")
            {
                char[] separator = { ':', '-' };
                string[] time = UnitFromValue.Text.Split(separator);
                double hours;
                if (double.TryParse(time[0], out hours))
                {
                  
                    Console.WriteLine(hours);
                    double result = ((IConverter)typeComboBox.SelectedItem)
                        .convert("24-hour", "12-hour", hours);
                    string hourString = result.ToString();
                    string minuteString = time.Length > 1 ? $":{time[1]}" : "";
                    string suffixString = hours > 12 ? "pm" : "am";
                    Console.WriteLine(suffixString);
                    UnitToValue.Text = $"{hourString}{minuteString} {suffixString}";
                    RotateTransform rotateHours = new RotateTransform(hours * 30, 337, 0);
                    Hours.RenderTransform = rotateHours;
                    if (time.Length > 1)
                    {
                        double minutes;
                        if (double.TryParse(time[1], out minutes))
                        {
                            RotateTransform rotateMinutes = new RotateTransform(minutes * 6, 337, 0);
                            Minutes.RenderTransform = rotateMinutes;
                        }
                    }
                }
                return;

            }
            double value;
            if (double.TryParse(UnitFromValue.Text, out value))
            {
                double result = ((IConverter)typeComboBox.SelectedItem)
                    .convert(UnitFrom.SelectedItem.ToString(), UnitTo.SelectedItem.ToString(), value);
                UnitToValue.Text = result.ToString();
            }
        }

        private void UnitFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double value;
            if (double.TryParse(UnitFromValue.Text, out value))
            {
                double result = ((IConverter)typeComboBox.SelectedItem)
                    .convert(UnitFrom.SelectedItem.ToString(), UnitTo.SelectedItem.ToString(), value);
                UnitToValue.Text = result.ToString();
            }
        }
        private void UnitTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double value;
            if (double.TryParse(UnitFromValue.Text, out value))
            {
                double result = ((IConverter)typeComboBox.SelectedItem)
                    .convert(UnitFrom.SelectedItem.ToString(), UnitTo.SelectedItem.ToString(), value);
                UnitToValue.Text = result.ToString();
            }
        }
    }
}
