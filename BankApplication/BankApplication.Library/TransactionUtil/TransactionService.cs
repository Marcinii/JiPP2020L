using BankApplication.Library.AccountUtil;
using BankApplication.Library.Context;
using System;
using System.Threading;

namespace BankApplication.Library.TransactionUtil
{
    /// <summary>
    /// Klasa odpowiedzialna za wykonywanie traksakcji
    /// </summary>
    /// <param name="destinationAccountNumber">Docelowy numer konta bankowego</param>
    /// <param name="salary">Kwota transakcji</param>
    /// <param name="name">Nazwa transakcji</param>
    /// <param name="onCreate">Zdarzenie, ktore będzie się wywoływało w momencie utworzenia nowej transakcji</param>
    /// <see cref="TransactionEventHandler"/>
    public class TransactionService
    {
        private CustomDatabaseContext customDatabaseContext;
        private AccountService accountService;
        private Account destinationAccount;

        public string destinationAccountNumber { get; set; }
        public decimal salary { get; set; }
        public string name { get; set; }

        public event TransactionEventHandler onCreate;

        public TransactionService(AccountService accountService, CustomDatabaseContext customDatabaseContext)
        {
            this.accountService = accountService;
            this.customDatabaseContext = customDatabaseContext;
        }



        /// <summary>
        /// Metoda tworzy i zapisuje nową transakcję dobazy danych.
        /// </summary>
        public void createTransaction()
        {
            Random random = new Random();

            this.destinationAccount = this.accountService.findAccountByNumber(this.destinationAccountNumber);

            this.customDatabaseContext.transactions.Add(new AccountTransaction()
            {
                srcAccount = this.accountService.currentAccount,
                name = this.name,
                ammount = this.salary,
                transactionType = 2,
                createdAt = DateTime.Now,
                destinationAccount = this.destinationAccount
            });

            this.accountService.currentAccount.salary -= this.salary;

            Thread.Sleep(random.Next(250, 500));

            this.customDatabaseContext.transactions.Add(new AccountTransaction()
            {
                srcAccount = destinationAccount,
                name = this.name,
                ammount = this.salary,
                transactionType = 1,
                createdAt = DateTime.Now,
                destinationAccount = this.accountService.currentAccount
            });

            destinationAccount.salary += this.salary;

            Thread.Sleep(random.Next(250, 500));
            this.customDatabaseContext.SaveChanges();
        }



        /// <summary>
        /// Metoda służy do wywołania zdarzenia utworzenia nowej transakcji
        /// </summary>
        public void invokeCreate() => this.onCreate?.Invoke(new AccountTransaction()
        {
            srcAccount = this.accountService.currentAccount,
            name = this.name,
            ammount = this.salary,
            accountTransactionType = new AccountTransactionType() { id = 2, name = "Przelew wychodzący" },
            createdAt = DateTime.Now,
            destinationAccount = this.destinationAccount
        });
    }
}
