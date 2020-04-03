namespace unitconverter.desktop
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class codefirst_unitsstatsmodel : DbContext
    {
        // Your context has been configured to use a 'codefirst_unitsstatsmodel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'unitconverter.desktop.codefirst_unitsstatsmodel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'codefirst_unitsstatsmodel' 
        // connection string in the application configuration file.
        public codefirst_unitsstatsmodel()
            : base("name=codefirst_unitsstatsmodel")
        {
        }

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