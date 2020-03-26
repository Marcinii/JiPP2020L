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
using UnitConverter.Lib;
using static UnitConverter.Lib.Units;

namespace UnitConverter.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<IConverter<double, Unit>> converters = new List<IConverter<double, Unit>>
            {
                new DistanceConverter(),
                new MassConverter(),
                new TemperatureConverter(),
                new SpeedConverter(),
            };
        TimeConverter tConv = new TimeConverter();
        bool timeConversion = false;
        double hours; double minutes;
        public MainWindow()
        {
            InitializeComponent();
            converterComboBox.ItemsSource = new List<string>
            {
                "Distance Converter",
                "Mass Converter",
                "Temperature Converter",
                "Speed Converter",
                "Time Converter",
            };


        }

        private void converterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            inputTextBox.Clear();
            switch (converterComboBox.SelectedItem)
            {
                case "Time Converter":
                    timeConversion = true;
                    unitFromComboBox.ItemsSource = tConv.SupportedUnits;
                    ((Storyboard)FindResource("ShowClock")).Begin();
                    outListView.Opacity = 0;
                    break;
                default:
                    timeConversion = false;
                    clockGrid.Opacity = 0;
                    outListView.Opacity = 1;
                    foreach (IConverter<double, Unit> conv in converters)
                    {
                        if ((string)converterComboBox.SelectedItem == conv.Name)
                        {
                            unitFromComboBox.ItemsSource = conv.SupportedUnits;
                            break;
                        }
                    }
                    break;
            }
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            if (timeConversion)
            {
                var inpFormat = (TimeFormat)unitFromComboBox.SelectedItem;
                var inpVal = inputTextBox.Text;
                try
                {
                    var outTime = tConv.Convert(inpVal, inpFormat, OppositeFormat(inpFormat));
                    if (outTime.Item2 == TimeFormat.TwentyFourHour)
                    {
                        var parts = outTime.Item1.Split(' ')[0].Split(':');
                        hours = double.Parse(parts[0]);
                        minutes = double.Parse(parts[1]);

                    }
                    RotateTransform minuteRotation = new RotateTransform
                    {
                        Angle = 360 / (60 / minutes)
                    };
                    TransformGroup minuteTransform = new TransformGroup();
                    minuteTransform.Children.Add(minuteRotation);
                    minutePath.RenderTransform = minuteTransform;

                    RotateTransform hourRotation = new RotateTransform();
                    hourRotation.Angle = 360 / (12 / hours);
                    TransformGroup hourTransform = new TransformGroup();
                    hourTransform.Children.Add(hourRotation);
                    hourPath.RenderTransform = hourTransform;
                }
                catch (InvalidTimeFormat)
                {
                    MessageBox.Show("Invalid time format.\nAvailable formats:\nTwelveHour - 6:30 pm\nTwentyFourHour - 17:30 h");
                }

            } else
            {
                var inpUnit = (Unit)unitFromComboBox.SelectedItem;
                var inpVal = Double.Parse(inputTextBox.Text);
                foreach (IConverter<double, Unit> conv in converters)
                {
                    if (conv.Name == converterComboBox.SelectedItem.ToString())
                    {
                        var outVals = new List<Tuple<double, string>>();
                        foreach (Unit u in conv.SupportedUnits)
                        {
                            if (inpUnit != u)
                            {
                                var outVal = conv.Convert(inpVal, inpUnit, u);
                                outVals.Add(new Tuple<double, string>(outVal.Item1, UnitName(outVal.Item2)));
                            }
                        }
                        outListView.ItemsSource = outVals;
                        break;
                    }
                }
            }
        }
    }
}
