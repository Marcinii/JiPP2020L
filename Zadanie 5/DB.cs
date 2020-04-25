namespace application
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB")
        {
        }

        public virtual DbSet<StatTable> StatTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatTable>()
                .Property(e => e.ConverterType)
                .IsUnicode(false);

            modelBuilder.Entity<StatTable>()
                .Property(e => e.UnitFrom)
                .IsUnicode(false);

            modelBuilder.Entity<StatTable>()
                .Property(e => e.UnitTo)
                .IsUnicode(false);

            modelBuilder.Entity<StatTable>()
                .Property(e => e.ValueFrom)
                .IsUnicode(false);

            modelBuilder.Entity<StatTable>()
                .Property(e => e.ValueTo)
                .IsUnicode(false);
        }

  
    }
}
