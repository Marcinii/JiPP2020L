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

            ResultTB.Text = "";

            convertCB.ItemsSource = new ConverterService().GetConverters();
        }

        private void convertCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UnitFromCB.ItemsSource = ((IConverter)convertCB.SelectedItem).Units;
            UnitToCB.ItemsSource = ((IConverter)convertCB.SelectedItem).Units;
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            ResultsPanel.Visibility = Visibility.Visible;

            string textToConvert = ValueToTB.Text;

            decimal valueToConvert = decimal.Parse(textToConvert);

            decimal result = ((IConverter)convertCB.SelectedItem).Converter(
                UnitFromCB.SelectedItem.ToString(),
                UnitToCB.SelectedItem.ToString(),
                valueToConvert);

            //save to sql

            ResultTB.Text = result.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Loader.Visibility = Visibility.Visible;

            Task t1 = new Task(() => LoadStats());
            t1.Start();

            Task.WhenAll(t1).ContinueWith(t =>
            {
                Loader.Visibility = Visibility.Hidden;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void LoadStats()
        {
            List<Statistics> stats = new List<Statistics>();
            stats.Add(new Statistics() { ConvertType = "Wagi", Date = DateTime.Now, Result = 12 });
            stats.Add(new Statistics() { ConvertType = "Długości", Date = DateTime.Now, Result = 2 });

            Task.Delay(2000).Wait();
            Dispatcher.Invoke(() => StatsGrid.ItemsSource = stats);
            Dispatcher.Invoke(() => Loader.Width = 356);
            Task.Delay(500).Wait();
        }
    }
    public class Statistics
    {
        public string ConvertType { get; set; }
        public DateTime Date { get; set; }
        public Decimal Result { get; set; }
    }
}
