using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PlotDrawer.Database
{
    public static class DatabaseIO
    {
        public static void AddToDatabase(string name, List<double> prms )
        {
            using var db = new PolynomialContext();
            UsedPolynomial usedPolynomial = new UsedPolynomial()
            {
                Name = name,
                Params = ParseParams(prms)
            };
            db.UsedPolynomials.Add(usedPolynomial);
            db.SaveChanges();
        }

        public static async Task AddToDatabaseAsync(string name, List<double> prms)
        {           
            using var db = new PolynomialContext();
            UsedPolynomial usedPolynomial = new UsedPolynomial()
            {
                Name = name,
                Params = ParseParams(prms)
            };
            db.UsedPolynomials.Add(usedPolynomial);
            await db.SaveChangesAsync();
        }

        public static async Task<List<UsedPolynomial>> LoadFromDatabaseAsync()
        {
            using var db = new PolynomialContext();
            return await db.UsedPolynomials.OrderByDescending(e => e.ID).Take(5).ToListAsync();
        }

        private static string ParseParams(List<double> prms)
        {
            string p = "";
            prms.ForEach(x =>
            {
                p += x.ToString()+";";               
            });
            return p;
        }
    }
}
