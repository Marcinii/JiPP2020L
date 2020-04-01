namespace UnitConverterDesktopApp
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ConverterDataModel : DbContext
    {
        public ConverterDataModel()
            : base("name=ConverterDataModel") { }

        public DbSet<Result> Results { get; set; }
    }
}