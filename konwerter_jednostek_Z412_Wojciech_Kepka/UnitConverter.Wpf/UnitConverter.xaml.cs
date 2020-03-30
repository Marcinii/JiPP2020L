using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        const int MaxRecordsPerPage = 20;
        List<string> converterNames = new List<string>() {
                "Distance",
                "Mass",
                "Temperature",
                "Speed",
                "Time",
        };
        public MainWindow()
        {
            InitializeComponent();
            converterComboBox.ItemsSource = converterNames;

        }

        private void converterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            inputTextBox.Clear();
            switch (converterComboBox.SelectedItem)
            {
                case "Time":
                    timeConversion = true;
                    unitFromComboBox.ItemsSource = tConv.SupportedUnits;
                    ((Storyboard)FindResource("ShowClock")).Begin();
                    outTextBox.Opacity = 0;
                    break;
                default:
                    timeConversion = false;
                    clockGrid.Opacity = 0;
                    outTextBox.Opacity = 1;
                    foreach (IConverter<double, Unit> conv in converters)
                    {
                        if (converterComboBox.SelectedItem.ToString() == conv.Name)
                        {
                            unitFromComboBox.ItemsSource = conv.SupportedUnits;
                            unitToComboBox.ItemsSource = conv.SupportedUnits;
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

            }
            else
            {
                if (unitFromComboBox.SelectedItem != null
                && unitToComboBox.SelectedItem != null
                && inputTextBox.Text != "")
                {
                    var inpUnit = (Unit)unitFromComboBox.SelectedItem;
                    var outUnit = (Unit)unitToComboBox.SelectedItem;
                    var inpVal = Double.Parse(inputTextBox.Text);
                    foreach (IConverter<double, Unit> conv in converters)
                    {
                        if (conv.Name == converterComboBox.SelectedItem.ToString())
                        {
                            var outVal = conv.Convert(inpVal, inpUnit, outUnit);
                            using (var context = new StatsDB())
                            {
                                context.Records.Add(new Record
                                {
                                    converter = conv.Name,
                                    date = DateTime.Now,
                                    inputValue = inpVal,
                                    inputUnit = UnitName(inpUnit),
                                    outputValue = outVal.Item1,
                                    outputUnit = UnitName(outVal.Item2),
                                });
                                context.SaveChanges();
                            }
                            outTextBox.Text = $"{outVal.Item1} {outVal.Item2}";
                            break;
                        }
                    }
                }
            }
        }

        private void nextPageButton_Click(object sender, RoutedEventArgs e)
        {
            var currentPage = int.Parse(pageNumberTextBlock.Text);
            List<Record> data = SelectRecords(currentPage + 1);

            if (data.Count > 0)
            {
                dbListView.ItemsSource = data;
                pageNumberTextBlock.Text = $"{currentPage + 1}";
            }
        }

        private void previousPageButton_Click(object sender, RoutedEventArgs e)
        {
            var currentPage = int.Parse(pageNumberTextBlock.Text);

            if (currentPage > 1)
            {
                List<Record> data = SelectRecords(currentPage - 1);
                dbListView.ItemsSource = data;
                pageNumberTextBlock.Text = $"{currentPage - 1}";
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;

            if (tabItem == "Statistics")
            {
                List<Record> data = SelectRecords(1);
                converterFilterComboBox.ItemsSource = new List<string> { "" }.Concat(converterNames);
                dbListView.ItemsSource = data;
                LoadTopConversionStats();
            }
        }

        private void LoadTopConversionStats()
        {
            using (var context = new StatsDB())
            {
                var topRecords = context.Records
                    .GroupBy(r => new { r.converter, r.inputUnit, r.outputUnit })
                    .Select(g => new { g.Key.converter, g.Key.inputUnit, g.Key.outputUnit, count = g.Count() })
                    .OrderByDescending(g => g.count)
                    .Take(3);
                topConversionUnitsListView.ItemsSource = topRecords.ToList();
            }
        }

        private List<Record> SelectRecords(int page)
        {
            List<Record> records = new List<Record>();
            if (page >= 1)
            {
                var i = 0;
                var convFilter = converterFilterComboBox.SelectedItem;
                var startDateFilter = startDatePicker.SelectedDate;
                var endDateFilter = endDatePicker.SelectedDate;

                using (var context = new StatsDB())
                {
                    var selectedRecords = context.Records.AsQueryable();
                    if (convFilter != null && convFilter.ToString() != "")
                    {
                        selectedRecords = selectedRecords.Where(r => r.converter == convFilter.ToString());
                    }
                    if (startDateFilter != null)
                    {
                        selectedRecords = selectedRecords.Where(r => DbFunctions.TruncateTime(r.date) >= startDateFilter);
                    }
                    if (endDateFilter != null)
                    {
                        selectedRecords = selectedRecords.Where(r => DbFunctions.TruncateTime(r.date) <= endDateFilter);
                    }
                    foreach (Record r in selectedRecords.ToList())
                    {
                        if (i >= MaxRecordsPerPage * (page - 1))
                        {
                            bool add = true;

                            if (add)
                            {
                                records.Add(r);
                            }
                        }
                        if (records.Count == MaxRecordsPerPage)
                        {
                            break;
                        }
                        i++;
                    }
                }
            }
            return records;
        }
        
        // Restartujemy strony jeżeli wybrano jeden z filtrów
        private void RestartRecordsPage()
        {
            pageNumberTextBlock.Text = "1";
            List<Record> data = SelectRecords(1);
            dbListView.ItemsSource = data;
        }
        private void converterFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RestartRecordsPage();
        }
        private void startDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            RestartRecordsPage();
        }
        private void endDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            RestartRecordsPage();
        }

        private void clearFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            converterFilterComboBox.SelectedIndex = 0;
            startDatePicker.SelectedDate = null;
            endDatePicker.SelectedDate = null;
            RestartRecordsPage();
        }
    }
}
