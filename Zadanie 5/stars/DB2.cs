namespace stars
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB2 : DbContext
    {
        public DB2()
            : base("name=DB2")
        {
        }

        public virtual DbSet<ranking> ranking { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ranking>()
               .Property(e => e.Id);

            modelBuilder.Entity<ranking>()
                .Property(e => e.rating);
        }
    }
}
