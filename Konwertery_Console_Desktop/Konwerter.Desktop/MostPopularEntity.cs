namespace Konwerter.Desktop
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MostPopularEntity : DbContext
    {
        public MostPopularEntity()
            : base("name=MostPopularEntity")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MostPopularEntity>(null);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<MostPopularConversion> MostPopularConversions { get; set; }
    }
}