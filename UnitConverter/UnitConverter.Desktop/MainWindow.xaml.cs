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
using UnitConverter.Logic;

namespace UnitConverter.Desktop
{
    public partial class MainWindow : Window
    {
        List<IConverter> converters = new List<IConverter>
        {
            new ByteConverter(),
            new DistanceConverter(),
            new MassConverter(),
            new TemperatureConverter(),
            new TimeConverter(),
        };

        public MainWindow()
        {
            InitializeComponent();
            ConverterComboBox.ItemsSource = converters;
            PrepareRelay();
            LoadLastRating();
        }

        private void PrepareRelay()
        {
            ConvertCmd = new RelayCommand(obj => Convert());
            ConvertButton.Command = ConvertCmd;
            StatsWindowCmd = new RelayCommand(obj => StatsWindow());
            StatisticsButton.Command = StatsWindowCmd;
        }

        private void ConverterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserInputTextBox.Clear();
            IConverter current = (IConverter)ConverterComboBox.SelectedItem;
            FromUnitComboBox.ItemsSource = current.Units;
            ToUnitComboBox.ItemsSource = current.Units;
        }
        
        private void ErrorText(string message)
        {
            OutputTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(0xee, 0x11, 0x11));
            OutputTextBlock.Text = message;
        }

        private void SetText(Tuple<double, string> output)
        {
            OutputTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(0x00, 0x00, 0x00));
            OutputTextBlock.Text = output.Item1.ToString() + ' ' + output.Item2;
        }

        private RelayCommand ConvertCmd;
        private void Convert()
        {
            if (ConverterComboBox.SelectedIndex == -1)
            {
                ErrorText("No converter selected");
                return;
            }
            IConverter current = (IConverter)ConverterComboBox.SelectedItem;
            try 
            {
                if (FromUnitComboBox.SelectedIndex == -1)
                {
                    ErrorText("No from unit selected");
                    return;
                }
                string input_unit = FromUnitComboBox.SelectedItem.ToString();

                if (ToUnitComboBox.SelectedIndex == -1)
                {
                    ErrorText("No final unit selected");
                    return;
                }
                string output_unit = ToUnitComboBox.SelectedItem.ToString();
                
                var user_input = UserInputTextBox.Text;
                if (user_input.Contains(':'))
                {
                    user_input = user_input.Replace(':', '.');    
                }
                double input_value = Double.Parse(UserInputTextBox.Text);

                var output = current.Convert(input_value, input_unit, output_unit);
                SetText(output);
                SaveRecordToDb(current.Name, input_value, input_unit, output.Item1, output_unit);
                
            }
            catch (System.FormatException) 
            {
                ErrorText("Invalid value " + UserInputTextBox.Text);
            }
        }

        private RelayCommand StatsWindowCmd;
        private void StatsWindow()
        {
            StatisticsWindow stats = new StatisticsWindow();
            stats.Show();
        }

        private void SaveRecordToDb(
            string converter,
            double input_value, 
            string input_unit, 
            double output_value, 
            string output_unit
            )
        {
            using (var context = new ConversionsDb())
            {
                context.Conversions.Add(new Conversion
                {
                    converter = converter,
                    date = DateTime.Now,
                    input_value = (decimal)input_value,
                    input_unit = input_unit,
                    output_value = (decimal)output_value,
                    output_unit = output_unit,
                });
                context.SaveChanges();
            }
        }

        private void RateControl_UserRatingChanged(object sender, CustomControls.RateControl.UserRatingEventArgs e)
        {
            var rating = e.UserRating;
            RateControl.FillColor(rating);
            SaveRatingToDb(rating);
        }

        private void SaveRatingToDb(int rating)
        {
            using(var context = new RatingDb())
            {
                context.Ratings.Add(new Rating
                {
                    rating1 = rating
                });
                context.SaveChanges();
            }
        }

        private void LoadLastRating()
        {
            using (var context = new RatingDb())
            {
                var max = context.Ratings.Max(r => r.id);
                var last_rating = context.Ratings.Where(r => r.id == max).FirstOrDefault();
                RateControl.FillColor(last_rating.rating1);
            }
        }
    }
}
