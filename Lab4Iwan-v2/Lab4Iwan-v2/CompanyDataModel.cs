namespace Lab4Iwan_v2
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CompanyDataEntities : DbContext
    {
        public CompanyDataEntities()
            : base("name=CompanyDataModel")
        {
        }

        public DbSet<Employees> Employees { get; set; }
    }
}