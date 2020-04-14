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


            db = new jippEntities();
            RefreshHistory();

        }

        IQueryable<ConversionHistory> items;
        private jippEntities db;

        private void RefreshHistory()
        {
            //using (var db = new jippEntities())
            //{

            items = db.ConversionHistory.AsQueryable<ConversionHistory>();


            if (StartDateDatePicker.SelectedDate.HasValue)
                items = items.Where(i => DbFunctions.TruncateTime(i.Date) >= StartDateDatePicker.SelectedDate);
            if (EndDateDatePicker.SelectedDate.HasValue)
                items = items.Where(i => DbFunctions.TruncateTime(i.Date) <= EndDateDatePicker.SelectedDate);
            if (ConvertersComboBox.SelectedIndex != -1)
                items = items.Where(i => i.Converter == ((IConverter)ConvertersComboBox.SelectedItem).Name);



            int count = items.Count();

            PageSelectorComboBox.Items.Clear();

            for (int i = 0, j = 1; i < count; i += 20, j++)
            {
                PageSelectorComboBox.Items.Add(j);
            }

            PageSelectorComboBox.SelectedIndex = 0;

            HistoryDataGrid.ItemsSource = items.OrderBy(i => i.Id).Take(20).ToList();

            var mostPopular = items.GroupBy(i => new { i.Converter, i.UnitFrom, i.UnitTo }).Select(i => new { Type = i.Key, Count = i.Count() }).OrderByDescending(i => i.Count).Take(3).ToList();


            MostPopularTextBlock.Text = "";

            foreach (var a in mostPopular)
                MostPopularTextBlock.Text += a.Type.Converter + " [" + a.Type.UnitFrom + " -> " + a.Type.UnitTo + "] (" + a.Count + ")\n";

            //}
        }
        private void PageSelectorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(PageSelectorComboBox.SelectedIndex != -1)
                HistoryDataGrid.ItemsSource = items.OrderBy(i => i.Id).Skip(20*(((int)PageSelectorComboBox.SelectedItem)-1)).Take(20).ToList();
        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void filterButon_Click(object sender, RoutedEventArgs e)
        {
            RefreshHistory();
        }

        private void ClearfilterButon_Click(object sender, RoutedEventArgs e)
        {
            ConvertersComboBox.SelectedIndex = -1;
            StartDateDatePicker.SelectedDate = null;
            EndDateDatePicker.SelectedDate = null;
            RefreshHistory();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshHistory();
        }
    }
}
