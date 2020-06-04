using BankApplication.Library.AccountUtil;
using BankApplication.Library.UserUtil;
using System.Data.Entity;

namespace BankApplication.Library.Context
{
    /// <summary>
    /// Klasa odpowiedzialna za wykonywanie operacji na bazie danych
    /// </summary>
    /// <param name="users">Lista użytkowników</param>
    /// <param name="accounts">Lista kont bankowych</param>
    /// <param name="transactions">Lista wszystkich dokonanych transakcji</param>
    /// <see cref="User"/>
    /// <see cref="Account"/>
    /// <see cref="AccountTransaction"/>
    public partial class CustomDatabaseContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<AccountTransaction> transactions { get; set; }

        public CustomDatabaseContext() : base("name=CustomDatabaseContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.accounts)
                .WithRequired(x => x.user);

            modelBuilder.Entity<Account>()
                .HasMany(x => x.transactions)
                .WithRequired(x => x.srcAccount);

            modelBuilder.Entity<AccountTransactionType>()
                .HasMany(x => x.transactions)
                .WithRequired(x => x.accountTransactionType)
                .HasForeignKey(x => x.transactionType)
                .WillCascadeOnDelete(false);
        }
    }
}
