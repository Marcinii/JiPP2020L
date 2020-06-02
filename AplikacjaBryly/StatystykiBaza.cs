namespace AplikacjaBryly
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StatystykiBaza : DbContext
    {

        public StatystykiBaza()
            : base("name=StatystykiBaza")
        {
        }

        public DbSet<StatystykiBryly> SBryly { get; set; }

    }


}