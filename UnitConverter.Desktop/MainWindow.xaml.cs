using Project1;
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

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();


            comboboxConverter.ItemsSource = new List<IConverter>()
            {
                new Project1.LengthConverter(),
                new TemperatureConverter(),
                new WeightConverter(),
                new TimeConverter()
            };



            }
        string nameConv = "";
        string nameConvDB = "";

        private void comboboxConverter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboboxUnitFrom.ItemsSource = ((IConverter)comboboxConverter.SelectedItem).Units;
            comboboxUnitTo.ItemsSource = ((IConverter)comboboxConverter.SelectedItem).Units;

            using (TestDataEntities contextGrid = new TestDataEntities())
            {
                List<ConverterRecord> records = contextGrid.ConverterRecords.ToList();
                dbGrid.ItemsSource = records;
            }


        }

        private void buttonConvert_Click(object sender, RoutedEventArgs e)
        {
            string inputText = inputTextbox.Text;
            decimal inputValue = decimal.Parse(inputText);

            decimal result = ((IConverter)comboboxConverter.SelectedItem).Convert(
                comboboxUnitFrom.SelectedItem.ToString(),
                comboboxUnitTo.SelectedItem.ToString(),
                inputValue);

            resultTextblock.Text = result.ToString();

            nameConv = comboboxConverter.SelectedItem.ToString();

            if (nameConv == "Project1.LengthConverter")
            {
                nameConvDB = "Długość";
            }
            else if (nameConv == "Project1.TemperatureConverter")
            {
                nameConvDB = "Temperatura";
            }
            else if (nameConv == "Project1.WeightConverter")
            {
                nameConvDB = "Masa";
            }
            else if (nameConv == "Project1.TimeConverter")
            {
                nameConvDB = "Czas";
            }


            using (TestDataEntities context = new TestDataEntities())
            {

                ConverterRecord newRecord = new ConverterRecord()
                {
                    NameConverter = nameConvDB,
                    UnitFrom = comboboxUnitFrom.SelectedItem.ToString(),
                    UnitTo = comboboxUnitTo.SelectedItem.ToString(),
                    Value = inputValue,
                    Result = result,
                    DateRecord = DateTime.Now
                };

                context.ConverterRecords.Add(newRecord);
                context.SaveChanges();

            }


        }



    }
}
