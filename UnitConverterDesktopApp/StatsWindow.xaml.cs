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
using unit_converter;

namespace UnitConverterDesktopApp
{
    /// <summary>
    /// Interaction logic for StatsWindows.xaml
    /// </summary>
    public partial class StatsWindow : Window
    {
        public StatsWindow()
        {
            InitializeComponent();
            FilterByConverterListBox.ItemsSource = new ConverterService().GetConverters().Keys;
        }
        private void SelectResults(List<string> converters, DateTime? dateFrom, DateTime? dateTo, bool? topOnly)
        {
            using (ConverterDataModel context = new ConverterDataModel())
            {
                var results = context.Results.AsQueryable();

                results = results.AsQueryable()
                    .Where(r => converters.Any(c => r.ConverterName.Equals(c)));
                
                if (dateFrom.HasValue)
                {
                    results = results.Where(
                        r => DbFunctions.TruncateTime(r.ConversionDate) >= dateFrom);
                }
                if (dateTo.HasValue)
                {
                    results = results.Where(
                        r => DbFunctions.TruncateTime(r.ConversionDate) <= dateTo);
                }
                
                if (topOnly ?? false)  
                    this.DataTable.ItemsSource = results.ToList();
                else
                {
                    var topResults = results
                    .GroupBy(x => new { x.ConverterName, x.SourceUnit, x.TargetUnit })
                    .Select(x => new { x.Key.ConverterName, x.Key.SourceUnit, x.Key.TargetUnit, Count = x.Count() })
                    .OrderByDescending(x => x.Count)
                    .Take(3);
                    this.DataTable.ItemsSource = topResults.ToList();
                }
            }
        }
        private void FilterDataButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> nameFilters = new List<string>();
            if (FilterByConverterListBox.SelectedItems.Count == 0)
            {
                foreach (string s in FilterByConverterListBox.Items)
                {
                    nameFilters.Add(s);
                }
            }
            else
            {
                foreach (string s in FilterByConverterListBox.SelectedItems)
                {
                    nameFilters.Add(s);
                }
            }
            this.SelectResults(nameFilters, this.DateFromPicker.SelectedDate, this.DateToPicker.SelectedDate, this.TopCheckBox.IsChecked);
        }
    }
}
