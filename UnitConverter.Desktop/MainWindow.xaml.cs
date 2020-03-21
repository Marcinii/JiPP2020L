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
            typeComboBox.ItemsSource = new List<IConverter>()
            {
                new TemperatureConverter(),
                new WeightConverter(),
                new LengthConverter(),
                new TimeConverter(),
            };
            UnitFrom.Focusable = false;
            UnitTo.Focusable = false;
            UnitFrom.IsHitTestVisible = false;
            UnitTo.IsHitTestVisible = false;
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
        }

        private void UnitFromValue_TextChanged(object sender, TextChangedEventArgs e)
        {
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
