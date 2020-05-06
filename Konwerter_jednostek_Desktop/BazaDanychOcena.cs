namespace Konwerter_jednostek
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BazaDanychOcena : DbContext
    {

        public BazaDanychOcena()
            : base("name=BazaDanychOcena")
        {
        }
        
        public DbSet<OcenaBaza> OcenaDB { get; set; }
    }


}