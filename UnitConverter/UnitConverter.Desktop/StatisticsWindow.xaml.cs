using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;
using UnitConverter.Logic;

namespace UnitConverter.Desktop
{
    public partial class StatisticsWindow : Window
    {
        List<IConverter> converters = new List<IConverter>
        {
            new ByteConverter(),
            new DistanceConverter(),
            new MassConverter(),
            new TemperatureConverter(),
            new TimeConverter(),
        };

        public StatisticsWindow()
        {
            InitializeComponent();
            PrepareRelay();
            ConverterFilterComboBox.ItemsSource = converters;
        }

        private void PrepareRelay()
        {
            NextPageCmd = new RelayCommand(obj => NextPage());
            NextPageButton.Command = NextPageCmd;
            PreviousPageCmd = new RelayCommand(obj => PreviousPage());
            PreviousPageButton.Command = PreviousPageCmd;
        }

        private RelayCommand NextPageCmd;
        private void NextPage()
        {
            var page = int.Parse(PageLabel.Content.ToString());
            var output = LoadDbData(page + 1);

            if (output.Count > 0)
            {
                DbView.ItemsSource = output;
                PageLabel.Content = (page + 1).ToString();
            }
        }

        private RelayCommand PreviousPageCmd;
        private void PreviousPage()
        {
            var page = int.Parse(PageLabel.Content.ToString());

            if (page > 1)
            {
                var output = LoadDbData(page - 1);
                DbView.ItemsSource = output;
                PageLabel.Content = (page - 1).ToString();
            }
        }

        private void LoadFromDb()
        {
            DbView.ItemsSource = LoadDbData(1);
        }

        private List<Conversion> LoadDbData(int page)
        {
            var start_date = FromDatePickerFilter.SelectedDate;
            var end_date = ToDatePickerFilter.SelectedDate;
            var converter = ConverterFilterComboBox.SelectedItem;
            return SelectDb(start_date, end_date, converter, page);
        }
        private List<Conversion> SelectDb(DateTime? start_date, DateTime? end_date, object converter, int page)
        {
            var output = new List<Conversion> { };

            using (var context = new ConversionsDb())
            {
                var select = context.Conversions.AsQueryable();
                if (converter != null)
                {
                    select = select.Where(c => c.converter == ((IConverter)converter).Name);
                }
                if (start_date.HasValue)
                {
                    select = select.Where(c => DbFunctions.TruncateTime(c.date) >= start_date.Value);
                }
                if (end_date.HasValue)
                {
                    select = select.Where(c => DbFunctions.TruncateTime(c.date) >= start_date.Value);
                }
                output = select.OrderBy(c => c.id).Skip((page - 1) * 20).ToList();
            }

            return output;
        }
        private void LoadThreaded(DateTime? start_date, DateTime? end_date, object converter, int page)
        {
            var output = SelectDb(start_date, end_date, converter, page);
            Thread.Sleep(2000);
            Dispatcher.Invoke(() =>
            {
                DbView.ItemsSource = output;
            });
        }

        private void LoadStatsButton_Click(object sender, RoutedEventArgs e)
        {
            var loading = (Storyboard)FindResource("Loading");
            loading.Begin();
            var page = int.Parse(PageLabel.Content.ToString());
            var start_date = FromDatePickerFilter.SelectedDate;
            var end_date = ToDatePickerFilter.SelectedDate;
            var converter = ConverterFilterComboBox.SelectedItem;
            Thread t = new Thread(() =>
            {
                LoadThreaded(start_date, end_date, converter, page);
            });
            t.Start();
        }
    }
}
