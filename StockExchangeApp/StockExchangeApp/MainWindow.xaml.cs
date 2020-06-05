using StockExchangeApp.Desktop;
using StockExchangeApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StockExchangeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int temp = 0;
        DateTime datetimeValue;
        int paginationVariable = 0;

        public MainWindow()
        {
            InitializeComponent();
            countryCombobox.ItemsSource = new StockService().GetCountriesList().Distinct();
            numberCombobox.ItemsSource = new int[] { 1, 2, 3, 4 };
            typeOfTransactionCombobox.ItemsSource = new string[] { "buy", "sell" };

            CommissionCommand = new RelayCommand(obj => Commission(),
                obj => availableStocksCombobox_1.SelectedItem != null
                && dateDatepicker.SelectedDate != null
                && timeTextbox.SelectedText != null);
            resultButton.Command = CommissionCommand;

            RefreshCommand = new RelayCommand(obj => Refresh());
            refreshButton.Command = RefreshCommand;

            PaginationButtonPrevCommand = new RelayCommand(obj => PaginationButtonPrev());
            paginationButtonPrev.Command = PaginationButtonPrevCommand;

            PaginationButtonNextCommand = new RelayCommand(obj => PaginationButtonNext());
            paginationButtonNext.Command = PaginationButtonNextCommand;

            LoaderCancelCommand = new RelayCommand(obj => LoaderCancel());
            loaderCancelButton.Command = LoaderCancelCommand;
        }

        private void setCorrectDate()
        {
            int year = dateDatepicker.SelectedDate.Value.Year;
            int month = dateDatepicker.SelectedDate.Value.Month;
            int day = dateDatepicker.SelectedDate.Value.Day;
            string[] splitTime = timeTextbox.Text.Split(',', ':', '-', ' ', '.');
            int hour, minutes;
            Int32.TryParse(splitTime[0], out hour);
            if (splitTime.Length > 1)
            {
                Int32.TryParse(splitTime[1], out minutes);
            }
            else
            {
                minutes = 0;
            }
            datetimeValue = new DateTime(year, month, day);
            TimeSpan ts;

            if (hour < 9)
            {
                datetimeValue = datetimeValue.AddDays(-1);
                ts = new TimeSpan(17, 00, 0);
                datetimeValue = datetimeValue.Date + ts;
            }
            else if ((hour > 17 || (hour == 16 && minutes > 60)) && datetimeValue.ToString("yyyy/MM/dd") != DateTime.Now.ToString("yyyy/MM/dd"))
            {
                datetimeValue = datetimeValue.AddDays(1);
                ts = new TimeSpan(9, 00, 0);
                datetimeValue = datetimeValue.Date + ts;
            }
            else
            {
                ts = new TimeSpan(hour, minutes, 0);
                datetimeValue = datetimeValue.Date + ts;
            }
        }

        private RelayCommand CommissionCommand;
        private RelayCommand RefreshCommand;
        private RelayCommand PaginationButtonPrevCommand;
        private RelayCommand PaginationButtonNextCommand;
        private RelayCommand LoaderCancelCommand;

        private void CountryCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            availableStocksCombobox_1.ItemsSource =
                new StockService().GetStocksList(countryCombobox.SelectedValue.ToString());

            availableStocksCombobox_2.ItemsSource =
                new StockService().GetStocksList(countryCombobox.SelectedValue.ToString());

            availableStocksCombobox_3.ItemsSource =
                new StockService().GetStocksList(countryCombobox.SelectedValue.ToString());

            availableStocksCombobox_4.ItemsSource =
                new StockService().GetStocksList(countryCombobox.SelectedValue.ToString());


        }

        private void NumberCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedValue = int.Parse(numberCombobox.SelectedItem.ToString());

            if (temp < selectedValue)
            {
                for (int i = 1; i <= selectedValue; i++)
                {
                    if (temp < selectedValue)
                    {
                        ((Storyboard)Resources["availableCombobox_" + i + "_storyboard"]).Begin();
                        ((Storyboard)Resources["availableCombobox_" + i + "_storyboard"]).AutoReverse = false;
                    }
                }
            }
            if (temp > selectedValue)
            {
                for (int j = 1; j <= temp; j++)
                {
                    ((Storyboard)Resources["availableCombobox_" + j + "_storyboard"]).AutoReverse = true;
                    ((Storyboard)Resources["availableCombobox_" + j + "_storyboard"]).Begin(this, true);
                    ((Storyboard)Resources["availableCombobox_" + j + "_storyboard"]).Seek(this, new TimeSpan(0, 0, 0), TimeSeekOrigin.Duration);
                    ((Storyboard)Resources["availableCombobox_" + j + "_storyboard"]).AutoReverse = false;
                }

                for (int i = 1; i <= selectedValue; i++)
                {
                    ((Storyboard)Resources["availableCombobox_" + i + "_storyboard"]).Begin();
                    ((Storyboard)Resources["availableCombobox_" + i + "_storyboard"]).AutoReverse = false;
                }
            }
            temp = selectedValue;
        }

        private void Commission()
        {

            int numberOfStocks;
            Int32.TryParse(numberOfStocksInTransaction.Text, out numberOfStocks);
            int selectedValue = int.Parse(numberCombobox.SelectedItem.ToString());

            if (selectedValue == 1)
            {
                decimal resultCommission1 = ((IStock)availableStocksCombobox_1.SelectedItem)
                    .Commission(numberOfStocks, typeOfTransactionCombobox.SelectedIndex);
                resultTextBlock_1.Text = resultCommission1.ToString();
                resultTextBlock_2.Text = "0";
                resultTextBlock_3.Text = "0";
                resultTextBlock_4.Text = "0";
            }
            else if (selectedValue == 2)
            {
                decimal resultCommission1 = ((IStock)availableStocksCombobox_1.SelectedItem)
                    .Commission(numberOfStocks, typeOfTransactionCombobox.SelectedIndex);
                resultTextBlock_1.Text = resultCommission1.ToString();
                decimal resultCommission2 = ((IStock)availableStocksCombobox_2.SelectedItem)
                    .Commission(numberOfStocks, typeOfTransactionCombobox.SelectedIndex);
                resultTextBlock_2.Text = resultCommission1.ToString();
                resultTextBlock_3.Text = "0";
                resultTextBlock_4.Text = "0";
            }
            else if(selectedValue==3)
            {
                decimal resultCommission1 = ((IStock)availableStocksCombobox_1.SelectedItem)
                    .Commission(numberOfStocks, typeOfTransactionCombobox.SelectedIndex);
                resultTextBlock_1.Text = resultCommission1.ToString();
                decimal resultCommission2 = ((IStock)availableStocksCombobox_2.SelectedItem)
                    .Commission(numberOfStocks, typeOfTransactionCombobox.SelectedIndex);
                resultTextBlock_2.Text = resultCommission2.ToString();
                decimal resultCommission3 = ((IStock)availableStocksCombobox_3.SelectedItem)
                    .Commission(numberOfStocks, typeOfTransactionCombobox.SelectedIndex);
                resultTextBlock_3.Text = resultCommission3.ToString();
                resultTextBlock_4.Text = "0";
            }
            else if (selectedValue==4)
            {
                decimal resultCommission1 = ((IStock)availableStocksCombobox_1.SelectedItem)
                    .Commission(numberOfStocks, typeOfTransactionCombobox.SelectedIndex);
                resultTextBlock_1.Text = resultCommission1.ToString();
                decimal resultCommission2 = ((IStock)availableStocksCombobox_2.SelectedItem)
                    .Commission(numberOfStocks, typeOfTransactionCombobox.SelectedIndex);
                resultTextBlock_2.Text = resultCommission2.ToString();
                decimal resultCommission3 = ((IStock)availableStocksCombobox_3.SelectedItem)
                    .Commission(numberOfStocks, typeOfTransactionCombobox.SelectedIndex);
                resultTextBlock_3.Text = resultCommission3.ToString();
                decimal resultCommission4 = ((IStock)availableStocksCombobox_4.SelectedItem)
                    .Commission(numberOfStocks, typeOfTransactionCombobox.SelectedIndex);
                resultTextBlock_4.Text = resultCommission3.ToString();
            }

            setCorrectDate();
            resultTextBlock_time.Text = datetimeValue.ToString();

            InsertDataToDatabase();            
        }

        private void InsertDataToDatabase()
        {
            string numberOfStocksToCompute = numberCombobox.SelectedItem.ToString();
            string amountOfStocksToExchange = numberOfStocksInTransaction.Text;
            int number, amount;
            Int32.TryParse(numberOfStocksToCompute, out number);
            Int32.TryParse(amountOfStocksToExchange, out amount);
            string stock_2 = availableStocksCombobox_2.SelectedItem == null ? "" : availableStocksCombobox_2.SelectedItem.ToString();
            string stock_3 = availableStocksCombobox_3.SelectedItem == null ? "" : availableStocksCombobox_3.SelectedItem.ToString();
            string stock_4 = availableStocksCombobox_4.SelectedItem == null ? "" : availableStocksCombobox_4.SelectedItem.ToString();

            using (StockExchangeDbContext context = new StockExchangeDbContext())
            {
                StockExchangeDataModel newRecord = new StockExchangeDataModel
                {
                    Country = countryCombobox.SelectedItem.ToString(),
                    NumberOfStocksToCompute = number,
                    TypeOfTransaction = typeOfTransactionCombobox.SelectedItem.ToString(),
                    AmountOfStocksToExchange = amount,
                    Stocks_1 = availableStocksCombobox_1.SelectedItem?.ToString(),
                    Stocks_2 = availableStocksCombobox_2.SelectedItem?.ToString(),
                    Stocks_3 = availableStocksCombobox_3.SelectedItem?.ToString(),
                    Stocks_4 = availableStocksCombobox_4.SelectedItem?.ToString(),
                    StockExchangeDate = datetimeValue
                };
                context.StockExchangeDataModels.Add(newRecord);
                context.SaveChanges();
            }
        }


        private void LoadDataFromDatabase()
        {
            using (StockExchangeDbContext context = new StockExchangeDbContext())
            {
                Task.Delay(5000).Wait();
                Dispatcher.Invoke(() =>
                {
                    dataFromDatabase.ItemsSource = context.StockExchangeDataModels.ToList();
                });
            }
        }

        CancellationTokenSource tokenSource;

        private void LoaderCancel()
        {
            tokenSource.Cancel();
        }

        private void DataFromDatabase_Loaded(object sender, RoutedEventArgs e)
        {
            using (StockExchangeDbContext context = new StockExchangeDbContext())
            {
                dataFromDatabase.ItemsSource = context.StockExchangeDataModels.ToList();
            }
        }

        private void Refresh()
        {
            tokenSource = new CancellationTokenSource();
            loaderPanel.Visibility = Visibility.Visible;

            Task t1 = new Task(() => LoadDataFromDatabase());
            t1.Start();

            Task t2 = new Task(() => Refresh1(tokenSource.Token), tokenSource.Token);
            t2.Start();

            Task t3 = new Task(() => Refresh2(tokenSource.Token), tokenSource.Token);
            t3.Start();

            Task.WhenAll(t1, t2, t3).ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    MessageBox.Show("Wystąpił błąd");
                }
                loaderPanel.Visibility = Visibility.Hidden;
            }, TaskScheduler.FromCurrentSynchronizationContext()
            );
        }

        private void Refresh1(CancellationToken cancellationToken)
        {
            for (int i = 0; i < 20; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }
                Task.Delay(1000).Wait();
            }
        }

        private void Refresh2(CancellationToken cancellationToken)
        {
            for (int i = 0; i < 20; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }
                Task.Delay(1000).Wait();
            }
        }

        private void PaginationButtonPrev()
        {
            using (StockExchangeDbContext context = new StockExchangeDbContext())
            {
                dataFromDatabase.ItemsSource = context.StockExchangeDataModels
                    .ToList()
                    .Skip(paginationVariable)
                    .Take(10)
                    .ToList();
                paginationVariable -= 10;
            }
        }

        private void PaginationButtonNext()
        {
            using (StockExchangeDbContext context = new StockExchangeDbContext())
            {
                dataFromDatabase.ItemsSource = context.StockExchangeDataModels
                    .ToList()
                    .Skip(paginationVariable)
                    .Take(10)
                    .ToList();
                paginationVariable += 10;
            }
        }

        private void IndiceControlButtons_Loaded(object sender, RoutedEventArgs e)
        {
            using (StockExchangeDbContext context = new StockExchangeDbContext())
            {
                int? lastRateFromDatabase = context.MajorMarketIndiceDataModels
                    .OrderByDescending(r => r.Id).FirstOrDefault()?.MajorIndice;

                if (lastRateFromDatabase != null)
                    indiceControlButtons.IndiceValue = lastRateFromDatabase ?? default(int);

            }
        }

        private void IndiceControlButtons_IndiceValueChanged(object sender, Common.Controls.IndiceEventArgs e)
        {
            using (StockExchangeDbContext context = new StockExchangeDbContext())
            {
                MajorMarketIndiceDataModel newRecord = new MajorMarketIndiceDataModel
                {
                    MajorIndice = e.value,
                    IndiceDate = DateTime.Now
                };
                context.MajorMarketIndiceDataModels.Add(newRecord);
                context.SaveChanges();
            }
        }
    }
}