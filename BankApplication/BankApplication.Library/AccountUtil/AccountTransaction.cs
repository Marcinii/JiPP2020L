using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApplication.Library.AccountUtil
{
    /// <summary>
    /// Klasa reprezentująca model rekordu tabeli przechowjącej dane o dokonanej transakcji.
    /// </summary>
    /// <param name="id">Identyfikator transakcji</param>
    /// <param name="srcAccountId">Identyfikator źródłowego konta bankowego</param>
    /// <param name="srcAccount">Konto źródłowe</param>
    /// <param name="name">Nazwa traksakcji</param>
    /// <param name="destinationAccountId">Identyfikator konta docelowego</param>
    /// <param name="destinationAccount">Konto docelowe</param>
    /// <param name="createAt">Data wykonania transakcji</param>
    /// <param name="transactionType">Identyfikator rodzaju dokonanej transakcji</param>
    /// <param name="accountTransactionType">Rodzaj wykonanej transakcji</param>
    /// <param name="ammount">Kwota przelewu</param>
    /// <see cref="Account"/>
    /// <see cref="AccountTransactionType"/>
    [Table("account_transactions")]
    public class AccountTransaction
    {
        public int id { get; set; }

        [Column("src_account_id")]
        public int srcAccountId { get; set; }
        public virtual Account srcAccount { get; set; }

        public string name { get; set; }

        [Column("destination_account_id")]
        public int destinationAccountId { get; set; }
        public virtual Account destinationAccount { get; set; }

        [Column("created_at")]
        public DateTime createdAt { get; set; }

        [Column("transaction_type")]
        public int transactionType { get; set; }
        public virtual AccountTransactionType accountTransactionType { get; set; }

        public decimal ammount { get; set; }

        


        public AccountTransaction() {}
    }
}
