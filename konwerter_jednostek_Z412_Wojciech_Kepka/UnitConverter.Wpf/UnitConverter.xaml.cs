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
using UnitConverter.Lib;
using static UnitConverter.Lib.Units;

namespace UnitConverter.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            converterComboBox.ItemsSource = new List<IConverter> {
                new DistanceConverter(),
                new MassConverter(),
                new TemperatureConverter(),
                new SpeedConverter(),
            };
            
        }

        private void converterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFromComboBox.ItemsSource = ((IConverter)converterComboBox.SelectedItem).SupportedUnits;
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            var inpUnit = (Unit)unitFromComboBox.SelectedItem;
            var inpVal = Double.Parse(inputTextBox.Text);
            var conv = ((IConverter)converterComboBox.SelectedItem);
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
        }
    }
}
