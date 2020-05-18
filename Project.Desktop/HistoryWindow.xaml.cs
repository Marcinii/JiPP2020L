using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace Project.Desktop
{
    /// <summary>
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    /// 

    public partial class HistoryWindow : Window
    {

        private List<ConversionHistory> HistoryList = new List<ConversionHistory>();

        public HistoryWindow()
        {
            InitializeComponent();

            ConvertersComboBox.ItemsSource = (new ConverterService()).GetConverters();
        }


        private IQueryable<ConversionHistory> Filter(IQueryable<ConversionHistory> items)
        {
            DateTime? StartDate = Dispatcher.Invoke(() => StartDateDatePicker.SelectedDate);
            DateTime? EndDate = Dispatcher.Invoke(() => EndDateDatePicker.SelectedDate);
            string ConverterName = "";
            ConverterName = Dispatcher.Invoke(() => ((IConverter)ConvertersComboBox?.SelectedItem)?.Name);

            if (StartDate.HasValue)
                items = items.Where(i => DbFunctions.TruncateTime(i.Date) >= StartDate);
            if (EndDate.HasValue)
                items = items.Where(i => DbFunctions.TruncateTime(i.Date) <= EndDate);
            if (!String.IsNullOrEmpty(ConverterName))
                items = items.Where(i => i.Converter == ConverterName);


            return items;

        }


        public void LoadHistory()
        {

            LoadingScreen.Visibility = Visibility.Visible;

            Task t1 = new Task(() => LoadData());
            t1.Start();
            

        }


        private void LoadData()
        {
 
            using (var db = new jippEntities())
            {
                var items = db.ConversionHistory.AsQueryable<ConversionHistory>();


                items = Filter(items);

                int count = items.Count();

                Dispatcher.Invoke(() =>
                {
                    PageSelectorComboBox.Items.Clear();

                    for (int i = 0, j = 1; i < count; i += 20, j++)
                    {
                        PageSelectorComboBox.Items.Add(j);
                    }

                    PageSelectorComboBox.SelectedIndex = 0;
                });


                Task.Delay(2000).Wait();

                // Tu następuje pobranie danych z sql
                var itemslist = items.OrderBy(i => i.Id).Take(20).ToList();

                Dispatcher.Invoke(() => HistoryDataGrid.ItemsSource = itemslist);

                // Pobranie najpopularniejszych konwersji
                var mostPopular = items.GroupBy(i => new { i.Converter, i.UnitFrom, i.UnitTo }).Select(i => new { Type = i.Key, Count = i.Count() }).OrderByDescending(i => i.Count).Take(3).ToList();


                Dispatcher.Invoke(() =>
                {

                    MostPopularTextBlock.Text = "";

                    foreach (var a in mostPopular)
                        MostPopularTextBlock.Text += a.Type.Converter + " [" + a.Type.UnitFrom + " -> " + a.Type.UnitTo + "] (" + a.Count + ")\n";

                    LoadingScreen.Visibility = Visibility.Hidden;
                });
        
            }

        }


        private void PageSelectorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadingScreen.Visibility = Visibility.Visible;
            Task t1 = new Task(() =>
            {


                using (var db = new jippEntities())
                {
                    Task.Delay(2000).Wait();
                    if (Dispatcher.Invoke(() => PageSelectorComboBox.SelectedIndex) != -1)
                    {
                        var items = db.ConversionHistory.AsQueryable<ConversionHistory>();
                        items = Filter(items);

                        Dispatcher.Invoke(() => HistoryDataGrid.ItemsSource = items.OrderBy(i => i.Id).Skip(20 * (((int)PageSelectorComboBox.SelectedItem) - 1)).Take(20).ToList());
                    }


                }

                Dispatcher.Invoke(() => LoadingScreen.Visibility = Visibility.Hidden);

            });

            t1.Start();

        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void filterButon_Click(object sender, RoutedEventArgs e)
        {
            LoadHistory();
        }

        private void ClearfilterButon_Click(object sender, RoutedEventArgs e)
        {
            ConvertersComboBox.SelectedIndex = -1;
            StartDateDatePicker.SelectedDate = null;
            EndDateDatePicker.SelectedDate = null;
            LoadHistory();
        }


    }
}
