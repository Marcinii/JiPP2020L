namespace Book.Desktop
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhoneBookDataModel : DbContext
    {
        public PhoneBookDataModel()
            : base("name=PhoneBookDataModel")
        {
        }
        public DbSet<BasBook> BasBookMy {get; set;}
    }

   
}