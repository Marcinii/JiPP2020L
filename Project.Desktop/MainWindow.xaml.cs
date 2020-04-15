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

            ConverterListComboBox.SelectedIndex = 0;
            ValueToConvertTextBlock.Text = "0";

            hwindow = new HistoryWindow();
        }

        private void ConverterListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvertFromListComboBox.ItemsSource = ((IConverter)ConverterListComboBox.SelectedItem).Units;
            ConvertToListComboBox.ItemsSource = ((IConverter)ConverterListComboBox.SelectedItem).Units;
            ConvertFromListComboBox.SelectedIndex = 0;
            ConvertToListComboBox.SelectedIndex = 1;

            if (ConverterListComboBox.SelectedItem.GetType() == typeof(ClockConverter))
                ClockGrid.Visibility = Visibility.Visible;
            else
                ClockGrid.Visibility = Visibility.Hidden;

        }

        private void Recalculate()
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

        private void ValueToConvertTextBlock_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Recalculate();
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
