namespace FinancialSettlementApp.Logic.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinancialSettlementApp.Logic.FinancialSettlementAppBase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FinancialSettlementApp.Logic.FinancialSettlementAppBase";
        }

        protected override void Seed(FinancialSettlementApp.Logic.FinancialSettlementAppBase context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
