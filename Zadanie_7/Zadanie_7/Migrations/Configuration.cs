namespace Zadanie_7.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Zadanie_7.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Zadanie_7.Model1";
        }

        protected override void Seed(Zadanie_7.Model1 context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
