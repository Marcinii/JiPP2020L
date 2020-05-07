namespace Konwerter.Desktop
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GradeModel : DbContext
    {
        
        public GradeModel()
            : base("name=GradeModel")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<GradeModel>(null);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<GRADES> GRADES { get; set; }
    }
}