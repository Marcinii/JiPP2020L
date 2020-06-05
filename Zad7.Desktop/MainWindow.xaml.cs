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
using Zad7.Dll;

namespace Zad7.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FunctionSelectorComboBox.ItemsSource = (new CalculatorService()).GetFunctions();
            FunctionSelectorComboBox.DisplayMemberPath = "Name";


            LoadHistory();

        }

        private void FunctionSelectorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            InputStackPanel.Children.Clear();

            if(((ComboBox)sender).SelectedIndex > -1)
            {

                foreach (var name in ((IMathFunction)FunctionSelectorComboBox.SelectedItem).ParameterNames)
                {
                    InputStackPanel.Children.Add(new TextBlock() { Text = name });
                    InputStackPanel.Children.Add(new TextBox() { Height=30 });
                    ActionsGrid.Visibility = Visibility.Visible;

                    ((MainWindow)System.Windows.Application.Current.MainWindow).UpdateLayout();
                }


            }
            else
            {
                ActionsGrid.Visibility = Visibility.Hidden;
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            List<double> p = new List<double>();

            foreach(var item in InputStackPanel.Children)
            {
                if(item.GetType() == typeof(TextBox))
                {
                    Double temp;

                    Double.TryParse(((TextBox)item).Text, out temp);

                    p.Add(temp);
                }
            }

            IMathFunction f = ((IMathFunction)FunctionSelectorComboBox.SelectedItem);


            string result = f.Calculate(p.ToArray()).ToString();

            CalculationResultTextBlock.Text = result;

            string par = String.Empty;

            for(int i = 0; i< p.Count; i++)
            {
                par += f.ParameterNames[i] + "=" + p[i] + ",";
            }

            par = par.Remove(par.LastIndexOf(','), 1);


            AddToHistory(f.Name, par, result);


        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            foreach (var item in InputStackPanel.Children)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    ((TextBox)item).Text = string.Empty;
                }
            }
        }

        private void AddToHistory(string _Name, string _Parameters, string _Result)
        {
            Dispatcher.Invoke(() => LoadingScreen.Visibility = Visibility.Visible);

            Task t1 = new Task(() =>
            {


                using (var db = new SQLiteDbContext())
                {

                    History h = new History() { Name = _Name, Parameters = _Parameters, Result = _Result };
                    db.History.Add(h);
                    db.SaveChanges();
                }

                LoadHistory();

            });

            t1.Start();

        }


        void LoadHistory()
        {
            Dispatcher.Invoke(() => LoadingScreen.Visibility = Visibility.Visible);

            Task t1 = new Task(() =>
            {

                using (var db = new SQLiteDbContext())
                {

                    var h = db.History.ToList();


                    Dispatcher.Invoke(() => HistoryDataGrid.ItemsSource = h);


                }


                Dispatcher.Invoke(() => LoadingScreen.Visibility = Visibility.Hidden);

            });
            t1.Start();

        }

    }



}
