using BankApplication.GUI.AppUserControl.FormInputControl;
using BankApplication.GUI.Util;
using BankApplication.Library.LoginUtil;
using BankApplication.Library.RegisterUtil;
using BankApplication.Library.UserUtil;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using UnitConverter.Application.Command;

namespace BankApplication.GUI.AppWindow
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private bool usernameExists;

        private UserService userService;
        private LoginService loginService;
        private RegisterService registerService;



        public RegisterWindow()
        {
            this.usernameExists = false;
            InitializeComponent();

            this.userService = ((App)Application.Current).userService;
            this.loginService = ((App)Application.Current).loginService;
            this.registerService = ((App)Application.Current).registerService;

            this.registerButton.Command = new ButtonCommand(
                x => register(),
                x => !this.loginTextBox.isEmpty() && !usernameExists &&
                     !this.passwordTextBox.isEmpty() && this.passwordTextBox.value.Length >= 5 &&
                     !this.firstNameTextBox.isEmpty() &&
                     !this.lastNameTextBox.isEmpty() &&
                     !this.emailAddressTextBox.isEmpty() &&
                     !this.birthDateDatePicker.isEmpty() &&
                     DateTime.Parse(this.birthDateDatePicker.value).AddYears(18) <= DateTime.Now
            );
        }



        /// <summary>
        /// Metoda, która wywołuje się w momencie kliknięcia na przycisk <see cref="registerButton"/>.
        /// Metoda ma za zadanie utworzyć nowego użytkownika. Wyświetla również powiadomienie informujące o tym,
        /// aby użytkownik utworzył na starcie pierwsze konto bankowe.
        /// Jeżeli tego nie zrobi, aplikacja się zamyka i podczas logowania dane powiadomienie znowu się pojawia.
        /// </summary>
        private void register()
        {
            this.loadingSpinner.Visibility = Visibility.Visible;
            this.registerService.applyUser(new User()
            {
                username = loginTextBox.value,
                password = passwordTextBox.value,
                firstName = firstNameTextBox.value,
                lastName = lastNameTextBox.value,
                emailAddress = emailAddressTextBox.value,
                birthDate = DateTime.Parse(birthDateDatePicker.value)
            });

            new Thread(() =>
            {
                this.registerService.register();

                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        this,
                        "Użytkownik został zarejestrowany pomyślnie",
                        "JakiśBankXD",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );

                    this.loginService.username = this.loginTextBox.value;
                    this.loginService.password = this.passwordTextBox.value;
                });

                this.loginService.login();

                Dispatcher.Invoke(() =>
                {
                    this.Hide();
                    CreateBankAccountUtils.checkUserAccounts(this.loginService.currentUser);
                    this.Close();
                });
            }).Start();
        }



        /// <summary>
        /// Metoda ta ma za zadanie powrócić na stronę logowania.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginLabel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }



        /// <summary>
        /// Metoda wywołuje się podczas zmiany wartości pola <see cref="loginTextBox"/>.
        /// Metoda sprawdza poprawność wprowadzonej nazwy użytkownika.
        /// Sprawdza, czy użytkownik już istnieje w bazie danych.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginTextBox_TextChanged(object sender, FormInputEventArgs e)
        {
            new Thread(() => Dispatcher.Invoke(() =>
            {
                this.usernameExists = this.userService.findByUsername(e.value) != null;
                if (this.usernameExists)
                {
                    this.loginTextBox.errorMessage = "Podana nazwa użytkownika już istnieje";
                    this.loginTextBox.setToInvalid();
                }
                else
                    this.loginTextBox.setToValid();
            })).Start();
        }



        /// <summary>
        /// Metoda sprawdza, czy wprowadzone hasło posiada wymaganą ilość znaków.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordTextBox_PasswordChanged(object sender, FormInputEventArgs e)
        {
            if (e.value.Length < 5)
            {
                this.passwordTextBox.errorMessage = "Hasło musi zawierać conajmniej 5 znaków";
                this.passwordTextBox.setToInvalid();
            }
            else
                this.passwordTextBox.setToValid();
        }



        /// <summary>
        /// Metoda sprawdza, czy data, która została wprowadzona do pola <see cref="birthDateDatePicker"/>
        /// jest większa niż 18 lat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void birthDateDatePicker_SelectedDateChanged(object sender, FormInputEventArgs e)
        {
            if (!this.birthDateDatePicker.isEmpty() && DateTime.Parse(this.birthDateDatePicker.value).AddYears(18) > DateTime.Now)
            {
                this.birthDateDatePicker.errorMessage = "Musisz mieć ukończone 18 lat by założyć konto";
                this.birthDateDatePicker.setToInvalid();
            }
            else
                this.birthDateDatePicker.setToValid();
        }
    }
}
