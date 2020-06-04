using BankApplication.Library.UserUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApplication.Library.AccountUtil
{
    /// <summary>
    /// Klasa reprezentująca model rekordu tabeli, która ma za zadanie przechowywać dane o koncie bankowym.
    /// </summary>
    /// <param name="id">Identyfikator konta bankowego</param>
    /// <param name="user">Właściciel konta</param>
    /// <param name="name">Nazwa konta</param>
    /// <param name="salary">Aktualny stan konta</param>
    /// <param name="accountNumber">Numer konta bankowego (poosłuży do wykonywania transakcji)</param>
    /// <param name="createdAt">Data utworzenia konta</param>
    /// <param name="transactions">Lista dokonanych na danym koncie traksakcji</param>
    /// <see cref="User"/>
    [Table("accounts")]
    public class Account
    {
        public int id { get; set; }
        public virtual User user { get; set; }

        public string name { get; set; }
        public decimal salary { get; set; }

        [Column("account_number")]
        public string accountNumber { get; set; }

        [Column("created_at", TypeName = "smalldatetime")]
        public DateTime createdAt { get; set; } = DateTime.Now;

        public virtual List<AccountTransaction> transactions { get; set; } = new List<AccountTransaction>();

        public Account() {}
    }
}
