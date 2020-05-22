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
using uniConverter.Desktop;
using UniConverter;
using unitConverter.Logic;

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

            combobox.ItemsSource = new ConverterService().GetConverters();

            using (ocenaEntities context = new ocenaEntities())
            {
                tabela ocena = context.tabela.ToList().Last();
                rateControl.RateValue = ocena.ocena;
            }

                //rateControl.RateValue;

            ConvertCommand = new RelayCommand(obj => Convert(), obj =>
                comboboxSecond.SelectedItem !=null && comboboxSecond.SelectedItem != null && string.IsNullOrEmpty(inputTextBox.Text) !=true);
            ActionButton.Command = ConvertCommand;
        }

        private RelayCommand ConvertCommand;

        private void Convert()
        {
            string inputText = inputTextBox.Text;
            decimal convertValue = decimal.Parse(inputText);
            decimal result = decimal.Round(((Iconventer)combobox.SelectedItem).converterCalculator(comboboxSecond.SelectedIndex, comboboxThird.SelectedIndex, convertValue),6);
            resultTextBlock.Text = result.ToString();

            string getType, getFromUnit, getToUnit;
            getType = ((Iconventer)combobox.SelectedItem).Name;
            getFromUnit = comboboxSecond.SelectedItem.ToString();
            getToUnit = comboboxThird.SelectedItem.ToString();
            double getValue, getResult;
            getValue = double.Parse(inputText);
            getResult = double.Parse(resultTextBlock.Text);
         


           /* using (ConverterDataEntities context = new ConverterDataEntities())
            {
                Stats newStat = new Stats()
                {
                    Type = getType,
                    FromUnit = getFromUnit,
                    ToUnit = getToUnit,
                    ConvertHour = DateTime.Now,
                    Value = getValue,
                    Result = getResult,

                };
                context.Stats.Add(newStat);
                context.SaveChanges();

            }
            getAllStats(page, "");
            */
        }

        private void combobox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            comboboxSecond.ItemsSource = ((Iconventer)combobox.SelectedItem).Units;
            comboboxThird.ItemsSource = ((Iconventer)combobox.SelectedItem).Units;
           


        }

        public void getAllStats(int ShowPage = 0, string bySelectedItem = "")
        {
           /* using (ConverterDataEntities context = new ConverterDataEntities())
            {

                List<Stats> stats = context.Stats.ToList();
                stats = context.Stats.SqlQuery("SELECT * FROM Stats WHERE type LIKE '%" + bySelectedItem + "%'").Skip(ShowPage).Take(20).ToList();
                ConverterData.ItemsSource = stats;

                
            }*/


        }

        

        private void Nextpage_Click(object sender, RoutedEventArgs e)
        {
            page += 20;
            getAllStats(page,WhereTextIs);
           
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            page -= 20;
            getAllStats(page, WhereTextIs);
           
        }

       

        private void ConverterSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            WhereTextIs = ConverterSearchBox.Text;
            getAllStats(page, WhereTextIs);
        }

        private void ConverterData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RateControl_RateValueChanged(object sender, CommonControl.RateEventArgs e)
        {
            using (ocenaEntities context = new ocenaEntities())
            {
                context.tabela.SqlQuery("Update tabela SET ocena=" + e.Value);
            }
        }
    }
}