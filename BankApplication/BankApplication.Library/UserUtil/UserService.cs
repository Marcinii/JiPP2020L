using BankApplication.Library.Context;
using System.Linq;

namespace BankApplication.Library.UserUtil
{
    /// <summary>
    /// Klasa jest odpowiedzialna za wykonywanie podstawowych operacji na użytkownikach
    /// </summary>
    public class UserService
    {
        private CustomDatabaseContext customDatabaseContext;


        public UserService(CustomDatabaseContext customDatabaseContext)
        {
            this.customDatabaseContext = customDatabaseContext;
        }



        /// <summary>
        /// Metoda wyszukuje użytkownika według jego nazwy
        /// </summary>
        /// <param name="username">Nazwa użytkownika</param>
        /// <returns>
        ///     Zwraca obiekt przechowujący informacje o użytkowniku pod warunkiem istnienia danego użytkownika.
        ///     W przeciwnym przypadku zwraca null
        /// </returns>
        public User findByUsername(string username) => 
            this.customDatabaseContext.users.FirstOrDefault(x => x.username == username);



        /// <summary>
        /// Metoda wyszukuje użytkownika według numeru konta bankowego
        /// </summary>
        /// <param name="accountNumber">Numer konta bankowego</param>
        /// <returns>
        ///     Zwraca obiekt przechowujący informacje o użytkowniku pod warunkiem istnienia danego użytkownika.
        ///     W przeciwnym przypadku zwraca null
        /// </returns>
        public User findByAccountNumber(string accountNumber)
        {
            return this.customDatabaseContext.users.FirstOrDefault(x => x.accounts.Select(y => y.accountNumber).Contains(accountNumber));
        }
    }
}
