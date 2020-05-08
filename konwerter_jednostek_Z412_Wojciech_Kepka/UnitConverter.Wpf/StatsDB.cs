namespace UnitConverter.Wpf
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StatsDB : DbContext
    {
        public StatsDB()
            : base("name=StatsDB")
        {
        }

        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>()
                .Property(e => e.converter)
                .IsUnicode(false);

            modelBuilder.Entity<Record>()
                .Property(e => e.inputUnit)
                .IsUnicode(false);

            modelBuilder.Entity<Record>()
                .Property(e => e.outputUnit)
                .IsUnicode(false);

            modelBuilder.Entity<Rating>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
