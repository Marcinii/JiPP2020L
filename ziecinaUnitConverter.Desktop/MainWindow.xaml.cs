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
using ziecina_zad1;

namespace ziecinaUnitConverter.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<IConverter> converters;
        public static int chosenConverter;

        public MainWindow()
        {
            InitializeComponent();
            converters = new List<IConverter>()
            {
                new ConvertTemperature(),
                new ConvertMass(),
                new ConvertLength(),
                new ConvertVolume()
            };
            for (int i = 0; i < converters.Count; i++)
            {
                listConverters.Items.Add(converters[i].Name);
            }
        }

        private void textValues_KeyUp(object sender, KeyEventArgs e)
        {
            string input = textValues.Text;
            try
            {
                float whateva = Convert.ToSingle(input);
                //blockResault.Text = "k liczba";
                float toDisplay = MainWindow.converters[chosenConverter].Convert(listStartUnit.SelectedItem.ToString(), listEndUnit.SelectedItem.ToString(), input);
                string toDisplayStr = toDisplay.ToString();
                blockResault.Text = toDisplayStr;
            }
            catch
            {
                blockResault.Text = "Niepoprawne dane";
            }
        }

        private void listConverters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow.chosenConverter = listConverters.SelectedIndex;
            listStartUnit.ItemsSource = MainWindow.converters[chosenConverter].Units;
            listEndUnit.ItemsSource = MainWindow.converters[chosenConverter].Units;
        }

        private void textValues_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void text12h_KeyUp(object sender, KeyEventArgs e)
        {
            ziecinaUnitConverter.Logic.ConvertHour convH = new ziecinaUnitConverter.Logic.ConvertHour();
            if (radioAM.IsChecked == true)
            {
                string newHour = convH.Convert(text12h.Text, "AM");
                blockResaultHour.Text = newHour;
            }
            else if (radioPM.IsChecked == true)
            {
                string newHour = convH.Convert(text12h.Text, "PM");
                blockResaultHour.Text = newHour;
            }
            else if (radio24h.IsChecked == true)
            {
                string newHour = convH.Convert(text12h.Text, "24h");
                blockResaultHour.Text = newHour;
            }else
            {
                blockResaultHour.Text = "Proszę wybrać startowy format";
            }
        }
    }
}
