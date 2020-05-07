namespace Konwerter_ver01.Desktop
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class KonwerterDane : DbContext
    {
        // Your context has been configured to use a 'KonwerterDane' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Konwerter_ver01.Desktop.KonwerterDane' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'KonwerterDane' 
        // connection string in the application configuration file.
        public KonwerterDane()
            : base("name=KonwerterDane")
        {
        }

       public DbSet<KonwerterDa> KonwerterDaWy { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}