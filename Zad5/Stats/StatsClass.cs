using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stats
{
    public class StatsClass
    {
        public static List<Stats> GetAll()
        {
            using (db_statsEntities context = new db_statsEntities())
            {
                List<Stats> lista = new List<Stats>(context.Stats.ToList());
                return lista;
            }
        }
        public static void Insert(string converter, string unitIn, string unitOut, DateTime date, string valueIn, string valueOut)
        {
            using (db_statsEntities context = new db_statsEntities())
            {
                Stats Stat = new Stats()
                {
                    converter = converter,
                    unitIn = unitIn,
                    unitOut = unitOut,
                    ConversionDate = date,
                    valueIn = valueIn,
                    valueOut = valueOut
                };

                context.Stats.Attach(Stat);
                context.Stats.Add(Stat);
                context.SaveChanges();
            }
        }
        public static List<Stats> Search(string converter, DateTime from, DateTime to, int page)
        {
           // Console.WriteLine(converter + " " + from + " " + to);
            using (var context = new db_statsEntities())
            {
                var query = context.Stats.Where(s => s.converter == converter)
                    .Where(s => s.ConversionDate >= from)
                    .Where(s => s.ConversionDate <= to)
                    .Skip(20 * (page - 1)) //page number
                    .Take(20) //page size
                    .ToList<Stats>();
                return query;
            }
        }
        public static IEnumerable Top(DateTime from, DateTime to)
        {
          //  Console.WriteLine(converter + " " + from + " " + to);
            using (var context = new db_statsEntities())
            {
                var query = context.Stats//.Where(s => s.converter == converter)
                    .Where(s => s.ConversionDate >= from)
                    .Where(s => s.ConversionDate <= to)
                    .ToList<Stats>();
                
                var res = query.GroupBy(s => s.converter)
                    .Select(s => new{converter = s.Key, num = s.Count()})
                    .OrderByDescending(s => s.num).Take(3);
                
                return res;
            }
        }
        public static IEnumerable GetRate()
        {
            using (var context = new db_statsEntities())
            {
                var query = context.Stats
                    .Where(s => s.converter == "RATE")
                    .OrderByDescending(s=> s.Id)
                    .Take(1)
                    .ToList<Stats>();

                return query;

            }
        }
    }
}
