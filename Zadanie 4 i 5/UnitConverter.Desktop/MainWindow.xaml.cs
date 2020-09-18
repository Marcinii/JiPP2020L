using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UnitConverter.RatingControl;
using unitConverterv2;
using UnitConverterv2.Logic;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FirstList.ItemsSource = new ConverterService().getConverters();
            ConverterTypeSortingList.ItemsSource = new ConverterService().getConverters();
            int index = FirstList.SelectedIndex;

            RatingControl.Rating = Rating.LoadLastRating();

            ConvertCommand = new RelayCommand(obj => ConvertAction(), obj =>
                FirstList.SelectedIndex != -1 && SecondList.SelectedIndex != -1);
            ActionButton.Command = ConvertCommand;

            ShowTop3Command = new RelayCommand(obj => ShowTop3());
            Top3Button.Command = ShowTop3Command;
        }
        private RelayCommand ConvertCommand;
        private RelayCommand ShowTop3Command;

        private void ConvertAction()
        {
            string inputText = InputTextBox.Text;
            inputText = inputText.ToString().Replace(':', '.');
            decimal inputValue = decimal.Parse(inputText, CultureInfo.InvariantCulture);

            decimal result = decimal.Round(((IConvert)FirstList.SelectedItem).Convert(SecondList.SelectedIndex, ThirdList.SelectedIndex, inputValue), 6);
            string resultToString;

            if (((IConvert)FirstList.SelectedItem).Name == "Clock Converter")
            {
                resultToString = result.ToString().Replace(',', ':');
            }
            else
            {
                resultToString = result.ToString();
            }

            ResultTextBlock.Text = resultToString;

            if (ResultTextBlock.Text != "")
            {
                ResultTextBlock.Background = Brushes.BlanchedAlmond;
            }

            if (((IConvert)FirstList.SelectedItem).Name == "Clock Converter")
            {

                if (result - (int)result > (decimal)0.60)
                {
                    MessageBox.Show("Podane minuty większe od 60");
                    throw new System.ArgumentException("Wartość nie może być większa od 24 i od 0 ");
                }
                secondDot.Angle = (double)result * 30;
                clockMarker.Angle = (double)Math.Floor(result) * 30;

                if (inputValue > 24 || inputValue < 0)
                {
                    MessageBox.Show("Wartość nie może być większa od 24 i mniejsza od 0");
                    throw new System.ArgumentException("Wartość nie może być większa od 24 i od 0 ");
                }
                if (inputValue < 13) ResultTextBlock.Text += " AM";
                else ResultTextBlock.Text += " PM";
            }
            else
            {
                ResultTextBlock.Text += " " + ThirdList.SelectedItem.ToString();
            }

            //Baza danych
            Conversion conversion = new Conversion()
            {
                Date = DateTime.Now,

                Type = FirstList.Text,
                UnitFrom = SecondList.Text,
                UnitTo = ThirdList.Text,
                ValueFrom = inputValue,
                ValueTo = result,

            };
            conversion.Save();
            InputTextBox.Text = "";
        }

        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SecondList.ItemsSource = ((IConvert)FirstList.SelectedItem).Units;
            ThirdList.ItemsSource = ((IConvert)FirstList.SelectedItem).Units;

            if (((IConvert)FirstList.SelectedItem).Name == "Clock Converter")
            {
                SecondList.SelectedIndex = 1;
                ThirdList.SelectedIndex = 0;
            }
        }

        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool success = decimal.TryParse(InputTextBox.Text, out decimal inputValue);
            if (success)
            {
                if (((IConvert)FirstList.SelectedItem).Name == "Clock Converter")
                {
                    if (inputValue > 24 || inputValue < 0)
                    {
                        InputTextBox.Background = Brushes.Red;
                    }
                    else
                    {
                        InputTextBox.Background = Brushes.Green;
                    }
                }
            }
            else
            {
                InputTextBox.Background = Brushes.White;
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(PageTextBox.Text, out int page))
            {
                if (page >= 1)
                {
                    if ((bool)TypeFilterCheckBox.IsChecked && (bool)DateFilterCheckBox.IsChecked)
                    {
                        ConversionsList.ItemsSource = Conversion.LoadConversionPage(page, ConverterTypeSortingList.Text, (DateTime)FirstDate.SelectedDate, (DateTime)SecondDate.SelectedDate);
                    }
                    else if ((bool)TypeFilterCheckBox.IsChecked)
                    {
                        ConversionsList.ItemsSource = Conversion.LoadConversionPage(page, ConverterTypeSortingList.Text);
                    }
                    else if ((bool)DateFilterCheckBox.IsChecked)
                    {
                        ConversionsList.ItemsSource = Conversion.LoadConversionPage(page, (DateTime)FirstDate.SelectedDate, (DateTime)SecondDate.SelectedDate);
                    }
                    else
                    {
                        ConversionsList.ItemsSource = Conversion.LoadConversionPage(page);
                    }
                }
            }
        }

        private void ShowTop3()
        {
            using (ConverterDataModel context = new ConverterDataModel())
            {
                ConversionsList.ItemsSource = context.Conversions.GroupBy(x => new { x.Type }).Select(x => new { Type = x.Key, Count = x.Count() }).OrderByDescending(x => x.Count).Take(3).ToList();

            }
        }

        private void Rating_RateValueChange(object sender, RateEventArgs e)
        {
            Rating rating = new Rating
            {
                Value = e.Value
            };
            rating.Save();
        }
    }
}


