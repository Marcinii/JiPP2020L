using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApplication.Library.AccountUtil
{
    /// <summary>
    /// Klasa reprezentujaca model rekordu tabeli przechowującej rodzaje wykonywanych transakcji
    /// </summary>
    /// <param name="id">Identyfikator rodzaju transakcji</param>
    /// <param name="name">Nazwa rodzaju transakcji</param>
    /// <param name="transactions">Lista wykonanych transakcji</param>
    /// <see cref="AccountTransaction"/>
    [Table("account_transaction_type")]
    public class AccountTransactionType
    {
        public int id { get; set; }
        public string name { get; set; }

        public virtual List<AccountTransaction> transactions { get; set; }

        public AccountTransactionType() {}
    }
}
