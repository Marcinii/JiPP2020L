using BankApplication.Library.LoginUtil;
using System.Windows;
using UnitConverter.Application.Command;

namespace BankApplication.GUI.AppWindow
{
    /// <summary>
    /// Interaction logic for PasswordPromptWindow.xaml
    /// </summary>
    /// <param name="approved">
    ///     Pole przechowujące informacje o tym, czy haso które zostało wprowadzone jest prawidowe.
    /// </param>
    public partial class PasswordPromptWindow : Window
    {
        private LoginService loginService;

        public bool approved { get; private set; } = false;

        public PasswordPromptWindow()
        {
            this.loginService = ((App)Application.Current).loginService;

            InitializeComponent();

            this.applyButton.Command = new ButtonCommand(
                x => apply(), 
                x => !this.passwordFormInput.isEmpty()
            );
        }



        /// <summary>
        /// Metoda wywołuje się w momencie wciśnięcia na przycisk <see cref="applyButton"/>.
        /// Po wpisaniu hasła metoda ta potwierdza wykonanie danej czynności, które wymaga autoryzacji.
        /// </summary>
        public void apply()
        {
            this.approved = this.loginService.currentUser.password == this.passwordFormInput.value;

            if (!this.approved)
            {
                MessageBox.Show(
                    this,
                    "Podane hasło jest nieprawidłowe",
                    "JakiśBankXD",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );

                this.passwordFormInput.clear();
            }
            else this.Close();
        }
    }
}
