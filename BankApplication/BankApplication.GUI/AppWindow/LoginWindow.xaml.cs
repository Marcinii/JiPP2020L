using BankApplication.GUI.Util;
using BankApplication.Library.LoginUtil;
using BankApplication.Library.UserUtil;
using System.Threading.Tasks;
using System.Windows;
using UnitConverter.Application.Command;

namespace BankApplication.GUI.AppWindow
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginService loginService;

        public LoginWindow()
        {
            this.loginService = ((App)Application.Current).loginService;
            InitializeComponent();

            this.loginButton.Command = new ButtonCommand(
                x => login(),
                x => !this.loginTextBox.isEmpty() && !this.passwordTextBox.isEmpty()
            );
        }



        /// <summary>
        /// Metoda, która jest wywoływana w momecie kliknięcia przycisku <see cref="loginButton"/>.
        /// Metoda ta ma za zadanie zalogowanie użytkownika i otworzenie główngo okna aplikacji.
        /// </summary>
        private void login()
        {
            this.loadingSpinner.Visibility = Visibility.Visible;
            this.loginService.username = this.loginTextBox.value;
            this.loginService.password = this.passwordTextBox.value;

            Task d = new Task(() =>
            {
                try
                {
                    this.loginService.login();
                    Dispatcher.Invoke(() =>
                    {
                        CreateBankAccountUtils.checkUserAccounts(this.loginService.currentUser);
                        this.Close();
                    });
                }
                catch(UserNotFoundException ex)
                {
                    Dispatcher.Invoke(() =>
                    {
                        this.loadingSpinner.Visibility = Visibility.Collapsed;
                        this.loginTextBox.clear();
                        this.passwordTextBox.clear();

                        MessageBox.Show(
                            this,
                            ex.Message,
                            "JakiśBankXD",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                        );

                        this.loginTextBox.focus();
                    });
                }
            });

            d.Start();
        }



        /// <summary>
        /// Metoda otwierająca okno do rejestracji użytkownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerLabel_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }



        /// <summary>
        /// Metoda nasłuchująca zdarzenia wciskania klawiszy.
        /// Metoda ta ma za zadanie zalogować użytkownika pod warunkiem, że wciśnięty został klawisz ENTER.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && !this.loginTextBox.isEmpty() && !this.passwordTextBox.isEmpty())
                this.login();
        }
    }
}
