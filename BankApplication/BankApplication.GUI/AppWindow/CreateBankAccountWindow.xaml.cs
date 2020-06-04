using BankApplication.Library.AccountUtil;
using BankApplication.Library.LoginUtil;
using System.Threading;
using System.Windows;
using UnitConverter.Application.Command;

namespace BankApplication.GUI.AppWindow
{
    /// <summary>
    /// Interaction logic for CreateBankAccountWindow.xaml
    /// </summary>
    public partial class CreateBankAccountWindow : Window
    {
        private AccountService accountService;
        private LoginService loginService;

        public CreateBankAccountWindow()
        {
            this.accountService = ((App)Application.Current).accountService;
            this.loginService = ((App)Application.Current).loginService;

            InitializeComponent();

            this.applyButton.Command = new ButtonCommand(
                x => createAccount(),
                x => !this.accountNameFormInput.isEmpty() && this.accountNameFormInput.valid
            );
        }



        /// <summary>
        /// Metoda, która wywołuje się w momencie kliknięcia na przycisk <see cref="applyButton"/>.
        /// Metoda ta ma za zadanie utworzyć nowe konto bankowe dla danego użytkownika
        /// </summary>
        private void createAccount() => new Thread(() => Dispatcher.Invoke(() =>
        {
            this.accountService.createAccount(this.accountNameFormInput.value);

            MessageBox.Show(
                this,
                "Konto zostało utworzone pomyślnie",
                "JakiśBankXD",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );

            if(this.loginService.currentUser.accounts.Count == 1)
                new MainWindow().Show();
            
            this.Close();
        })).Start();



        /// <summary>
        /// Metoda wywołuje się w trakcie dokonywania zmiany wartości pola, przechowującego nazwę konta bankowego.
        /// Metoda ta sprawdza, czy wprowadzona nazwa już istnieje dla danego użytkownika.
        /// Jeżeli posiada, wówczas wyświetla stoosowny komunikat pod polem tekstowym.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void accountName_onChange(object sender, AppUserControl.FormInputControl.FormInputEventArgs args)
        {
            if (this.accountService.accountExists(args.value))
            {
                this.accountNameFormInput.errorMessage = "Już posiadasz konto o takiej nazwie";
                this.accountNameFormInput.setToInvalid();
            }
            else
                this.accountNameFormInput.setToValid();
        }
    }
}
