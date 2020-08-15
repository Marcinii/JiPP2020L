using Converter.Logic;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PagedList;

namespace Converter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int pageNumber = 1;
        IPagedList<Converter> list;


        public MainWindow()
        {

            InitializeComponent();
            List<IConverter> list = new List<IConverter>()
            {
                new LenghtConverter(),
                new TemperatureConverter(),
                new QuantityConverter(),
                new WeightConverter(),

            };
            converterComboBox.ItemsSource = list;
            sortTypeComboBox.ItemsSource = list;


            List<string> time = new List<string>()
            {
                "24h na 12h",
                "12h na 24h"
            };
            timeComboBox.ItemsSource = time;

            

        }

        

        public async Task<IPagedList<Converter>> GetPagedListAsync(int pageNumber = 1, int pageSize = 10){
            return await Task.Factory.StartNew(() =>
            {
                using (ConvertersDataBaseEntities1 context = new ConvertersDataBaseEntities1())
                {
                    return context.Converter.OrderBy(p => p.ID).ToPagedList(pageNumber, pageSize);
                }
            });
        }

        private async void last20Logs_Click(object sender, RoutedEventArgs e)
        {
            list = await GetPagedListAsync();
            pageLeftButton.IsEnabled = list.HasPreviousPage;
            pageRightButton.IsEnabled = list.HasNextPage;
            logsOutputDataGird.ItemsSource = list.ToList();
            label2.Content = string.Format("Page {0}/{1}", pageNumber, list.PageCount);
        }

        private async void pageLeftButton_Click(object sender, EventArgs e)
        {
            if (list.HasPreviousPage)
            {
                list = await GetPagedListAsync(--pageNumber);
                pageLeftButton.IsEnabled = list.HasPreviousPage;
                pageRightButton.IsEnabled = list.HasNextPage;
                logsOutputDataGird.ItemsSource = list.ToList();
                label2.Content = string.Format("Page {0}/{1}", pageNumber, list.PageCount);
            }
        }

        private async void pageRightButton_Click(object sender, EventArgs e)
        {
            if (list.HasNextPage)
            {
                list = await GetPagedListAsync(++pageNumber);
                pageLeftButton.IsEnabled = list.HasPreviousPage;
                pageRightButton.IsEnabled = list.HasNextPage;
                logsOutputDataGird.ItemsSource = list.ToList();
                label2.Content = string.Format("Page {0}/{1}", pageNumber, list.PageCount);
            }
        }



        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFromComboBox.ItemsSource = ((IConverter)converterComboBox.SelectedItem).Units;
            unitToComboBox.ItemsSource = ((IConverter)converterComboBox.SelectedItem).Units;
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = inputTextBox.Text;
            decimal inputValue = decimal.Parse(inputText);

            decimal result = ((IConverter)converterComboBox.SelectedItem).Convert(
                unitFromComboBox.SelectedItem.ToString(),
                unitToComboBox.SelectedItem.ToString(),
                inputValue);

            outputTextBlock.Text = result.ToString();

            InstertDataToDB();
        }

       

        private void timeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string input = hourTextBox.Text;
            decimal x = decimal.Parse(input);
            decimal result=1;
            string type="";
            if (timeComboBox.SelectedItem.ToString() == "12h na 24h")
            {
                result = new TimeConverter().Convert("Am", "Pm", x);
                type = " Pm";
                
            }
            else if(timeComboBox.SelectedItem.ToString() == "24h na 12h")
            {
                result = new TimeConverter().Convert("Pm", "Am", x);
                type = " Am";
            }
            timeOutput.Text = result + ":" + minuteTextBox.Text + type;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["rotatingClock"]).Begin();
        }

        public void InstertDataToDB()
        {
            using (ConvertersDataBaseEntities1 context = new ConvertersDataBaseEntities1())
            {
                Converter converter = new Converter()
                {
                    ConverterName = converterComboBox.Text.ToString(),
                    ConversionFrom = unitFromComboBox.Text.ToString(),
                    ConversionTo = unitToComboBox.Text.ToString(),
                    ConversionDate = DateTime.Now
                };
                context.Converter.Add(converter);
                context.SaveChanges();
            }
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DisplaySomeLogs();
        }

        public void DisplaySomeLogs()
        {
            string konwerter = sortTypeComboBox.SelectedItem.ToString();
            using (ConvertersDataBaseEntities1 context = new ConvertersDataBaseEntities1())
            {
                List<Converter> converters = context.Converter.ToList();

                logsOutputDataGird.ItemsSource = converters.Where(e => e.ConverterName == konwerter)
                                                         .OrderByDescending(el => el.ID);
            }
        }

        private void dataSortButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime startData = (DateTime)datePicker1.SelectedDate;
            DateTime endData = (DateTime)datePicker2.SelectedDate;
 
         
            using (ConvertersDataBaseEntities1 context = new ConvertersDataBaseEntities1())
            {
                List<Converter> converters = context.Converter.ToList();
                logsOutputDataGird.ItemsSource = converters.Where(e2=> (e2.ConversionDate > startData) && (e2.ConversionDate <= endData))
                    .OrderByDescending(e1 => e1.ID);
            }

        }

    }
}
