using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using unit_converter;

namespace UnitConverterDesktopApp
{
    public partial class StatsWindow : Window
    {
        private IEnumerable<dynamic> _records;
        private static readonly int _maxRecordsPerPage = 10;
        private int _currentPage;
        private double _lastPage;

        public StatsWindow()
        {
            InitializeComponent();

            FilterByConverterListBox.ItemsSource = new ConverterService().GetConverters().Keys;
            _currentPage = 1;

            FilterDataCommand = new RelayCommand(obj => FilterData());
            FilterDataButton.Command = FilterDataCommand;

            PreviousCommand = new RelayCommand(
                obj => Previous(), 
                obj => _currentPage - 1 > 0
            );
            PreviousButton.Command = PreviousCommand;

            NextCommand = new RelayCommand(
                obj => Next(),
                obj => _currentPage < _lastPage
            );
            NextButton.Command = NextCommand;
        }

        public void PageCountRefresh()
        {
            PageCountTextBox.Text = $"Page {_currentPage} of {_lastPage}";
        }

        private List<string> GetFilterByConverterItems()
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
            return nameFilters;
        }
        private void RunQuery()
        {
            this._records = Database.SelectResults(
                this.GetFilterByConverterItems(), this.DateFromPicker.SelectedDate, this.DateToPicker.SelectedDate, this.TopCheckBox.IsChecked);
            _lastPage = Math.Ceiling(Enumerable.Count(this._records) / Convert.ToDouble(_maxRecordsPerPage));
        }

        private void LoadStatistics()
        {
            Task.Delay(3000).Wait();

            Dispatcher.Invoke(() => 
            {
                if (TableForStats.ItemsSource != null)
                {
                    _currentPage = 1;
                    TableForStats.ItemsSource = this._records
                        .Skip((_currentPage - 1) * _maxRecordsPerPage)
                        .Take(_maxRecordsPerPage);
                    PageCountRefresh();
                }
                else
                {
                    TableForStats.ItemsSource = this._records.Take(_maxRecordsPerPage);
                    PageCountRefresh();
                }
            });
        }

        public RelayCommand FilterDataCommand;
        private void FilterData()
        {
            RunQuery();
            
            StatsWindowLoadingScreen.Visibility = Visibility.Visible;

            Task task1 = new Task(() => LoadStatistics());
            task1.Start();

            Task.WhenAll(task1).ContinueWith(t =>
            {
                Dispatcher.Invoke(() => StatsWindowLoadingScreen.Visibility = Visibility.Hidden);
            });
        }

        RelayCommand PreviousCommand;
        private void Previous()
        {
            _currentPage--;
            TableForStats.ItemsSource = this._records
                .Skip((_currentPage - 1) * _maxRecordsPerPage)
                .Take(_maxRecordsPerPage);
            PageCountRefresh();
        }

        RelayCommand NextCommand;
        private void Next()
        {        
            _currentPage++;
            TableForStats.ItemsSource = this._records
                .Skip((_currentPage - 1) * _maxRecordsPerPage)
                .Take(_maxRecordsPerPage);
            PageCountRefresh();
        }
    }
}
