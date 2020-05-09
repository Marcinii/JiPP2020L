using CommonControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using unitConverterv2;
using UnitConverterv2.Logic;

using Clock = unitConverterv2.Clock;



namespace UnitConverter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int page;
        string WhereTextIs;
        

        public MainWindow()
        {
            InitializeComponent();

            firstList.ItemsSource = new ConverterService().getConverters();
            PoRodzaju.ItemsSource = new ConverterService().getConverters();



            using (ConverterDataEntities context = new ConverterDataEntities())
            {

                List<Stats> stats = context.Stats.OrderBy(e => e.ID).Skip(0).Take(20).ToList();
                ConverterData.ItemsSource = stats.ToList();
            }



            ConvertCommand = new RelayCommand(e => Convert(), e => firstList.SelectedItem != null && secondList.SelectedItem != null && thirdList.SelectedItem != null 
            && string.IsNullOrEmpty(inputTextBox.Text) != true && decimal.TryParse(inputTextBox.Text, out decimal CheckIstrue));
            ActionButton.Command = ConvertCommand;




            using (OcenaAplikacjiEntities context = new OcenaAplikacjiEntities())
            {
                ocena allValue = context.ocena.ToList().Last();
                RateControl.RateValue = allValue.Ocena1;
            }

           

        }

        private RelayCommand ConvertCommand;
        
        private void Convert()
        {
            string inputText = inputTextBox.Text;
            inputText = inputText.ToString().Replace(':', '.');
            decimal inputValue = decimal.Parse(inputText, CultureInfo.InvariantCulture);
           
            decimal result = decimal.Round(((IConvert)firstList.SelectedItem).Convert(secondList.SelectedIndex, thirdList.SelectedIndex, inputValue), 6);
            string resultToString = "";

            if (((IConvert)firstList.SelectedItem).Name == "Clock Converter")
            {
                Clock clockField = new Clock();
                resultToString = clockField.valueAsClock(resultToString, result);
                secondDot.Angle = (double)result * 30;
                clockMarker.Angle = (double)Math.Floor(result) * 30;


            }

            else if (((IConvert)firstList.SelectedItem).Name != "Clock Converter")
            {
                resultToString = result.ToString();
                resultToString += " " + thirdList.SelectedItem.ToString();
            }

            resultTextBlock.Text = resultToString;

            if (resultTextBlock.Text != "")
            {
                resultTextBlock.Background = Brushes.BlanchedAlmond;
            }

            string getType, getFromUnit, getToUnit;
            getType = ((IConvert)firstList.SelectedItem).Name;
            getFromUnit = secondList.SelectedItem.ToString();
            getToUnit = thirdList.SelectedItem.ToString();



            using (ConverterDataEntities context = new ConverterDataEntities())
            {
                Stats newStat = new Stats()
                {
                    Type = getType,
                    FromUnit = getFromUnit,
                    ToUnit = getToUnit,
                    ConvertHour = DateTime.Now,


                };
                context.Stats.Add(newStat);
                context.SaveChanges();

            }


            inputTextBox.Text = "";

        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            secondList.ItemsSource = ((IConvert)firstList.SelectedItem).Units;
            thirdList.ItemsSource = ((IConvert)firstList.SelectedItem).Units;


            if (((IConvert)firstList.SelectedItem).Name == "Clock Converter")
            {
                secondList.SelectedIndex = 1;
                thirdList.SelectedIndex = 0;

            }


        }

        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string inputText = inputTextBox.Text;
            decimal inputValue;
            bool success = decimal.TryParse(inputText, out inputValue);
            if (success)
            {

                if (((IConvert)firstList.SelectedItem).Name == "Clock Converter")
                {
                    if (inputValue > 24 || inputValue < 0)
                    {
                        inputTextBox.Background = Brushes.Red;
                    }
                    else
                    {
                        inputTextBox.Background = Brushes.Green;
                    }
                }
            }
            else
            {
                inputTextBox.Background = Brushes.White;
            }
        }

        public void ShowNextButton_Click(object sender, RoutedEventArgs e)
        {

            ShowPreviousButton.Opacity = 100;

            page += 20;
            getAllStats(page);
        }

        private void ShowPreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (page >= 20)
            {
                page -= 20;
                getAllStats(page);
            }
            else
            {

            }
        }

        private void PoRodzaju_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WhereTextIs = ((IConvert)PoRodzaju.SelectedItem).Name;

            getAllStats(page, WhereTextIs);
        }

        public void getAllStats(int ShowPage = 0, string bySelectedItem = "", string Date1 = "Data Od", string Date2 = "Data do")
        {

            using (ConverterDataEntities context = new ConverterDataEntities())
            {

                List<Stats> stats = context.Stats.OrderBy(e => e.ID).Skip(ShowPage).Take(20).ToList();
                stats = context.Stats.SqlQuery("SELECT * FROM Stats WHERE type LIKE '%" + bySelectedItem + "%'").Skip(ShowPage).Take(20).ToList();
                ConverterData.ItemsSource = stats;

               


            }


        }

        private void Data_od_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }

        private void Data_od_TextChanged(object sender, TextChangedEventArgs e)
        {
            getAllStats(page, "", Data_od.Text, Data_Do.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RateMe_RateValueChanged(object sender, RateMe.RateEventArgs e)
        {
            MessageBox.Show("DZIAL");
            using (OcenaAplikacjiEntities context = new OcenaAplikacjiEntities())
            {
                context.ocena.SqlQuery("UPDATE ocena SET Ocena =" + e.Value);
            }

        }
    }
}


