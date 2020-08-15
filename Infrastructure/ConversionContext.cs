using Logic.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ConversionContext : DbContext
    {
        public ConversionContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<ConverterKind> ConverterKinds { get; set; }
        public virtual DbSet<Conversion> Conversions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConverterKind>().HasKey(x => x.Id);
            modelBuilder.Entity<Conversion>().HasKey(x => x.Id);

            modelBuilder.Entity<Conversion>()
                .HasOne<ConverterKind>(x => x.ConverterKind)
                .WithMany()
                .HasForeignKey(x => x.KindId);
        }
    }
}
