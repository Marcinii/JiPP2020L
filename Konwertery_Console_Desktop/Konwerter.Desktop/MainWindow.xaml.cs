using System;
using System.Collections.Generic;
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
using Konwerter.Desktop.Repository;
using Konwerter.Desktop.ViewModel;
using Logic;

namespace Konwerter.Desktop
{
    public partial class MainWindow : Window
    {

        public ViewModelBase view = new ViewModelBase();

        public bool isOcenaOpened;
        public int initPagination = 0;
        public int borderPagination = 20;
        public int databaseSize;
        public string selectedFilterType = null;

        public string dateFromParam = null;
        public string dateToParam = null;

        public CONVERSIONS conversion = new CONVERSIONS();

        public List<IConverter> converterList = new List<IConverter> {
            new LenghtConversion(),
            new WeightConversion(),
            new TemperatureConversion(),
            new PowerConversion(),
            new TimeConversion()
        };

        public IConverter chosenConverter;

        public MainWindow()
        {
            InitializeComponent();
            // getPagedConversions(initPagination, borderPagination, selectedFilterType, dateFromParam, dateToParam);
            getMostPopular();
            initConverterBox();
            hourRotation.Angle = (360/12)*(6)+90;
            minuteRotation.Angle = (360 / 60) * (15) + 90;

        }

        private void initConverterBox()
        {
            List<string> list = new List<string>();
            foreach (IConverter converter in converterList)
            {
                list.Add(converter.ConverterName);
            }
            converterBox.ItemsSource = list;
            convFilterBox.ItemsSource = list;
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
                    chosenConverter = converterList[0];
                    initLenghtConverter();
                    hideClock();
                    break;
                case 1:
                    chosenConverter = converterList[1];
                    initWeightConverter();
                    hideClock();
                    break;
                case 2:
                    chosenConverter = converterList[2];
                    initTemperatureConverter();
                    hideClock();
                    break;
                case 3:
                    chosenConverter = converterList[3];
                    initPowerConverter();
                    hideClock();
                    break;
                case 4:
                    chosenConverter = converterList[4];
                    initTimeConverter();
                    showClock();
                    ((Storyboard)Resources["zegarAnimation"]).Begin();
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
                string result = chosenConverter.onConvert(quantity, conFrom, conTo);

                if (chosenConverter.Equals(converterList[4]))
                {
                    string[] lista = quantity.Split(':');
                    hourRotation.Angle = (360 / 12) * (Int32.Parse(lista[0])) + 90;
                    minuteRotation.Angle = (360 / 60) * (Int32.Parse(lista[1])) + 90;
                    resultLabel.Content = result;
                } 
                else
                {
                    resultLabel.Content = result;
                }

                conversion.name = chosenConverter.ConverterName;
                conversion.unitFrom = conFrom;
                conversion.unitTo = conTo;
                conversion.valueToConvert = quantity;
                conversion.valueAfterConvert = result;
                conversion.dateOfConversion = DateTime.Now;

                insertData(conversion);
                conversion = new CONVERSIONS();
                // getPagedConversions(initPagination, borderPagination, null, dateFromParam, dateToParam);
            }
        }

        private void showClock()
        {
            path1.Visibility = Visibility.Visible;
            rectangle.Visibility = Visibility.Visible;
            hourPointer.Visibility = Visibility.Visible;
        }

        private void hideClock()
        {
            path1.Visibility = Visibility.Hidden;
            rectangle.Visibility = Visibility.Hidden;
            hourPointer.Visibility = Visibility.Hidden;
        }

        public void insertData(CONVERSIONS conversion)
        {
            DatabaseModule.insert(conversion);
        }

        public void getPagedConversions(int initPagination, int borderPagination, string type, string dateFrom, string dateTo)
        {
            List<CONVERSIONS> allConversions;
            if (type != null && dateFrom != null && dateTo != null)
            {
                allConversions = DatabaseModule.getConversionsByParams(type, dateFrom, dateTo);
            }
            else
            {
                allConversions = DatabaseModule.getAllConversions();
            }
            this.databaseSize = allConversions.Count;
            List<CONVERSIONS> pagedList = new List<CONVERSIONS>();

            if (borderPagination > databaseSize)
            {
                for (int i = initPagination; i < databaseSize; i++)
                {
                    pagedList.Add(allConversions.ElementAt(i));
                }
            }
            else
            {
                for (int i = initPagination; i < borderPagination; i++)
                {
                    pagedList.Add(allConversions.ElementAt(i));
                }
            }

            Task.Delay(5000).Wait();

            Dispatcher.Invoke(() => {
                statsGrid.ItemsSource = pagedList;
                ld_con.Visibility = Visibility.Hidden;
            });
        }

        public void getMostPopular()
        {
            List<MostPopularConversion> allPopularConversions;
            allPopularConversions = DatabaseModule.getAllMostPopular();
            mostPopularGrid.ItemsSource = allPopularConversions;
        }

        private void convFilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            initPagination = 0;
            borderPagination = 20;
            this.selectedFilterType = converterList[convFilterBox.SelectedIndex].ConverterName;
            getPagedConversions(initPagination, borderPagination, selectedFilterType, dateFromParam, dateToParam);
            mostPopularGrid.ItemsSource = DatabaseModule.getMostPopularByType(selectedFilterType);
        }

        private void previousPageBtn_Click(object sender, RoutedEventArgs e)
        {
            this.initPagination -= 20;
            this.borderPagination -= 20;
            if (initPagination < 0)
            {
                initPagination = 0;
                borderPagination = initPagination + 20;
                previousPageBtn.IsEnabled = false;
            } else
            {
                getPagedConversions(initPagination, borderPagination, selectedFilterType, dateFromParam, dateToParam);
                nextPageBtn.IsEnabled = true;
            }
            
        }

        private void nextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            int border = borderPagination;
            this.initPagination  +=  20;
            this.borderPagination +=  20;
            if (borderPagination > databaseSize)
            {
                getPagedConversions(border, ((borderPagination - databaseSize) + border), selectedFilterType, dateFromParam, dateToParam);
                nextPageBtn.IsEnabled = false;
                previousPageBtn.IsEnabled = true;
            } 
            else
            {
                getPagedConversions(initPagination, borderPagination, selectedFilterType, dateFromParam, dateToParam);
            }
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            initPagination = 0;
            borderPagination = 20;
            getPagedConversions(initPagination, borderPagination, selectedFilterType, dateFromParam, dateToParam);
            mostPopularGrid.ItemsSource = DatabaseModule.getMostPopularByType(selectedFilterType);
        }

        private void dateFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string pickedDate = dateFrom.SelectedDate.ToString();
            DateTime day = DateTime.Parse(pickedDate);
            dateFromParam = day.ToString("yyyy/MM/dd");
        }

        private void dateTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string pickedDate = dateTo.SelectedDate.ToString();
            DateTime day = DateTime.Parse(pickedDate);
            dateToParam = day.ToString("yyyy/MM/dd");
        }

        private void onConvert_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void convertFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void loadStats_btn_Click(object sender, RoutedEventArgs e)
        {
            ld_con.Visibility = Visibility.Visible;

            Task task = new Task (() => getPagedConversions(initPagination, borderPagination, selectedFilterType, dateFromParam, dateToParam));
            task.Start();

        }
    }
}
