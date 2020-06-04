using BankApplication.Library.Context;
using BankApplication.Library.UserUtil;
using System;
using System.Linq;
using System.Threading;

namespace BankApplication.Library.LoginUtil
{
    /// <summary>
    /// Klasa jest odpowiedzialna za logowanie użytkownika do serwisu
    /// </summary>
    /// <param name="username">Nazwa użytkownika</param>
    /// <param name="password">Hasło</param>
    /// <param name="currentUser">Aktualnie zalogowany użytkownik</param>
    public class LoginService
    {
        private CustomDatabaseContext customDatabaseContext;

        public string username { private get; set; }
        public string password { private get; set; }

        public User currentUser { get; set; }

        public LoginService(CustomDatabaseContext customDatabaseContext)
        {
            this.customDatabaseContext = customDatabaseContext;
        }



        /// <summary>
        /// Metoda ma za zadanie zalogować użytkownika.
        /// Jeżeli użytkownik nie istnieje - zostanie wyrzucony wyjątek <see cref="UserNotFoundException"/>
        /// </summary>
        public void login()
        {
            this.currentUser = this.customDatabaseContext.users
                   .FirstOrDefault(x => x.username == username && x.password == password);

            Thread.Sleep(new Random().Next(500, 1000));

            if (this.currentUser == null)
                throw new UserNotFoundException("Nieprawidłowa nazwa użytkownika lub hasło");
        }



        /// <summary>
        /// Metoda ta wyloogowuje użytkownika z serwisu
        /// </summary>
        public void logout() => this.currentUser = null;
    }
}
