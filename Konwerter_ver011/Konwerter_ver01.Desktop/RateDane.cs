namespace Konwerter_ver01.Desktop
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RateDane : DbContext
    {
        public RateDane()
            : base("name=RateDane")
        {
        }

        public DbSet<KonwerterDa> RateDaWy { get; set; }
    }

   
}