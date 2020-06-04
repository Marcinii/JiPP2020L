using BankApplication.GUI.AppUserControl.AccountTransactionItemControl;
using BankApplication.Library.AccountUtil;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BankApplication.GUI.Util
{
    /// <summary>
    /// Klasa zawierająca metody służące do wykonywania operacji na oknie głównym aplikacji
    /// </summary>
    /// <see cref="MainWindow"/>
    public class MainWindowUtils
    {
        private MainWindow mainWindow;

        public MainWindowUtils(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }



        /// <summary>
        /// Metoda aktualizuje dane dotyczące wybranego konta bankowego użytkownika
        /// </summary>
        public void setAccountDetails()
        {
            mainWindow.firstLastNameLabel.Content = mainWindow.loginService.currentUser.firstName + " " + mainWindow.loginService.currentUser.lastName;
            mainWindow.emailAddressLabel.Content = mainWindow.loginService.currentUser.emailAddress;
            mainWindow.accountNameLabel.Content = mainWindow.accountService.currentAccount.name;
            mainWindow.salaryLabel.Content = mainWindow.accountService.currentAccount.salary + "zł";
            mainWindow.accountNumberLabel.Content = AccountNumberUtils.toFormattedAccountNumber(mainWindow.accountService.currentAccount.accountNumber);
        }



        /// <summary>
        /// Metoda, która ma za zadanie wyświetlić listę dokonanych transakcji.
        /// Jeżeli na danym koncie bankowym nie zostały dokonane żadne transakcje - wówczas 
        /// wyświetla napis informujący o braku wykonanych transakcji
        /// </summary>
        public void manageTransacions()
        {
            mainWindow.transactionListDockPanel.Children.Clear();
            if (mainWindow.accountService.currentAccount.transactions.Count == 0)
            {
                mainWindow.transactionListDockPanel.Children.Add(new Label()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#cccccc"),
                    FontSize = 24,
                    Content = "Brak dotychczasowych transakcji"
                });
            }
            else
            {
                this.displayListOfTransactions();
            }
        }



        /// <summary>
        /// Metoda wyświetla listę wszystkich transakcji.
        /// </summary>
        public void displayListOfTransactions()
        {
            mainWindow.accountService.currentAccount.transactions.ForEach(transaction =>
            {
                AccountTransactionItem item = new AccountTransactionItem()
                {
                    name = transaction.name,
                    price = transaction.ammount,
                    transactionType = transaction.accountTransactionType,
                    createdAt = transaction.createdAt,
                    accountNumber = transaction.destinationAccount.accountNumber,
                    VerticalAlignment = VerticalAlignment.Top
                };
                DockPanel.SetDock(item, Dock.Top);
                mainWindow.transactionListDockPanel.Children.Add(item);
            });
        }
    }
}
