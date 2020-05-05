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
using System.Data.SqlClient;
using konwerter;

namespace Konwerter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> converters_names = new List<string>()
            {
                new MassConv().name.ToString(),
                new TemperatureConv().name.ToString(),
                new LenghConv().name.ToString(),
                new StorageConv().name.ToString()
            };
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

        public static void DisplayDataUsingEF()
        {
            using (HistoryDataEntities context = new HistoryDataEntities())
            {
                List<Konwert_History> history_conversion = context.Konwert_History.ToList();

            }
        }       
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }        
        public void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {           
           
        }
        
        private void Temp_Button_Click(object sender, RoutedEventArgs e)
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
            using (HistoryDataEntities context = new HistoryDataEntities())
            {
                Konwert_History rec = new Konwert_History()
                {
                    Data = System.DateTime.Now,
                    Wartosc_z = decimal.Parse(InputTempTextBox.Text),
                    Jednostka_z = From_ChoiseTempUnitComboBox.Text,
                    Wartosc_do = decimal.Parse(ResultTempTextBlock.Text),                    
                    Jednostka_do = To_ChoiseTempUnitComboBox.Text                    
                };
                context.Konwert_History.Add(rec);
                context.SaveChanges();
            }
        }
        private void Mass_Button_Click(object sender, RoutedEventArgs e)
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
            using (HistoryDataEntities context = new HistoryDataEntities())
            {
                Konwert_History rec = new Konwert_History()
                {
                    Data = System.DateTime.Now,
                    Wartosc_z = decimal.Parse(InputMassTextBox.Text),
                    Jednostka_z = From_ChoiseMassUnitComboBox.Text,
                    Wartosc_do = decimal.Parse(ResultMassTextBlock.Text),
                    Jednostka_do = To_ChoiseMassUnitComboBox.Text
                };
                context.Konwert_History.Add(rec);
                context.SaveChanges();
            }
        }

        private void Lenght_Button_Click(object sender, RoutedEventArgs e)
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
            using (HistoryDataEntities context = new HistoryDataEntities())
            {
                Konwert_History rec = new Konwert_History()
                {
                    Data = System.DateTime.Now,
                    Wartosc_z = decimal.Parse(InputLenghTextBox.Text),
                    Jednostka_z = From_ChoiseLenghUnitComboBox.Text,
                    Wartosc_do = decimal.Parse(ResultLenghTextBlock.Text),
                    Jednostka_do = To_ChoiseLenghUnitComboBox.Text
                };
                context.Konwert_History.Add(rec);
                context.SaveChanges();
            }
        }

        private void Data_Button_Click(object sender, RoutedEventArgs e)
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
            using (HistoryDataEntities context = new HistoryDataEntities())
            {
                Konwert_History rec = new Konwert_History()
                {
                    Data = System.DateTime.Now,
                    Wartosc_z = decimal.Parse(InputDataTextBox.Text),
                    Jednostka_z = From_ChoiseDataUnitComboBox.Text,
                    Wartosc_do = decimal.Parse(ResultDataTextBlock.Text),
                    Jednostka_do = To_ChoiseDataUnitComboBox.Text
                };
                context.Konwert_History.Add(rec);
                context.SaveChanges();
            }
        }

        private void Time_Button_Click(object sender, RoutedEventArgs e)
        {
            string input_hour = InputTimeHourTextBox.Text;
            string input_min = InputTimeMinTextBox.Text;
            int hour, minutes;
            if (int.TryParse(input_hour, out hour) == true)
            {
                if (hour < 0 || hour > 24)
                {
                    MessageBox.Show("Podaj poprawną godzinę");
                }
                else
                {
                    if (hour >= 0 && hour <= 12)
                    {
                        ResultTimeHourTextBlock.Text = hour.ToString();
                        ResultTimePMTextBlock.Text = "AM";
                    }
                    if (hour > 12 && hour < 24)
                    {
                        hour -= 12;
                        ResultTimeHourTextBlock.Text = hour.ToString();
                        ResultTimePMTextBlock.Text = "PM";
                    }
                    if (hour == 24)
                    {
                        hour = 00;
                        ResultTimeHourTextBlock.Text = hour.ToString();
                        ResultTimePMTextBlock.Text = "AM";
                    }
                    double hours = hour * 30;
                    HourRotate.Angle = hours;
                }
            }
            if (int.TryParse(input_min, out minutes) == true)
            {
                if (minutes < 0 || minutes > 60)
                {
                    MessageBox.Show("Podaj poprawną wartość minut");
                }
                else
                {
                    ResultTimeMinTextBlock.Text = minutes.ToString();
                    double minut = minutes * 6;
                    MinuteRotate.Angle = minut;
                }
            }
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void History_Data_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                     
        }
        public void Daj_historie()
        {
            var biezaca = int.Parse(strona.Content.ToString());
            using (var historia = new HistoryDataEntities())
            {
                var dane = historia.Konwert_History.AsQueryable();
                if (date_od.SelectedDate != null)
                {
                    dane = dane.Where(DATE => DATE.Data >= date_od.SelectedDate);
                }
                if (date_do.SelectedDate != null)
                {
                    dane = dane.Where(DATE => DATE.Data <= date_do.SelectedDate);
                }
                History_Data_Grid.ItemsSource = dane.OrderBy(LP => LP.ID).Skip(10 * (biezaca - 1)).Take(10).ToList();
            }

        }
        private void Get_Button_Click(object sender, RoutedEventArgs e)
        {
            Daj_historie();
        }

        private void Prev_Button_Click(object sender, RoutedEventArgs e)
        {
            var biezaca = int.Parse(strona.Content.ToString());
            if (biezaca > 1)
            {
                strona.Content = biezaca - 1;
            }
            Daj_historie();
        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            var biezaca = int.Parse(strona.Content.ToString());
            strona.Content = biezaca + 1;
            Daj_historie();
        }

        private void Top_5_Click(object sender, RoutedEventArgs e)
        {
            using (var dane = new HistoryDataEntities())
            {
                var items = dane.Konwert_History.GroupBy(X => new { X.Jednostka_z, X.Wartosc_z, X.Jednostka_do, X.Wartosc_do });
                var top5 = items.Select(x => new { ile = x.Count(), x.Key.Jednostka_z, x.Key.Jednostka_do, x.Key.Wartosc_z, x.Key.Wartosc_do})
                    .OrderByDescending(x => x.ile)
                    .Take(5);
                History_Data_Grid.ItemsSource = top5.ToList();
            }
        }
    }
}