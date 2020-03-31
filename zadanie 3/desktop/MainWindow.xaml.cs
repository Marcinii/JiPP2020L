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
using UnitConverter;


namespace desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            converterCombobox.ItemsSource = new List<Interface>()
            {
            new Speed(),
            new Length(),
            new Weight(),
            new Temperature(),
            new Time()
        };
    
        }

        private void converterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFromCombobox.ItemsSource = ((Interface)converterCombobox.SelectedItem).Units;
            unitToCombobox.ItemsSource = ((Interface)converterCombobox.SelectedItem).Units;
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = inputTextbox.Text;
            double inputValue = double.Parse(inputText);
            double result = ((Interface)converterCombobox.SelectedItem).Convert(
                unitFromCombobox.SelectedItem.ToString(),
                unitToCombobox.SelectedItem.ToString(),
                inputValue);

            outputTextBlock.Text = result.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clock.Angle = -240;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            clock.Angle = -210;
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            clock.Angle = -180;
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            clock.Angle = -150;
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            clock.Angle = -120;
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            clock.Angle = -90;
        }

        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            clock.Angle = -60;
        }

        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            clock.Angle = -30;
        }

        private void Button_Click9(object sender, RoutedEventArgs e)
        {
            clock.Angle = 0;
        }

        private void Button_Click10(object sender, RoutedEventArgs e)
        {
            clock.Angle = -330;
        }

        private void Button_Click11(object sender, RoutedEventArgs e)
        {
            clock.Angle = -300;
        }

        private void Button_Click12(object sender, RoutedEventArgs e)
        {
            clock.Angle = 90;
        }
    }
}
