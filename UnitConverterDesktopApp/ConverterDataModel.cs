namespace UnitConverterDesktopApp
{
    using System.Data.Entity;

    public class ConverterDataModel : DbContext
    {
        public ConverterDataModel()
            : base("name=ConverterDataModel") { }

        public DbSet<Result> Results { get; set; }
    }
}