using BankApplication.Library.AccountUtil.Event;
using BankApplication.Library.Context;
using BankApplication.Library.LoginUtil;
using System.Linq;

namespace BankApplication.Library.AccountUtil
{
    /// <summary>
    /// Klasa odpowiedzialna za wykonywanie podstawowych operacji na kontach bankowych.
    /// </summary>
    /// <param name="onChange">Zdarzenie, które wywoła się w momencie, gdy dojdzie do zmiany danych konta bankowego</param>
    /// <param name="onCreate">Zdarzenie, które wywoła sie w momencie utworzenia nowego konta bankowego</param>
    /// <param name="currentAccount">Aktualnie wybrane konto bankowego</param>
    public class AccountService
    {
        private CustomDatabaseContext customDatabaseContext;
        private LoginService loginService;

        public event AccountEventHandler onChange;
        public event AccountEventHandler onCreate;
        public Account currentAccount { get; private set; }


        public AccountService(CustomDatabaseContext customDatabaseContext, LoginService loginService)
        {
            this.customDatabaseContext = customDatabaseContext;
            this.loginService = loginService;
        }



        /// <summary>
        /// Metoda tworzy nowe konto bankowe i zapisuje je do bazy danych
        /// </summary>
        /// <param name="name">Nazwa konta bankowego</param>
        public void createAccount(string name)
        {
            Account account = new Account()
            {
                name = name,
                user = loginService.currentUser,
                accountNumber = AccountUtils.generateAccountNumber()
            };

            while(this.loginService.currentUser.accounts.Where(x => x.accountNumber == account.accountNumber).Count() > 0)
            {
                account.accountNumber = AccountUtils.generateAccountNumber();
            }

            this.customDatabaseContext.users.Where(x => x.id == this.loginService.currentUser.id).First()
                .accounts.Add(account);

            this.customDatabaseContext.SaveChanges();
            this.onCreate?.Invoke(account);
        }



        /// <summary>
        /// Metoda sprawdza, czy wprowadzona nazwa konta bankowego już istnieje u użytkownika
        /// </summary>
        /// <param name="name">Nazwa konta bankowego</param>
        /// <returns>Zwraca true, jeżeli istnieje. W przeciwnym przypadku - false</returns>
        public bool accountExists(string name)
        {
            return this.loginService.currentUser.accounts.Where(x => x.user.id == loginService.currentUser.id && x.name == name).Count() > 0;
        }



        /// <summary>
        /// Metoda ma za zadanie zmienić aktualnie wybrane konto bankowe.
        /// </summary>
        /// <param name="index">Indeks konta bankowego</param>
        public void selectAccount(int index)
        {
            this.currentAccount = this.loginService.currentUser.accounts[index];
            this.onChange?.Invoke(this.currentAccount);
        }



        /// <summary>
        /// Metoda wyszukująca konto bankowego według jego numeru
        /// </summary>
        /// <param name="accountNumber">Numer konta bankowego</param>
        /// <returns>Zwraca konto bankowe, jeżeli zostanie znalezione. W przeciwnym przypadku zwróci null.</returns>
        /// <see cref="Account"/>
        public Account findAccountByNumber(string accountNumber)
        {
            return this.customDatabaseContext.accounts.FirstOrDefault(x => x.accountNumber == accountNumber);
        }
    }
}
