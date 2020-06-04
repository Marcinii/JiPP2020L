using BankApplication.Library.AccountUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApplication.Library.UserUtil
{
    /// <summary>
    /// Klasa reprezentująca model rekordu tabeli przechowująca dane o użytkowniku.
    /// </summary>
    /// <param name="id">Identyfikator użytkownika</param>
    /// <param name="username">Nazwa użytkownika</param>
    /// <param name="password">Hasło</param>
    /// <param name="firstName">Imię</param>
    /// <param name="lastName">Nazwisko</param>
    /// <param name="emailAddress">Adres e-mail</param>
    /// <param name="birthDate">Data urodzenia</param>
    /// <param name="accounts">Lista posiadanych kont bankowych</param>
    /// <see cref="Account"/>
    [Table("users")]
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        [Column("first_name")]
        public string firstName { get; set; }

        [Column("last_name")]
        public string lastName { get; set; }

        [Column("email_address")]
        public string emailAddress { get; set; }

        [Column("birth_date")]
        public DateTime birthDate { get; set; }

        public virtual List<Account> accounts { get; set; } = new List<Account>();

        public User() { }
    }
}
