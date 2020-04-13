namespace Logic
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ConversionDataEntities : DbContext
    {
        
        public ConversionDataEntities()
            : base("name=ConversionDataEntities")
        {
        }
        public DbSet<Conversion> Conversions { get; set; }
    }
}