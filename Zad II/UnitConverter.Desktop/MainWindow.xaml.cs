using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
