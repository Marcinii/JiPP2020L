namespace KonwerterJednostek.Logic
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class KonwerterBaza : DbContext
    {
        public KonwerterBaza()
            : base("name=KonwerterBaza")
        {
        }
        public DbSet<Wpis> registrations { get; set; }
        public DbSet<Star> newStar { get; set; }
    }
}
