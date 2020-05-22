using CommonControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
            bool success = decimal.TryParse(inputText, out decimal inputValue);
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

        private void loadFromBaseButton_Click_1(object sender, RoutedEventArgs e)
        {


            LoaderBase.Visibility = Visibility.Visible;
            ellipse6.Visibility = Visibility.Visible;
            ellipse7.Visibility = Visibility.Visible;
            ellipse8.Visibility = Visibility.Visible;
            ellipse9.Visibility = Visibility.Visible;
            ellipse10.Visibility = Visibility.Visible;
            ellipse11.Visibility = Visibility.Visible;
            ellipse12.Visibility = Visibility.Visible;
            ellipse13.Visibility = Visibility.Visible;
            LoaderAnimation(1);
            Thread thread = new Thread(() => loadFromBase());
            thread.Start();

        }

        private void loadFromBase()
        {
            Thread.Sleep(10000);
            LoaderAnimation(0);
            
            Dispatcher.Invoke(() => ellipse6.Visibility = Visibility.Hidden);
            Dispatcher.Invoke(() => ellipse7.Visibility = Visibility.Hidden);
            Dispatcher.Invoke(() => ellipse9.Visibility = Visibility.Hidden);
            Dispatcher.Invoke(() => ellipse8.Visibility = Visibility.Hidden);
            Dispatcher.Invoke(() => ellipse10.Visibility = Visibility.Hidden);
            Dispatcher.Invoke(() => ellipse11.Visibility = Visibility.Hidden);
            Dispatcher.Invoke(() => ellipse12.Visibility = Visibility.Hidden);
            Dispatcher.Invoke(() => ellipse13.Visibility = Visibility.Hidden);
            Dispatcher.Invoke(() => LoaderBase.Visibility = Visibility.Hidden);

            using (ConverterDataEntities context = new ConverterDataEntities())
            {

                List<Stats> stats = context.Stats.OrderBy(x => x.ID).Skip(0).Take(20).ToList();
                Dispatcher.Invoke(() => ConverterData.ItemsSource = stats.ToList());
            }


        }

        public void LoaderAnimation(int loaderInfo)
        {
            Storyboard storyboard = this.FindResource("LoaderStoryBoard") as Storyboard;

            if (loaderInfo == 1)
            {
                Dispatcher.Invoke(() => storyboard.Begin());
            }
            else
            {
                Dispatcher.Invoke(() => storyboard.Stop());

            }


        }
    }
}


