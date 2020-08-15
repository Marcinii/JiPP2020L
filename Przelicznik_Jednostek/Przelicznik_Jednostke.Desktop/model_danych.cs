namespace Przelicznik_Jednostke.Desktop
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Przelicznik_Jednostek.Logic;

    public class model_danych : DbContext
    {
        // Your context has been configured to use a 'Model_danych' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Przelicznik_Jednostke.Desktop.Model_danych' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model_danych' 
        // connection string in the application configuration file.
        public model_danych()
            : base("name=model_danych")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
       public virtual DbSet<daneBazaDBO> bazaDane { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}