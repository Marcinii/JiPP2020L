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
        public MainWindow()
        {
            InitializeComponent();

            ConverterListComboBox.ItemsSource = new ConverterService().GetConverters();
            ConverterListComboBox.DisplayMemberPath = "Name";

            ConverterListComboBox.SelectedIndex = 0;
            ValueToConvertTextBlock.Text = "0";

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


            Recalculate();
        }

        private void Recalculate()
        {
            
            try
            {
                ResultTextBlock.Text = string.Empty;
                //string result = ValueToConvertTextBlock.Text + " " + ConvertFromListComboBox.SelectedValue + " = ";
                string result = ((IConverter)ConverterListComboBox.SelectedItem)
                     .Convert(
                        (string)ConvertFromListComboBox.SelectedValue,
                        (string)ConvertToListComboBox.SelectedValue,
                        ValueToConvertTextBlock.Text);
                //result += " " + ConvertToListComboBox.SelectedValue;
                ResultTextBlock.Text = result;


                if (ConverterListComboBox.SelectedItem.GetType() == typeof(ClockConverter))
                {
                    DateTime temp = DateTime.Parse(result);
                    HoursRectangle.RenderTransform = new RotateTransform((360/12) * temp.Hour);
                    MinutesRectangle.RenderTransform = new RotateTransform((360 / 60) * temp.Minute);
                }

            }
            catch (FormatException)
            {
                ResultTextBlock.Text = string.Empty;
            }
        }

        private void ValueToConvertTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            Recalculate();
        }

        private void ConvertFromListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Recalculate();
        }

        private void ConvertToListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Recalculate();
        }
    }
}
