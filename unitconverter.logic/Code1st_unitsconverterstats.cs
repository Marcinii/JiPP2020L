namespace unitconverter.logic
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Code1st_unitsconverterstats : DbContext
    {
        // Your context has been configured to use a 'Code1st_unitsconverterstats' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'unitconverter.logic.Code1st_unitsconverterstats' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Code1st_unitsconverterstats' 
        // connection string in the application configuration file.
        public Code1st_unitsconverterstats()
            : base("name=Code1st_unitsconverterstats")
        {
        }
        public DbSet<conversions> conversions { get; set; }
        public DbSet<rates> rates { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}