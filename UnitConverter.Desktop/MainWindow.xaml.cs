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
using System.Windows.Media.Animation;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ellipse Clock = new Ellipse();
        Line Hours = new Line();
        Line Minutes = new Line();

        private Storyboard toggleClock;

        public MainWindow()
        {
            InitializeComponent();
            typeComboBox.ItemsSource = new List<IConverter>()
            {
                new TemperatureConverter(),
                new WeightConverter(),
                new LengthConverter(),
                new TimeConverter(),
                new ClockConverter(),
            };
            UnitFrom.Focusable = false;
            UnitTo.Focusable = false;
            UnitFrom.IsHitTestVisible = false;
            UnitTo.IsHitTestVisible = false;

            TypeFilter.ItemsSource = new List<string>()
            {
                new TemperatureConverter().Name,
                new WeightConverter().Name,
                new LengthConverter().Name,
                new TimeConverter().Name,
                new ClockConverter().Name,
            };
            TypeFilter.SelectedIndex = 1;

            FilterFromDB();
            using (ParadygmatyEntities context = new ParadygmatyEntities())
            {
                var Ratings = context.RATINGS.ToList();
                RatingControl.RatingVal = (int) Ratings[0].RATINGS;
            }

            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromRgb(255, 255, 255);
            Clock.Fill = mySolidColorBrush;
            Clock.Height = 88;
            Clock.Width = 88;
            Clock.Stroke = Brushes.Black;
            Clock.Name = "Clock";
            Thickness margin = Clock.Margin;
            margin.Left = 289;
            margin.Top = -400;
            Clock.Margin = margin;

            Minutes.Stroke = Brushes.Black;
            Minutes.HorizontalAlignment = HorizontalAlignment.Left;
            Minutes.VerticalAlignment = VerticalAlignment.Center;
            Minutes.X1 = 487;
            Minutes.X2 = 487;
            Minutes.Y1 = 0;
            Minutes.Y2 = -40;
            Thickness marginM = Minutes.Margin;
            marginM.Top = -400;
            Minutes.Margin = marginM;
            Minutes.StrokeThickness = 2;

            Hours.Stroke = Brushes.Black;
            Hours.HorizontalAlignment = HorizontalAlignment.Left;
            Hours.VerticalAlignment = VerticalAlignment.Center;
            Hours.X1 = 487;
            Hours.X2 = 487;
            Hours.Y1 = 0;
            Hours.Y2 = -25;
            Thickness marginH = Hours.Margin;
            marginH.Top = -400;
            Hours.Margin = marginH;
            Hours.StrokeThickness = 4;

            FilterCommand = new RelayCommand(obj => Filter());
            PreviousPageCommand = new RelayCommand(obj => GoPreviousPage());
            NextPageCommand = new RelayCommand(obj => GoNextPage());

            FilterButton.Command = FilterCommand;
            PreviousPage.Command = PreviousPageCommand;
            NextPage.Command = NextPageCommand;
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Grid.Children.Remove(Clock);
            Grid.Children.Remove(Minutes);
            Grid.Children.Remove(Hours);

            UnitToValue.Text = "";
            UnitFromValue.Text = "";
            UnitFrom.ItemsSource = ((IConverter)typeComboBox.SelectedItem).Units;
            UnitTo.ItemsSource = ((IConverter)typeComboBox.SelectedItem).Units;
            UnitFrom.SelectedItem = ((IConverter)typeComboBox.SelectedItem).Units.First();
            UnitTo.SelectedItem = ((IConverter)typeComboBox.SelectedItem).Units.First();
            UnitFrom.Focusable = true;
            UnitTo.Focusable = true;
            UnitFrom.IsHitTestVisible = true;
            UnitTo.IsHitTestVisible = true;
            if (typeComboBox.SelectedItem.ToString() == "UnitConverter.ClockConverter")
            {
                UnitFrom.ItemsSource = new List<string> { "24-hour" };
                UnitFrom.SelectedItem = "24-hour";
                UnitFrom.Focusable = false;
                UnitFrom.IsHitTestVisible = false;

                Grid.Children.Add(Clock);
                Grid.Children.Add(Minutes);
                Grid.Children.Add(Hours);
            }
        }

        private void UnitFromValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (typeComboBox.SelectedItem.ToString() == "UnitConverter.ClockConverter")
            {
                char[] separator = { ':', '-' };
                string[] time = UnitFromValue.Text.Split(separator);
                double hours;
                if (double.TryParse(time[0], out hours))
                {
                    double result = ((IConverter)typeComboBox.SelectedItem)
                        .convert("24-hour", "12-hour", hours);
                    string hourString = result.ToString();
                    string minuteString = time.Length > 1 ? $":{time[1]}" : "";
                    string suffixString = hours > 12 ? "pm" : "am";
                    UnitToValue.Text = $"{hourString}{minuteString} {suffixString}";
                    RotateTransform rotateHours = new RotateTransform(hours * 30, 337, 0);
                    Hours.RenderTransform = rotateHours;
                    if (time.Length > 1)
                    {
                        double minutes;
                        if (double.TryParse(time[1], out minutes))
                        {
                            RotateTransform rotateMinutes = new RotateTransform(minutes * 6, 337, 0);
                            Minutes.RenderTransform = rotateMinutes;
                        }
                    }
                }
                return;

            }
            double value;
            if (double.TryParse(UnitFromValue.Text, out value))
            {
                double result = ((IConverter)typeComboBox.SelectedItem)
                    .convert(UnitFrom.SelectedItem.ToString(), UnitTo.SelectedItem.ToString(), value);
                UnitToValue.Text = result.ToString();

                using (ParadygmatyEntities context = new ParadygmatyEntities())
                {
                    STATISTIC newStatistic = new STATISTIC()
                    {
                        TYPE = ((IConverter)typeComboBox.SelectedItem).Name,
                        DATE = DateTime.Now,
                        VALUEFROM = value,
                        VALUETO = result,
                        UNITFROM = UnitFrom.Text,
                        UNITTO = UnitTo.Text
                    };
                    context.STATISTICS.Add(newStatistic);

                    context.SaveChanges();
                }
            }
        }

        private void UnitFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double value;
            if (double.TryParse(UnitFromValue.Text, out value))
            {
                double result = ((IConverter)typeComboBox.SelectedItem)
                    .convert(UnitFrom.SelectedItem.ToString(), UnitTo.SelectedItem.ToString(), value);
                UnitToValue.Text = result.ToString();
            }
        }
        private void UnitTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double value;
            if (double.TryParse(UnitFromValue.Text, out value))
            {
                double result = ((IConverter)typeComboBox.SelectedItem)
                    .convert(UnitFrom.SelectedItem.ToString(), UnitTo.SelectedItem.ToString(), value);
                UnitToValue.Text = result.ToString();
            }
        }

        private RelayCommand FilterCommand;

        private void Filter()
        {
            FilterFromDB();
        }

        protected void FilterFromDB()
        {
            int value;
            int.TryParse(PageNumber.Text, out value);
            using (ParadygmatyEntities context = new ParadygmatyEntities())
            {
                List<STATISTIC> StatisticsList = context.STATISTICS
                .Where(s => s.TYPE == TypeFilter.SelectedItem.ToString())
                .Where(s => DateFromFilter.SelectedDate != null ? s.DATE > DateFromFilter.SelectedDate.Value : true)
                .Where(s => DateToFilter.SelectedDate != null ? s.DATE < DateToFilter.SelectedDate.Value : true)
                .OrderBy(s => s.TYPE)
                .Skip(value > 1 ? (20 * (value - 1)) : 0)
                .Take(20)
                .ToList();

                var PopularList = context.STATISTICS
                .Where(s => s.TYPE == TypeFilter.SelectedItem.ToString())
                .Where(s => DateFromFilter.SelectedDate != null ? s.DATE > DateFromFilter.SelectedDate.Value : true)
                .Where(s => DateToFilter.SelectedDate != null ? s.DATE < DateToFilter.SelectedDate.Value : true)
                .GroupBy(x => new { x.TYPE, x.UNITFROM, x.UNITTO })
                .Select(x =>  new { x.Key.TYPE, x.Key.UNITFROM, x.Key.UNITTO, Count = x.Count() })
                .OrderByDescending(x => x.Count)
                .Take(3)
                .ToList();

                StatisticsData.ItemsSource = StatisticsList;
                PopularData.ItemsSource = PopularList;
            }
        }

        private RelayCommand PreviousPageCommand;

        private void GoPreviousPage()
        {
            int value;
            int.TryParse(PageNumber.Text, out value);
            if (value > 1)
            {
                value--;
                PageNumber.Text = value.ToString();
                FilterFromDB();
            }
        }

        private RelayCommand NextPageCommand;

        private void GoNextPage()
        {
            int value;
            int.TryParse(PageNumber.Text, out value);
            value++;
            PageNumber.Text = value.ToString();
            FilterFromDB();
        }

        private void RatingControl_RatingValueChanged(object sender, Common.Controls.Rate.RatingEventArgs e)
        {
            using (ParadygmatyEntities context = new ParadygmatyEntities())
            {
                var rating = context.RATINGS.First(row => row.ID == 1);
                rating.RATINGS = e.Value;
                context.SaveChanges();
            }
        }
    }
}
