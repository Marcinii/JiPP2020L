using KonwerterJednostek.Logic;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace KonwerterJednostek.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<stats> st;
        int skip = 0;
        public MainWindow()
        {
            InitializeComponent();
            converterComboBox.ItemsSource = new ConverterService().GetConverters();
            statsComboBox.ItemsSource = new ConverterService().GetConverters();
            appRate.RateValue = new rateAppService().GetValue();
        }

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            string unitFrom = unitFromCombobox.Text;
            string unitTo = unitToCombobox.Text;
            if (decimal.TryParse(inputTextBox.Text, out decimal value) && !String.IsNullOrEmpty(unitFrom) && !String.IsNullOrEmpty(unitTo))
            {
                decimal result = ((IConverter)converterComboBox.SelectedItem).Convert(unitFrom, unitTo, value);
                outputTextBlock.Text = result + unitTo.ToUpperInvariant();
                DatabaseService.InsertDataUsingEF(((IConverter)converterComboBox.SelectedItem).Name, unitFrom, unitTo, DateTime.Now, value, result);
            }
            else if (String.IsNullOrEmpty(unitFrom) || String.IsNullOrEmpty(unitTo))
            {
                MessageBox.Show("Wprowadź poprawne jednostki.", null, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Wprowadź poprawne wartości.", null, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void converterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFromCombobox.ItemsSource = ((IConverter)converterComboBox.SelectedItem).Units;
            unitToCombobox.ItemsSource = ((IConverter)converterComboBox.SelectedItem).Units;
        }

        private void timeConverterButton_Click(object sender, RoutedEventArgs e)
        {
            if(timeConverterTextBox.Text.Length == 5)
            {
                string res = new TimeConverter().Convert(timeConverterTextBox.Text);
                timeConverterResult.Text = res;
            }
            else
            {
                MessageBox.Show("Format godziny powinien wyglądać XX:XX", null, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void timeConverterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(timeConverterTextBox.Text.Length == 5)
            {
                int hours = new TimeConverter().GetHour(timeConverterTextBox.Text);
                int mins = new TimeConverter().GetMinute(timeConverterTextBox.Text);
                if (clockRotation != null && hours >= 0 && hours <= 23 && mins >= 0 && mins <= 59)
                {
                    clockRotation.Angle = ((double)hours * 30d) + ((double)mins * 0.5d) + 90d;
                }
            }
        }

        private void databaseButton_Click(object sender, RoutedEventArgs e)
        {
            statystykiEntities1 db = new statystykiEntities1();
            st = db.stats.ToList();
            List<stats> ls = new List<stats>();
            if (dateFromPicker.SelectedDate.HasValue && dateToPicker.SelectedDate.HasValue && statsComboBox.SelectedItem != null)
            {
                foreach (stats set in st)
                {
                    if (set.convDate.Value.Date >= dateFromPicker.SelectedDate.Value.Date && set.convDate.Value.Date <= dateToPicker.SelectedDate.Value.Date &&
                        set.convType == ((IConverter)statsComboBox.SelectedItem).Name)
                    {
                        ls.Add(set);
                    }
                }
                if (threeValueCheckBox.IsChecked.Value)
                {
                    var ks = (from s in ls
                              group s by new
                              {
                                  s.convType,
                                  s.unitFrom,
                                  s.unitTo,
                                  s.convValue,
                                  s.convertedValue
                              }
                 into grp
                              select new
                              {
                                  convType = grp.Key.convType,
                                  unitFrom = grp.Key.unitFrom,
                                  unitTo = grp.Key.unitTo,
                                  convValue = grp.Key.convValue,
                                  convertedValue = grp.Key.convertedValue,
                                  Ilosc = grp.Count()
                              }).Take(3);
                    ks = ks.OrderByDescending(s => s.Ilosc);
                    outputDataGrid.ItemsSource = ks;
                }
                else
                {
                    outputDataGrid.ItemsSource = ls.Take(20);
                    st = ls;
                }
            }
            else if (dateFromPicker.SelectedDate.HasValue && dateToPicker.SelectedDate.HasValue)
            {
                foreach (stats set in st)
                {
                    if (set.convDate.Value.Date >= dateFromPicker.SelectedDate.Value.Date && set.convDate.Value.Date <= dateToPicker.SelectedDate.Value.Date)
                    {
                        ls.Add(set);
                    }
                }
                if (threeValueCheckBox.IsChecked.Value)
                {
                    var ks = (from s in ls
                              group s by new
                              {
                                  s.convType,
                                  s.unitFrom,
                                  s.unitTo,
                                  s.convValue,
                                  s.convertedValue
                              }
                 into grp
                              select new
                              {
                                  convType = grp.Key.convType,
                                  unitFrom = grp.Key.unitFrom,
                                  unitTo = grp.Key.unitTo,
                                  convValue = grp.Key.convValue,
                                  convertedValue = grp.Key.convertedValue,
                                  Ilosc = grp.Count()
                              }).Take(3);
                    ks = ks.OrderByDescending(s => s.Ilosc);
                    outputDataGrid.ItemsSource = ks;
                }
                else
                {
                    outputDataGrid.ItemsSource = ls.Take(20);
                    st = ls;
                }
            }
            else if (statsComboBox.SelectedItem != null)
            {
                foreach (stats set in st)
                {
                    if (set.convType == ((IConverter)statsComboBox.SelectedItem).Name)
                    {
                        ls.Add(set);
                    }
                }
                if (threeValueCheckBox.IsChecked.Value)
                {
                    var ks = (from s in ls
                              group s by new
                              {
                                  s.convType,
                                  s.unitFrom,
                                  s.unitTo,
                                  s.convValue,
                                  s.convertedValue
                              }
                 into grp
                              select new
                              {
                                  convType = grp.Key.convType,
                                  unitFrom = grp.Key.unitFrom,
                                  unitTo = grp.Key.unitTo,
                                  convValue = grp.Key.convValue,
                                  convertedValue = grp.Key.convertedValue,
                                  Ilosc = grp.Count()
                              }).Take(3);
                    ks = ks.OrderByDescending(s => s.Ilosc);
                    outputDataGrid.ItemsSource = ks;
                }
                else
                {
                    outputDataGrid.ItemsSource = ls.Take(20);
                    st = ls;
                }
            }
            else
            {
                outputDataGrid.ItemsSource = st.Take(20);
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (st != null)
            {
                if (st.Skip(skip).Count() > skip && st.Skip(skip).Count() > 20)
                {
                    skip += 20;
                    Console.WriteLine(skip);
                    outputDataGrid.ItemsSource = st.Skip(skip);
                }
            }
        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            if (st != null)
            {
                if (st.Take(skip).Count() >= skip && skip - 20 >= 0)
                {
                    skip -= 20;
                    Console.WriteLine(skip);
                    outputDataGrid.ItemsSource = st.Skip(skip).Take(20);
                }
            }
        }

        private void appRate_RateValueChanged(object sender, Common.Controls.RateEventArgs e)
        {
            DatabaseService.InsertRateUsingEF(appRate.RateValue);
        }
    }
}
