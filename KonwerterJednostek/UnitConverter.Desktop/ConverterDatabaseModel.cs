namespace UnitConverter.Desktop
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ConverterDatabaseEntities : DbContext
    {
        // Your context has been configured to use a 'ConverterDatabaseModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'UnitConverter.Desktop.ConverterDatabaseModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ConverterDatabaseModel' 
        // connection string in the application configuration file.
        public ConverterDatabaseEntities()
            : base("name=ConverterDatabaseModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }



        public DbSet<ConverterData> ConverterDatas { get; set; }
        public DbSet<RateData> ConverterRates { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}