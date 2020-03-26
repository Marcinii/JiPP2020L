using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using UnitConverter.Logic;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool ruch = false;

        public MainWindow()
        {
            InitializeComponent();
            converterCombobox.ItemsSource = new ConverterService().GetConverters();
        }

        private void converterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFromCombobox.ItemsSource = ((IConverter)converterCombobox.SelectedItem).Units;
            unitToCombobox.ItemsSource = ((IConverter)converterCombobox.SelectedItem).Units;
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = inputTextBox.Text;
            string inputValue = System.Convert.ToString(inputText);

            string result = ((IConverter)converterCombobox.SelectedItem).Convert(
                unitFromCombobox.SelectedItem.ToString(),
                unitToCombobox.SelectedItem.ToString(),
                inputValue);
            outputTextBlock.Text = result.ToString();

            if (Convert.ToString(unitFromCombobox.SelectedItem) == "24" && Convert.ToString(unitToCombobox.SelectedItem) == "12")
            {
                double x, y;
                
                int index = result.IndexOf(":");
                if (index == 1)
                {
                     x = Convert.ToDouble(result.Substring(0, 1));
                     y = Convert.ToDouble(result.Substring(2, 2));
                }
                else
                {
                     x = Convert.ToDouble(result.Substring(0, 2));
                     y = Convert.ToDouble(result.Substring(3, 2));
                }
                
                x = x * 30 + 90;
                y = y * 6 + 90;
                
                Pokaz_Zegar(x,y);
            }
        }
        private void Pokaz_Zegar( double min, double hour)
        {
            WskHour.Angle = hour;
            WskMin.Angle = min;
        }
    }
}
