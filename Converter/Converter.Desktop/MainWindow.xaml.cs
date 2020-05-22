using Converter.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        int CurrentPage = 1;

        static readonly Dictionary<ConverterType, IConvert> converterMethods = new Dictionary<ConverterType, IConvert>()
        {
            { ConverterType.JOULE, new EnergyConverter("calories") },
            { ConverterType.CALORIES, new EnergyConverter("joules") },
            { ConverterType.FARENHEIT, new TemperatureConverter("celsius") },
            { ConverterType.CELSIUS, new TemperatureConverter("farenheits") },
            { ConverterType.KILOMETER, new Logic.LengthConverter("miles") },
            { ConverterType.MILE, new Logic.LengthConverter("kilometers") },
            { ConverterType.TIME, new Logic.TimeConverter("time") },


        };

        public event PropertyChangedEventHandler PropertyChanged = (sender, evt) => { };

        public MainWindow()
        {
            InitializeComponent();
           // getDataFromMySQL(); do zadania dajemy na przycisk
            for (int i = 0; i < converterMethods.Count; i++)
            {
                var element = converterMethods.ElementAt(i);
                Names.Add(EnumUtil.GetDescription(element.Key));
            }
            ComboBox1.ItemsSource = Names; //binding nie działa poprawić w XAML
            FilterType.ItemsSource = Names;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            ConverterType type = EnumUtil.GetValueFromDescription<ConverterType>(ComboBox1.SelectedItem.ToString());
            IConvertable<float> convertable = new ConvertValue<float>(float.Parse(ToConvertValue.Text));
            IConvert convert = converterMethods[type];
            float Converted = convert.convertValue(convertable.getValue(), type);
            ConvertedValue.Text = Converted.ToString();
            if(type == ConverterType.TIME)
            {
                int convertedValue = Convert.ToInt32(Converted);
                clockRotation.Angle = (30 * convertedValue) + 90;
            }
            InsertData(ComboBox1.SelectedItem.ToString(), type.ToString().ToLower(), convert.convertedTo(), Decimal.Parse(ToConvertValue.Text), Decimal.Parse(ConvertedValue.Text));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void getDataFromMySQL()
        {
            using (SqlConnection connection =
                new SqlConnection("Data Source=localhost;Initial Catalog=ConverterData;Integrated Security=True"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM ConverterData", connection);

                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ConverterManager.converters.Add(
                        new Converter.Logic.Converter(
                            
                            Convert.ToInt32(reader["id"]),
                            reader["ConverterName"].ToString(),
                            reader["UnitFrom"].ToString(),
                            reader["UnitTo"].ToString(),
                            Decimal.Parse(reader["ValueStart"].ToString()),
                            Decimal.Parse(reader["ValueConverted"].ToString()),
                            Convert.ToDateTime(reader["UseDate"])
                           
                        ));
                }

            }
        }


        private void InsertData(string ConverterName, string unitFrom, string unitTo, decimal ValueStart, decimal ValueConverted)
        {
            using (SqlConnection connection =
     new SqlConnection("Data Source=localhost;Initial Catalog=ConverterData;Integrated Security=True"))
            {
                string query = "INSERT INTO ConverterData (ConverterName, UnitFrom, UnitTo, ValueStart, ValueConverted, UseDate) VALUES " +
    "(@ConverterName, @UnitFrom, @UnitTo, @ValueStart, @ValueConverted, @UseDate)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@ConverterName", ConverterName);
                    command.Parameters.AddWithValue("@UnitFrom", unitFrom);
                    command.Parameters.AddWithValue("@UnitTo", unitTo);
                    command.Parameters.AddWithValue("@ValueStart", ValueStart);
                    command.Parameters.AddWithValue("@ValueConverted", ValueConverted);
                    command.Parameters.AddWithValue("@UseDate", DateTime.Now);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (FilterType.SelectedItem == null) return;
            DataView(CurrentPage);
        }

        private void Dalej_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage++;
            DataView(CurrentPage);
        }

        private void Wstecz_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage <= 1) return;
            CurrentPage--;
            DataView(CurrentPage);
        }


        private void DataView(int number)
        {
            if (FilterType.SelectedItem == null) return;
            int TmpMultipler = CurrentPage * 20;
            List<Logic.Converter> convertList = ConverterManager.converters
                .Where(c => FilterType.SelectedItem.ToString().Equals(c.ConveterName))            
                .OrderBy(c => c.ConveterName)
                .Skip(TmpMultipler - 20)
                .Take(TmpMultipler)
                .ToList();
            DateTime dateTime;
            if (DataOd.Text != null && DateTime.TryParseExact(DataOd.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                convertList = convertList.Where(c => c.UseDate >= dateTime).ToList();
            }
            if(DataDo.Text != null && DateTime.TryParseExact(DataDo.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                convertList = convertList.Where(c => c.UseDate <= dateTime).ToList();
            }
            DataGrid.ItemsSource = convertList;
        }

        private void Najpopularniejsze_Click(object sender, RoutedEventArgs e)
        {
            List<Logic.Converter> convertList = ConverterManager.converters
                .ToList();
            DateTime dateTime;
            if (DataOd.Text != null && DateTime.TryParseExact(DataOd.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                convertList = convertList.Where(c => c.UseDate >= dateTime).ToList();
            }
            if (DataDo.Text != null && DateTime.TryParseExact(DataDo.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                convertList = convertList.Where(c => c.UseDate <= dateTime).ToList();
            }
            DataGrid.ItemsSource = convertList.GroupBy(c => c.ConveterName)
                .Select(c => 
               new {  Str = c.Key, Count = c.Count() })
                .OrderByDescending(c => c.Count)
                .Take(3);
        }


        private void DataLoad()
        {
            Thread.Sleep(5000);
            Dispatcher.Invoke(() =>
            {
                getDataFromMySQL();
                DataGrid.ItemsSource = ConverterManager.converters
                .OrderBy(c=> c.id)
                .ToList();
                ellipse1.Visibility = Visibility.Hidden;
                WyciemnienieAplikacji.Visibility = Visibility.Hidden;
                LadowanieNapis.Visibility = Visibility.Hidden;
            });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ellipse1.Visibility = Visibility.Visible;
            WyciemnienieAplikacji.Visibility = Visibility.Visible;
            LadowanieNapis.Visibility = Visibility.Visible;
            Thread t = new Thread(() => DataLoad());
            t.Start();
            ((Storyboard)Resources["LoaderStoryboard"]).Begin();

        }
    }
}
