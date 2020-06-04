using BankApplication.GUI.AppWindow;
using BankApplication.GUI.Util;
using BankApplication.Library.AccountUtil;
using BankApplication.Library.LoginUtil;
using BankApplication.Library.TransactionUtil;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UnitConverter.Application.Command;

namespace BankApplication.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowUtils mainWindowUtils;

        public LoginService loginService { get; private set; }
        public AccountService accountService { get; private set; }
        public TransactionService transactionService { get; private set; }

        public MainWindow()
        {
            this.mainWindowUtils = new MainWindowUtils(this);
            this.loginService = ((App)Application.Current).loginService;
            this.accountService = ((App)Application.Current).accountService;
            this.transactionService = ((App)Application.Current).transactionService;

            this.accountService.onChange += AccountService_onChange;
            this.transactionService.onCreate += TransactionService_onCreate;

            InitializeComponent();

            this.accountService.selectAccount(0);

            this.mainWindowUtils.manageTransacions();

            this.createTrasactionButton.Command = new ButtonCommand(
                x => new CreateTransactionWindow().ShowDialog()
            );

            this.copyAccountNumberButton.Command = new ButtonCommand(
                x => Clipboard.SetText(this.accountNumberLabel.Content.ToString()),
                x => this.accountNumberLabel.Content.ToString().Trim() != ""
            );
        }



        /// <summary>
        /// Metoda wywołuje się w momencie dokonania przelewu bankowego.
        /// Po dokonaniu przelewu aktualizowana jest lista wszystkich transakcji oraz zmieniane jest aktualne saldo konta.
        /// </summary>
        /// <param name="transaction"></param>
        private void TransactionService_onCreate(AccountTransaction transaction)
        {
            if(this.transactionListDockPanel.Children.OfType<Label>().FirstOrDefault() != null)
            {
                this.transactionListDockPanel.Children.RemoveAt(0);
            }

            this.mainWindowUtils.displayListOfTransactions();

            this.salaryLabel.Content = this.accountService.currentAccount.salary;
        }



        /// <summary>
        /// Metoda, która wykonuje się po zmianie konta bankowego.
        /// Metoda aktualizuje wartości kontrolek, które odpowiedzialne były za wyświetlenie podstawowych informacji o aktualnym
        /// koncie bankowym.
        /// </summary>
        /// <param name="account"></param>
        private void AccountService_onChange(Account account)
        {
            this.mainWindowUtils.setAccountDetails();
            this.mainWindowUtils.manageTransacions();
        }



        /// <summary>
        /// Metoda wywołująca się w momencie kliknięcia na element menu <see cref="logoutMenuItem"/>.
        /// Metoda wylogowuje użytkownika z serwisu i wyswietla ekran logowania.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logoutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show(
                this,
                "Czy na pewno chcesz się wylogować?",
                "JakiśBankXD",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if(res == MessageBoxResult.Yes)
            {
                this.loginService.logout();
                new LoginWindow().Show();
                this.Close();
            }
        }



        /// <summary>
        /// Metoda ma za zadanie wyświetlić nowe okno, prezentujące listę kont bankowych.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <see cref="AccountListWindow"/>
        private void displayAccountListMenuItem_Click(object sender, RoutedEventArgs e) => new AccountListWindow().ShowDialog();
    }
}
