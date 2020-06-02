using Microsoft.EntityFrameworkCore;
using System;

namespace FunctionDrawer.Database
{   
    public class PolynomialContext : DbContext
    {
        public DbSet<UsedPolynomial> UsedPolynomials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"data source=localhost;initial catalog=PolynomialCalc;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        }
    }

    public class UsedPolynomial
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Params { get; set; }
    }
}
