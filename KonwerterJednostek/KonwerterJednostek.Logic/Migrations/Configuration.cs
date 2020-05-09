namespace KonwerterJednostek.Logic.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KonwerterJednostek.Logic.KonwerterBaza>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "KonwerterJednostek.Logic.KonwerterBaza";
        }

        protected override void Seed(KonwerterJednostek.Logic.KonwerterBaza context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
