namespace UnitConverterv2.Logic
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ConverterDataModel : DbContext
    {
        public ConverterDataModel()
            : base("name=ConverterDataModel")
        {
        }

        public DbSet<Conversion> Conversions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}