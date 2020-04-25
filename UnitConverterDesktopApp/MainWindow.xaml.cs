using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using unit_converter;
using static Common.Controls.Rate;

namespace UnitConverterDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, IConverter> AvailableConverters = new ConverterService().GetConverters();
        
        IConverter SelectedConverter { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Unit Converter";

            ShieldClock.Visibility = Visibility.Hidden;
            MinutePointer.Visibility = Visibility.Hidden;
            HourPointer.Visibility = Visibility.Hidden;

            // Odczytaj ocene aplikacji z bazy danych
            RateControl.RateValue = 4;

            ConvertCommand = new RelayCommand(obj => Convert(), obj =>
               CategoryComboBox.SelectedItem != null &&
               SourceUnitComboBox.SelectedItem != null &&
               TargetUnitComboBox.SelectedItem != null &&
               !string.IsNullOrEmpty(InputValueTextBox.Text)
            );
            ConvertButton.Command = ConvertCommand;

            ShowStatsCommand = new RelayCommand(obj => ShowStats());
            ShowStatsButton.Command = ShowStatsCommand;
        }
        private void CategoryComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            CategoryComboBox.ItemsSource = AvailableConverters.Keys;
        }
        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!SourceUnitComboBox.IsEnabled)
            {
                SourceUnitComboBox.IsEnabled = true;
            }
            if (!TargetUnitComboBox.IsEnabled)
            {
                TargetUnitComboBox.IsEnabled = true;
            }

            SelectedConverter = AvailableConverters[CategoryComboBox.SelectedItem.ToString()];
            SourceUnitComboBox.ItemsSource = SelectedConverter.AvailableUnits;
            TargetUnitComboBox.ItemsSource = SelectedConverter.AvailableUnits;
            
            if (SelectedConverter.Name == "Clock")
            {       
                ShieldClock.Visibility = Visibility.Visible;
                MinutePointer.Visibility = Visibility.Visible;
                HourPointer.Visibility = Visibility.Visible;
                ((Storyboard)Resources["ClockAppear"]).Begin();
            }  
            else
            {
                ((Storyboard)Resources["ClockDisappear"]).Begin();
            }
        }

        public RelayCommand ConvertCommand;
        private void Convert()
        {
            ResultValueTextBlock.Text = "";

            string sourceUnit = SourceUnitComboBox.SelectedItem.ToString();
            string targetUnit = TargetUnitComboBox.SelectedItem.ToString();
            string inputValue = InputValueTextBox.Text;

            if (!SelectedConverter.IsInputValid(inputValue, sourceUnit))
            {
                MessageBox.Show("Invalid value!");
            }
            else
            {  
                var result = SelectedConverter.Convert(sourceUnit, targetUnit, inputValue);
                ResultValueTextBlock.Text = result.ToString();
                        
                Database.InsertResult(
                    SelectedConverter.Name, sourceUnit, targetUnit, inputValue, result.ToString());

                if (SelectedConverter.Name == "Clock")
                {
                    if (DateTime.TryParse(result, out DateTime timeToShow))
                    {
                        MinuteRotation.Angle = timeToShow.Minute * 6.0;
                        HourRotation.Angle = (timeToShow.Hour * 30.0) + (timeToShow.Minute / 60.0 * 30.0);
                    }
                }
            }
        }
        public RelayCommand ShowStatsCommand;
        private void ShowStats()
        {
            StatsWindow statsWindow = new StatsWindow();
            statsWindow.Show();
        }

        private void RateControl_RateValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show((e as RateEventArgs).Value.ToString());
            // zapisujemy do bazy danych wartosc e jako ocene apllikacji
        }
    }
}
