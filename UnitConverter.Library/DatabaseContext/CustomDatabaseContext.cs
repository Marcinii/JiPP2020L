using System.Data.Entity;
using UnitConverter.Library.RatingUtil;

namespace UnitConverter.Library.History
{
    /// <summary>
    /// Klasa, za pomocą której będziemy mieli możliwość podłączeni się do bazy danych.
    /// </summary>
    /// <param name="conversionHistoryList">
    ///     Pole, które będziemy wykorzystywali do wyciągania historii wykonanych konwersji
    /// </param>
    /// <param name="ratings">
    ///     Pole, które będzie wykorzystywane do wyciągania informacji o ocenach użytkowników
    /// </param>
    /// <see cref="ConversionHistory"/>
    public class CustomDatabaseContext : DbContext
    {
        public DbSet<ConversionHistory> conversionHistoryList { get; set; }
        public DbSet<Rating> ratings { get; set; }

        public CustomDatabaseContext() : base("name=CustomDatabaseContext") { }
    }
}