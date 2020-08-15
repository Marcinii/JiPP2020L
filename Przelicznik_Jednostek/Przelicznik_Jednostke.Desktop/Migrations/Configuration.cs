namespace Przelicznik_Jednostke.Desktop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Przelicznik_Jednostke.Desktop.model_danych>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Przelicznik_Jednostke.Desktop.model_danych";
        }

        protected override void Seed(Przelicznik_Jednostke.Desktop.model_danych context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
