namespace Modul4DBSample02
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

        public DbSet<Employee> Employees { get; set; }
    }
}