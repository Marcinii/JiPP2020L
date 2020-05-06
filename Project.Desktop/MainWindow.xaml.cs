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
using UnitConverter.Desktop;
using static Common.Controls.Rate;

namespace Project.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private HistoryWindow hwindow;

        public MainWindow()
        {
            InitializeComponent();

            ConverterListComboBox.ItemsSource = new ConverterService().GetConverters();
            ConverterListComboBox.DisplayMemberPath = "Name";



            hwindow = new HistoryWindow();

            RateButtons.RateValueChanged += RateButtons_RateValueChanged;

            using (var db = new jippEntities())
            {

                RateButtons.RateValue = db.ProgramValues.First().Value;
            }

            ConvertCommand = new RelayCommand(obj => Convert(), obj=> ValueToConvertTextBlock.Text.Length > 0 && ConvertFromListComboBox.SelectedItem != null && ConvertToListComboBox.SelectedItem != null);

            ConvertButton.Command = ConvertCommand;


        }

        private void RateButtons_RateValueChanged(object sender, RateEventArgs e)
        {
            using (var db = new jippEntities())
            {
                db.ProgramValues.First().Value = RateButtons.RateValue;
                db.SaveChanges();
            }
        }

        private void ConverterListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvertFromListComboBox.ItemsSource = ((IConverter)ConverterListComboBox.SelectedItem).Units;
            ConvertToListComboBox.ItemsSource = ((IConverter)ConverterListComboBox.SelectedItem).Units;

            if (ConverterListComboBox.SelectedItem.GetType() == typeof(ClockConverter))
                ClockGrid.Visibility = Visibility.Visible;
            else
                ClockGrid.Visibility = Visibility.Hidden;

        }


        private RelayCommand ConvertCommand;


        private void Convert()
        {
            
            try
            {
                ResultTextBlock.Text = string.Empty;
                //string result = ValueToConvertTextBlock.Text + " " + ConvertFromListComboBox.SelectedValue + " = ";
                string result = ((IConverter)ConverterListComboBox.SelectedItem)
                     .Convert(
                        ConvertFromListComboBox.SelectedValue?.ToString(),
                        ConvertToListComboBox.SelectedValue?.ToString(),
                        ValueToConvertTextBlock.Text);
                //result += " " + ConvertToListComboBox.SelectedValue;
                ResultTextBlock.Text = result;


                if (ConverterListComboBox.SelectedItem.GetType() == typeof(ClockConverter))
                {
                    DateTime temp = DateTime.Parse(result);
                    HoursRectangle.RenderTransform = new RotateTransform((360/12) * temp.Hour);
                    MinutesRectangle.RenderTransform = new RotateTransform((360 / 60) * temp.Minute);
                }

                
                if(!ConvertFromListComboBox.SelectedValue.Equals(null) && !ConvertToListComboBox.SelectedValue.Equals(null))
                    SaveLog((IConverter)ConverterListComboBox.SelectedItem, ConvertFromListComboBox.SelectedValue.ToString(), ConvertToListComboBox.SelectedValue.ToString(), ValueToConvertTextBlock.Text, result);



            }
            catch (FormatException)
            {
                ResultTextBlock.Text = string.Empty;
            }
        }


        private void SaveLog(IConverter type, string convertFrom, string ConvertTo, string valueToConvert, string valueAfterConversion)
        {
          
            using (var db = new jippEntities())
            {
                var newItem = new ConversionHistory()
                {
                    Converter = type.Name,
                    UnitFrom = convertFrom,
                    UnitTo = ConvertTo,
                    ValueBefore = valueToConvert,
                    ValueAfter = valueAfterConversion,
                    Date = DateTime.Now
                };

                db.ConversionHistory.Add(newItem);

                db.SaveChanges();
            }
        }

        

        private void ToggleHistoryButton_Click(object sender, RoutedEventArgs e)
        {

            hwindow.Show();
            hwindow.LoadHistory();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            hwindow.Close();

            Application.Current.Shutdown();
        }
    }
}
