namespace Konwerter_jednostek
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BazaDanych : DbContext
    {

        public BazaDanych()
            : base("name=BazaDanych")
        {
        }
        public DbSet<Konwersja> Konwersje { get; set; }



    }


}