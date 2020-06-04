using BankApplication.Library.Context;
using BankApplication.Library.UserUtil;
using System;
using System.Threading;

namespace BankApplication.Library.RegisterUtil
{
    /// <summary>
    /// Klasa odpowiedzialna za rejestrację nowuch użytkowników
    /// </summary>
    public class RegisterService
    {
        private CustomDatabaseContext customDatabaseContext;
        private User providedUser;

        public RegisterService(CustomDatabaseContext customDatabaseContext)
        {
            this.customDatabaseContext = customDatabaseContext;
        }



        /// <summary>
        /// Metoda, służąca do przekazania danych użytkownika do rejestracji w serwisie
        /// </summary>
        /// <param name="user">Użytkownik do zarejestrowania</param>
        public void applyUser(User user) => this.providedUser = user;



        /// <summary>
        /// Metoda służąca o rejestracji nowego użytkownika
        /// </summary>
        public void register()
        {
            Random random = new Random();
            Thread.Sleep(random.Next(1000, 2000));
            this.customDatabaseContext.users.Add(this.providedUser);
            this.customDatabaseContext.SaveChanges();
        }
    }
}
