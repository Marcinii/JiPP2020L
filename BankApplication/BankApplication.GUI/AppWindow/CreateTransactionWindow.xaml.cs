using BankApplication.Library.AccountUtil;
using BankApplication.Library.TransactionUtil;
using BankApplication.Library.UserUtil;
using BankApplication.Library.ValidatorUtil;
using System;
using System.Threading;
using System.Windows;
using UnitConverter.Application.Command;

namespace BankApplication.GUI.AppWindow
{
    /// <summary>
    /// Interaction logic for CreateTransactionWindow.xaml
    /// </summary>
    public partial class CreateTransactionWindow : Window
    {
        private AccountService accountService;
        private UserService userService;
        private TransactionService transactionService;

        public CreateTransactionWindow()
        {
            this.accountService = ((App)Application.Current).accountService;
            this.userService = ((App)Application.Current).userService;
            this.transactionService = ((App)Application.Current).transactionService;

            InitializeComponent();
            this.transactionNameFormInput.value = "Przelew wychodzący dn. " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.Owner = Application.Current.MainWindow;

            this.createTransactionButton.Command = new ButtonCommand(
                x => createTransaction(),
                x => !this.transactionNameFormInput.isEmpty() &&
                     !this.destinationAccountNumberFormInput.isEmpty() && this.destinationAccountNumberFormInput.valid &&
                     !this.salaryFormInput.isEmpty() && this.salaryFormInput.valid
            );
        }



        /// <summary>
        /// Metoda, która wywołuje się w momencie klikniecia na przycisk <see cref="createTransactionButton"/>.
        /// Metoda ta wykonuje nowy przelew na docelowe konto bankowe.
        /// </summary>
        private void createTransaction()
        {
            this.transactionService.destinationAccountNumber = this.destinationAccountNumberFormInput.value;
            this.transactionService.salary = decimal.Parse(this.salaryFormInput.value);
            this.transactionService.name = this.transactionNameFormInput.value;

            MessageBoxResult res = MessageBox.Show(
                this,
                "Czy na pewno chcesz dokonać przelewu?",
                "JakiśBankXD",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if(res == MessageBoxResult.Yes)
            {
                PasswordPromptWindow passwordPromptWindow = new PasswordPromptWindow();
                passwordPromptWindow.ShowDialog();

                if(passwordPromptWindow.approved)
                {
                    this.loadingSpinner.Visibility = Visibility.Visible;
                    new Thread(() =>
                    {
                        this.transactionService.createTransaction();

                        Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show(
                                this,
                                "Przelew został dokonany pomyslnie",
                                "JakiśBankXD",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information
                            );

                            this.transactionService.invokeCreate();
                            this.Close();
                        });
                    }).Start();
                }
            }
        }



        /// <summary>
        /// Metoda, która wywołuje się w momencie zmiany wartości pola <see cref="destinationAccountNumberFormInput"/>.
        /// Metoda ta sprawdza, czy podany docelowy nummer konta bankowego jest prawidłową wartością, a także czy podany numer konta
        /// bankowego istnieje w bazie danych (w razie wprowadzonego błędnego numeru konta - transakcja nie będzie wykonana).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void destinationAccountNumberFormInput_onChange(object sender, AppUserControl.FormInputControl.FormInputEventArgs args)
        {
            if (!new AccountNumberValidator().validate(AccountNumberUtils.removeSpaces(this.destinationAccountNumberFormInput.value)))
            {
                this.destinationAccountNumberFormInput.errorMessage = "Number konta bankowego musi się składać z 26 cyfr";
                this.destinationAccountNumberFormInput.setToInvalid();
            }
            else if (userService.findByAccountNumber(AccountNumberUtils.removeSpaces(this.destinationAccountNumberFormInput.value)) == null)
            {
                this.destinationAccountNumberFormInput.errorMessage = "Podany numer konta bankowego nie istnieje";
                this.destinationAccountNumberFormInput.setToInvalid();
            }
            else this.destinationAccountNumberFormInput.setToValid();
        }



        /// <summary>
        /// Metoda, która wywołuje się podczas dokonywania zmian wartości pola <see cref="salaryFormInput"/>.
        /// Metoda ta sprawdza, czy podana wartość kwoty do przelania jest dodatnia, oraz czy kwota, którą chce przelać
        /// jest mniejsza od kwoty, jaką dysponuje użytkownik na danym koncie bankowym
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void salaryFormInput_onChange(object sender, AppUserControl.FormInputControl.FormInputEventArgs args)
        {
            if(this.salaryFormInput.isEmpty() || !this.salaryFormInput.valid)
            {
                this.salaryFormInput.setToInvalid();
            }
            else if (decimal.Parse(this.salaryFormInput.value) <= 0)
            {
                this.salaryFormInput.errorMessage = "Kwota nie może być mniejsza bądź równa 0. Musisz wprowadzić wartość dodatnią";
                this.salaryFormInput.setToInvalid();
            }
            else if (this.accountService.currentAccount.salary < decimal.Parse(this.salaryFormInput.value))
            {
                this.salaryFormInput.errorMessage = "Nie masz wystarczających środków na wykonanie przelewu. Dostępna wartość: " + this.accountService.currentAccount.salary;
                this.salaryFormInput.setToInvalid();
            }
            else this.salaryFormInput.setToValid();
        }
    }
}
