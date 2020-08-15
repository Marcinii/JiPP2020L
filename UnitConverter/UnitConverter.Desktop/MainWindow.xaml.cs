﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using UnitConverter.Library;

namespace UnitConverter.Desktop
{
    public partial class MainWindow : Window
    {
        private List<IConverter> Converters => new List<IConverter>
        {
            new DistanceConverter(),
            new WeightConverter(),
            new TemperatureConverter(),
            new PressureConverter(),
            new TimeConverter(),
        };
        private int CurrentPage = 1;

        public MainWindow()
        {
            InitializeComponent();
            ConverterComboBox.ItemsSource = Converters;
            ConverterStatsComboBox.ItemsSource = Converters;
        }

        private void SetError(string error)
        {
            OutputTextBlock.Text = "Error: " + error;
        }

        private void SetValue(double value, string unit)
        {
            OutputTextBlock.Text = value.ToString() + " " + unit;
        }

        private string CurrentConverter()
        {
            return ((IConverter)ConverterComboBox.SelectedItem).Name;
        }

        private void Convert()
        {
            var valText = ValueTextBox.Text;
            var unit = InputUnitComboBox.SelectedItem;
            double val;
            try
            {
                val = Double.Parse(valText);
            }
            catch (FormatException)
            {
                SetError("Invalid value '" + valText + "'");
                return;
            }

            if (unit == null)
            {
                SetError("No unit selected");
                return;
            }

            var u = unit.ToString();

            foreach (IConverter converter in Converters)
            {
                if (converter.Units.Contains(u))
                {
                    var outValue = converter.Convert(val, u);
                    SetValue(outValue, OtherUnit(u, converter));
                    SaveResultToDb(val, outValue, u, OtherUnit(u, converter), converter.Name);
                    if (converter.Name == "Time")
                    {
                        SetClockHour(outValue);
                    }
                    return;
                }
            }

            SetError("Unit " + u + " not found in any converter");
        }

        public string OtherUnit(string unit, IConverter converter)
        {
            if (converter.Name == "Time")
            {
                return "";
            }
            foreach (string u in converter.Units)
            {
                if (u != unit)
                {
                    return u;
                }
            }
            return unit;
        }

        private void SetCurrentConverterUnits()
        {
            var converter = (IConverter)ConverterComboBox.SelectedItem;
            InputUnitComboBox.ItemsSource = converter.Units;
        }

        private void ShowClockAnimation()
        {
            var animation = (Storyboard)FindResource("ShowClock");
            animation.Begin();
        }

        private void SetClockHour(double hour)
        {
            RotateTransform setHour = new RotateTransform();
            setHour.Angle = hour * 30;
            HourPath.RenderTransform = setHour;
        }

        private void ConverterSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SetCurrentConverterUnits();
            if (CurrentConverter() == "Time")
            {
                ShowClockAnimation();
            }
        }

        private void ConvertButtonClick(object sender, RoutedEventArgs e)
        {
            Convert();
        }


        private void SaveResultToDb(double inputValue, double outputValue, string inputUnit, string outputUnit, string converter)
        {
            try
            {
                using (var db = new StatisticsTableModel())
                {
                    db.Statistics.Add(new Statistic
                    {
                        Converter = converter,
                        Value = inputValue,
                        Unit = inputUnit,
                        OutputValue = outputValue,
                        OutputUnit = outputUnit,
                        Date = DateTime.Now,
                    });
                    db.SaveChanges();
                }
            }
            catch (InvalidOperationException _)
            {
            }
        }

        private IQueryable<Statistic> AddFilters(IQueryable<Statistic> select, DateTime? startDate, DateTime? endDate)
        {
            if (startDate != null)
            {
                select = select.Where(s => s.Date >= startDate.Value);
            }
            if (endDate != null)
            {
                select = select.Where(s => s.Date >= endDate.Value);
            }

            return select;
        }

        private List<Statistic> LoadStatsFromDb(string converter, DateTime? startDate, DateTime? endDate, int page)
        {
            try
            {
                using (var db = new StatisticsTableModel())
                {
                    var select = db.Statistics.Where(s => s.Converter == converter);
                    AddFilters(select, startDate, endDate);
                    return select.OrderBy(s => s.Id).Skip(20*(page-1)).ToList();
                }
            }
            catch (InvalidOperationException _)
            {
                SetError("Failed loading data from database");
                return new List<Statistic> { };
            }
        }

        private void SetCurrentPageLabel()
        {
            PageLabel.Content = CurrentPage.ToString();
        }

        private void IncPage()
        {
            CurrentPage++;
            SetCurrentPageLabel();
        }
        private void DecPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                SetCurrentPageLabel();
            }
        }

        private void ReloadStatisticsView()
        {
            var startDate = StartDatePicker.SelectedDate;
            var endDate = EndDatePicker.SelectedDate;
            var converter = ((IConverter)ConverterStatsComboBox.SelectedItem).Name;
            var stats = LoadStatsFromDb(converter, startDate, endDate, CurrentPage);
            StatsListView.ItemsSource = stats;
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            DecPage();
            ReloadStatisticsView();
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            IncPage();
            ReloadStatisticsView();
        }

        private void LoadStatsButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadStatisticsView();
        }
    }
}
