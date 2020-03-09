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
using konwerter;

namespace Konwerter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<IConverter> converters = new List<IConverter>()
            {
                new MassConv(),
                new TemperatureConv(),
                new LenghConv(),
                new StorageConv()
            };
        public MainWindow()
        {
            InitializeComponent();
            From_ChoiseMassUnitComboBox.ItemsSource = converters[0].Units;
            To_ChoiseMassUnitComboBox.ItemsSource = converters[0].Units;
            From_ChoiseTempUnitComboBox.ItemsSource = converters[1].Units;
            To_ChoiseTempUnitComboBox.ItemsSource = converters[1].Units;            
            From_ChoiseLenghUnitComboBox.ItemsSource = converters[2].Units;
            To_ChoiseLenghUnitComboBox.ItemsSource = converters[2].Units;
            From_ChoiseDataUnitComboBox.ItemsSource = converters[3].Units;
            To_ChoiseDataUnitComboBox.ItemsSource = converters[3].Units;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }        
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Temp_Tab.IsSelected)
            {               
                string inputValueTemp = InputTempTextBox.Text;
                decimal value_Temp;
                if (decimal.TryParse(inputValueTemp, out value_Temp) == true)
                {
                    converters[1].Data_and_convert(From_ChoiseTempUnitComboBox.Text, To_ChoiseTempUnitComboBox.Text, value_Temp);
                    ResultTempTextBlock.Text = Math.Round(converters[1].Convert(), 4, MidpointRounding.AwayFromZero).ToString();
                }
                else
                {
                    ResultTempTextBlock.Text = "Error";
                    MessageBox.Show("Podaj poprawną wartość liczbową");
                }
            }
            if (Mass_Tab.IsSelected)
            {
                string inputValueMass = InputMassTextBox.Text;
                decimal value_Mass;
                if (decimal.TryParse(inputValueMass, out value_Mass) == true)
                {
                    converters[0].Data_and_convert(From_ChoiseMassUnitComboBox.Text, To_ChoiseMassUnitComboBox.Text, value_Mass);
                    ResultMassTextBlock.Text = Math.Round(converters[0].Convert(), 4, MidpointRounding.AwayFromZero).ToString();
                }
                else
                {
                    ResultMassTextBlock.Text = "Error";
                    MessageBox.Show("Podaj poprawną wartość liczbową");
                }
            }
            if (Lenhg_Tab.IsSelected)
            {
                string inputValueLengh = InputLenghTextBox.Text;
                decimal value_Lengh;
                if (decimal.TryParse(inputValueLengh, out value_Lengh) == true)
                {
                    converters[2].Data_and_convert(From_ChoiseLenghUnitComboBox.Text, To_ChoiseLenghUnitComboBox.Text, value_Lengh);
                    ResultLenghTextBlock.Text = Math.Round(converters[2].Convert(), 4, MidpointRounding.AwayFromZero).ToString();
                }
                else
                {
                    ResultLenghTextBlock.Text = "Error";
                    MessageBox.Show("Podaj poprawną wartość liczbową");
                }
            }
            if (Data_Tab.IsSelected)
            {
                string inputValueData = InputDataTextBox.Text;
                decimal value_Data;
                if (decimal.TryParse(inputValueData, out value_Data) == true)
                {
                    converters[3].Data_and_convert(From_ChoiseDataUnitComboBox.Text, To_ChoiseDataUnitComboBox.Text, value_Data);
                    ResultDataTextBlock.Text = Math.Round(converters[3].Convert(), 4, MidpointRounding.AwayFromZero).ToString();
                }
                else
                {
                    ResultDataTextBlock.Text = "Error";
                    MessageBox.Show("Podaj poprawną wartość liczbową");
                }
            }
        }
    }
}
