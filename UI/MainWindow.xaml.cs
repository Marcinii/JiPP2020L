using System.Globalization;
using System.Windows;
using System.Windows.Input;
using Infrastructure;
using Infrastructure.Repositories;
using Logic.Externals;
using Logic.Services;
using Microsoft.EntityFrameworkCore;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataCapacityConvertingService _dataCapacityConvertingService;
        private readonly ConvertingService _convertingService;
        private readonly TimeConvertingService _timeConvertingService;
        private readonly IConversionRepository _conversionRepository;
        public MainWindow()
        {
            InitializeComponent();
            _dataCapacityConvertingService = new DataCapacityConvertingService();
            _convertingService = new ConvertingService();
            _timeConvertingService = new TimeConvertingService();
        }

        public void BitsInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var value = BitsInput.Text;
                var success = int.TryParse(value, NumberStyles.Any, null, out var parseResult);
                if (!success) return;
                _dataCapacityConvertingService.Bits = parseResult;
                SeedDataCapacityInputs(value);
            }
        }


        public void KilobitsInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                var value = KilobitsInput.Text;
                var success = int.TryParse(value, NumberStyles.Any, null, out var parseResult);
                if (!success) return;
                _dataCapacityConvertingService.KiloBits = parseResult;
                SeedDataCapacityInputs(value);
            }
        }

        public void MegabitsInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                var value = MegabitsInput.Text;
                var success = int.TryParse(value, NumberStyles.Any, null, out var parseResult);
                if (!success) return;
                _dataCapacityConvertingService.MegaBits = parseResult;
                SeedDataCapacityInputs(value);
            }
        }

        public void BytesInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                var value = BytesInput.Text;
                var success = int.TryParse(value, NumberStyles.Any, null, out var parseResult);
                if (!success) return;
                _dataCapacityConvertingService.Bytes = parseResult;
                SeedDataCapacityInputs(value);
            }
        }

        public void KilobytesInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                var value = KilobytesInput.Text;
                var success = int.TryParse(value, NumberStyles.Any, null, out var parseResult);
                if (!success) return;
                _dataCapacityConvertingService.KiloBytes = parseResult;
                SeedDataCapacityInputs(value);
            }
        }

        public void MegabytesInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                var value = MegabytesInput.Text;
                var success = int.TryParse(value, NumberStyles.Any, null, out var parseResult);
                if (!success) return;
                _dataCapacityConvertingService.MegaBytes = parseResult;
                SeedDataCapacityInputs(value);
            }
        }

        private void SeedDataCapacityInputs(string value)
        {
            BitsInput.Text = _dataCapacityConvertingService.Bits.ToString("F2");
            KilobitsInput.Text = _dataCapacityConvertingService.KiloBits.ToString("F2");
            MegabitsInput.Text = _dataCapacityConvertingService.MegaBits.ToString("F2");
            BytesInput.Text = _dataCapacityConvertingService.Bytes.ToString("F2");
            KilobytesInput.Text = _dataCapacityConvertingService.KiloBytes.ToString("F2");
            MegabytesInput.Text = _dataCapacityConvertingService.MegaBytes.ToString("F2" );
        }

        public void TemperatureConversionsInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var value = TemperatureConversionsInput.Text;
                var success = int.TryParse(value, NumberStyles.Any, null, out var parseResult);
                if (!success) return;

                if (TemperatureSwitch.IsChecked != null && TemperatureSwitch.IsChecked.Value)
                {
                    var result = _convertingService.ConvertFromFahrenheitToCelsius(parseResult);
                    TemperatureConversionResultLabel.Content = result.ToString("F2") + "*C";
                }
                else
                {
                    var result = _convertingService.ConvertFromCelsiusToFahrenheit(parseResult);
                    TemperatureConversionResultLabel.Content = result.ToString("F2") + "*F";
                }
            }
        }

        public void MiToKmConversionsInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var value = MiToKmConversionsInput.Text;
                var success = int.TryParse(value, NumberStyles.Any, null, out var parseResult);
                if (!success) return;

                if (MiToKmSwitch.IsChecked != null && MiToKmSwitch.IsChecked.Value)
                {
                    var result = _convertingService.ConvertFromKilometersToMiles(parseResult);
                    MiToKmConversionResultLabel.Content = result.ToString("F2") + ("mi");
                }
                else
                {
                    var result = _convertingService.ConvertFromMilesToKilometers(parseResult);
                    MiToKmConversionResultLabel.Content = result.ToString("F2") + "km";
                }
            }
        }

        public void KmToLbConversionsInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var value = KmToLbConversionsInput.Text;
                var success = int.TryParse(value, NumberStyles.Any, null, out var parseResult);
                if (!success) return;

                if (KmToLbSwitch.IsChecked != null && KmToLbSwitch.IsChecked.Value)
                {
                    var result = _convertingService.ConvertFromPoundsToKilograms(parseResult);
                    KmToLbConversionResultLabel.Content = result.ToString("F2") + ("kg");
                }
                else
                {
                    var result = _convertingService.ConvertFromKilogramsToPounds(parseResult);
                    KmToLbConversionResultLabel.Content = result.ToString("F2") + "lb";
                }
            }
        }

        public void MToKmConversionsInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return) return;
            var value = MToKmConversionsInput.Text;
            var success = int.TryParse(value, NumberStyles.Any, null, out var parseResult);
            if (!success) return;

            if (MToKmSwitch.IsChecked != null && MToKmSwitch.IsChecked.Value)
            {
                var result = _convertingService.ConvertFromKilometersToMeters(parseResult);
                MToKmConversionResultLabel.Content = result.ToString("F2") + ("m");
            }
            else
            {
                var result = _convertingService.ConvertFromMetersToKilometers(parseResult);
                MToKmConversionResultLabel.Content = result.ToString("F2") + "km";
            }
        }

        private void TemperatureCheckBoxChanged(object sender, RoutedEventArgs e)
        {
            TemperatureLabel.Content = (TemperatureSwitch.IsChecked != null && TemperatureSwitch.IsChecked.Value)
                ? "Fahrenheit to Celsius"
                : "Celsius to Fahrenheit";
        }

        private void MiToKmCheckBoxChanged(object sender, RoutedEventArgs e)
        {
            MiToKmLabel.Content = (MiToKmSwitch.IsChecked != null && MiToKmSwitch.IsChecked.Value)
                ? "Kilometers to Miles"
                : "Miles to Kilometers";
        }

        private void KmToLbCheckBoxChanged(object sender, RoutedEventArgs e)
        {
            KmToLbLabel.Content = (KmToLbSwitch.IsChecked != null && KmToLbSwitch.IsChecked.Value)
                ? "Pounds to Kilograms"
                : "Kilograms to Pounds";
        }

        private void MToKmCheckBoxChanged(object sender, RoutedEventArgs e)
        {
            MToKmLabel.Content = (MToKmSwitch.IsChecked != null && MToKmSwitch.IsChecked.Value)
                ? "Kilometers to Meters"
                : "Meters to Kilometers";
        }

        public void TimerInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return) return;
            var value = TimerInput.Text;
            var result = _timeConvertingService.Convert(value);
            TimerResultLabel.Content = result.Success ? result.TimeValue : result.Message;
        }
    }
}
