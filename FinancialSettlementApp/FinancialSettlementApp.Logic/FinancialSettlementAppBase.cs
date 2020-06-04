namespace FinancialSettlementApp.Logic
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FinancialSettlementAppBase : DbContext
    {
        
        public FinancialSettlementAppBase()
            : base("name=FinancialSettlementAppBase")
        {
        }
        public DbSet<Taking> taking { get; set; }
        public DbSet<Cost> cost { get; set; }
        public DbSet<TaxPrepayment> taxPrepayment { get; set; }

    }

    
}