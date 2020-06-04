namespace Calendar
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

        public virtual DbSet<hotel> hotel { get; set; }
        public virtual DbSet<login> login { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<hotel>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<hotel>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<hotel>()
                .Property(e => e.pets)
                .IsFixedLength();

            modelBuilder.Entity<hotel>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<hotel>()
                .Property(e => e.quality)
                .IsUnicode(false);

            modelBuilder.Entity<hotel>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<login>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<login>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<login>()
                .Property(e => e.password_)
                .IsUnicode(false);
        }
    }
}
