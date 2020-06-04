using BankApplication.GUI.AppWindow;
using BankApplication.Library.UserUtil;
using System.Windows;

namespace BankApplication.GUI.Util
{
    /// <summary>
    /// Metoda zawierająca zestaw metod służących do wykonywania operacji podczas torzenia konta bankowego
    /// </summary>
    public class CreateBankAccountUtils
    {
        /// <summary>
        /// Metoda sprawdza, czy użytkownik, który zalogował się już posiada konto bankowe.
        /// Jeżeli posiada, wówczas otwiera się główne okno.
        /// W przeciwnym przypadku otwiera się okno, w którym należy utworzyć konto
        /// </summary>
        /// <param name="user">Zalogowany użytkowik</param>
        /// <see cref="User"/>
        public static void checkUserAccounts(User user)
        {
            if (user.accounts.Count > 0)
            {
                new MainWindow().Show();
            }
            else
            {
                MessageBoxResult res = MessageBox.Show(
                    "Wymagane jest co najmniej jedno konto bankowe, by móc korzystać z aplikacji. Czy chcesz je teraz utworzyć",
                    "JakiśBankXD",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Information
                );

                if (res == MessageBoxResult.Yes)
                    new CreateBankAccountWindow().Show();
            }
        }
    }
}
