using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad7.Desktop
{
    class SQLiteDbContext : DbContext
    {

        public DbSet<History> History { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=.\\database.db");
        }

    }
}
