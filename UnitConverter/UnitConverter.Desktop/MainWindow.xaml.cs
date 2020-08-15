using System;
using System.Collections.Generic;
using System.Windows;
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
        };

        public MainWindow()
        {
            InitializeComponent();
            ConverterComboBox.ItemsSource = Converters;
        }

        private void SetError(string error)
        {
            OutputTextBlock.Text = "Error: " + error;
        }

        private void SetValue(double value, string unit)
        {
            OutputTextBlock.Text = value.ToString() + " " + unit;
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
                    return;
                }
            }

            SetError("Unit " + u + " not found in any converter");
        }

        public string OtherUnit(string unit, IConverter converter)
        {
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

        private void ConverterSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SetCurrentConverterUnits();
        }

        private void ConvertButtonClick(object sender, RoutedEventArgs e)
        {
            Convert();
        }
    }
}
