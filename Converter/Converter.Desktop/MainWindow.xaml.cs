using Converter.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Converter.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public ObservableCollection<string> Names = new ObservableCollection<string>();

        static readonly Dictionary<ConverterType, IConvert> converterMethods = new Dictionary<ConverterType, IConvert>()
        {
            { ConverterType.JOULE, new EnergyConverter() },
            { ConverterType.CALORIES, new EnergyConverter() },
            { ConverterType.FARENHEIT, new TemperatureConverter() },
            { ConverterType.CELSIUS, new TemperatureConverter() },
            { ConverterType.KILOMETER, new Logic.LengthConverter() },
            { ConverterType.MILE, new Logic.LengthConverter() },


        };

        public event PropertyChangedEventHandler PropertyChanged = (sender, evt) => { };

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < converterMethods.Count; i++)
            {
                var element = converterMethods.ElementAt(i);
                Names.Add(EnumUtil.GetDescription(element.Key));
            }
            ComboBox1.ItemsSource = Names; //binding nie działa poprawić w XAML
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConverterType type = EnumUtil.GetValueFromDescription<ConverterType>(ComboBox1.SelectedItem.ToString());
            IConvertable<float> convertable = new ConvertValue<float>(float.Parse(ToConvertValue.Text));
            IConvert convert = converterMethods[type];
            ConvertedValue.Text = convert.convertValue(convertable.getValue(), type).ToString();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
