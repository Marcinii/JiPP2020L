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
using System.Threading;
using Project1;

namespace Account.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AccountCombobox.ItemsSource = new List<IAccount>()
            {
                new SavingsAccount(),
                new VirtualAccount()
            };

        }

        private void AccountCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (BankEntities context = new BankEntities())
            {
                List<History> records = context.History.ToList();
                HistoryGrid.ItemsSource = records;
            }
            Thread thread = new Thread(() => welcome());
            thread.Start();
        }

        private void DepoButton_Click(object sender, RoutedEventArgs e)
        {


            string depoTextValue = DepoTextBox.Text;
            decimal depoValue = decimal.Parse(depoTextValue);
            decimal result = ((IAccount)AccountCombobox.SelectedItem).Deposit(depoValue);
            
            BalanceD.Text = result.ToString();
            Info.Text = "Wpłacono: " + depoValue + " PLN";
            DepoTextBox.Text = "0";
            using (BankEntities context = new BankEntities())
            {

                History newRecord = new History()
                {
                    Kwota = depoValue,
                    Operacja = "Wpłata",
                    Data = DateTime.Now
                };

                context.History.Add(newRecord);
                context.SaveChanges();
            }

        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            string withdrawTextValue = DepoTextBox.Text;
            decimal withdrawValue = decimal.Parse(withdrawTextValue);
            decimal result = ((IAccount)AccountCombobox.SelectedItem).Withdraw(withdrawValue);

            BalanceD.Text = result.ToString();
            Info.Text = "Wypłacono: " + withdrawValue + " PLN";
            DepoTextBox.Text = "0";
            using (BankEntities context = new BankEntities())
            {

                History newRecord = new History()
                {
                    Kwota = withdrawValue,
                    Operacja = "Wypłata",
                    Data = DateTime.Now
                };

                context.History.Add(newRecord);
                context.SaveChanges();

            }
        }

        private void welcome()
        {
            Thread.Sleep(7000);
            Dispatcher.Invoke(()=> welcomeTextblock.Visibility = Visibility.Visible) ;

        }

    }
}
