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
using Logic;

namespace Konwerter.Desktop
{
    public partial class MainWindow : Window
    {
        public List<IConverter> converterList = new List<IConverter> {
            new LenghtConversion(),
            new WeightConversion(),
            new TemperatureConversion(),
            new PowerConversion(),
            new TimeConversion()
        };
        IConverter chosenConverter;
        public MainWindow()
        {
            InitializeComponent();
            initConverterBox();
        }

        private void initConverterBox()
        {
            List<string> list = new List<string>();
            foreach (IConverter converter in converterList)
            {
                list.Add(converter.ConverterName);
            }
            converterBox.ItemsSource = list;
        }

        private void converterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int converterIndex = converterBox.SelectedIndex;

            onConvert.IsEnabled = true;
            quantityBox.Text = "0";
            resultLabel.Content = null;

            switch (converterIndex)
            {
                case 0:
                    initLenghtConverter();
                    chosenConverter = converterList[0];
                    break;
                case 1:
                    initWeightConverter();
                    chosenConverter = converterList[1];
                    break;
                case 2:
                    initTemperatureConverter();
                    chosenConverter = converterList[2];
                    break;
                case 3:
                    initPowerConverter();
                    chosenConverter = converterList[3];
                    break;
                case 4:
                    initTimeConverter();
                    chosenConverter = converterList[4];
                    break;
            }
        }
        private void initLenghtConverter()
        {
            converterLabel.Content = "Konwerter odległości";
            convertFrom.ItemsSource = converterList[0].ConverterUnits;
            convertTo.ItemsSource = converterList[0].ConverterUnits;
        }
        private void initWeightConverter()
        {
            converterLabel.Content = "Konwerter wag";
            convertFrom.ItemsSource = converterList[1].ConverterUnits;
            convertTo.ItemsSource = converterList[1].ConverterUnits;

        }
        private void initTemperatureConverter()
        {
            converterLabel.Content = "Konwerter temperatur";
            convertFrom.ItemsSource = converterList[2].ConverterUnits;
            convertTo.ItemsSource = converterList[2].ConverterUnits;
        }

        private void initPowerConverter()
        {
            converterLabel.Content = "Konwerter mocy";
            convertFrom.ItemsSource = converterList[3].ConverterUnits;
            convertTo.ItemsSource = converterList[3].ConverterUnits;
        }

        private void initTimeConverter()
        {
            converterLabel.Content = "Konwerter czasu";
            convertFrom.ItemsSource = converterList[4].ConverterUnits;
            convertTo.ItemsSource = converterList[4].ConverterUnits;
        }

        private void onConvert_Click(object sender, RoutedEventArgs e)
        {
            string quantity = quantityBox.Text;

            if (convertFrom.SelectedItem == null || convertTo.SelectedItem == null || quantityBox.Text == null)
            {
                resultLabel.Content = "Wprowadź potrzebne parametry";
            } 
            else
            {
                string conTo = convertTo.SelectedItem.ToString();
                string conFrom = convertFrom.SelectedItem.ToString();
                resultLabel.Content = chosenConverter.onConvert(quantity, conFrom, conTo);
            }
        }
    }
}
