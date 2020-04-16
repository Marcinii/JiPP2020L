namespace KonwerterWPF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<KonwersjeTabela> KonwersjeTabelas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KonwersjeTabela>()
                .Property(e => e.nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<KonwersjeTabela>()
                .Property(e => e.wartosc_a)
                .IsUnicode(false);

            modelBuilder.Entity<KonwersjeTabela>()
                .Property(e => e.wartosc_b)
                .IsUnicode(false);
        }
    }
}
