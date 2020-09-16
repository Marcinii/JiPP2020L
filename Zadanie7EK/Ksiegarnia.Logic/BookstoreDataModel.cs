namespace Ksiegarnia.Logic
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookstoreDataModel : DbContext
    {
        // Your context has been configured to use a 'LibraryDataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Ksiegarnia.Logic.LibraryDataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LibraryDataModel' 
        // connection string in the application configuration file.
        public BookstoreDataModel()
            : base("name=BookstoreDataModel")
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
    }
}