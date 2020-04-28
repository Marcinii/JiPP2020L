namespace Project.Logic
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ConverterData : DbContext
    {
       
        public ConverterData()
            : base("name=ConverterData")
        {
        }

        public DbSet<Converter> Converters { get; set; }
        
    }

}