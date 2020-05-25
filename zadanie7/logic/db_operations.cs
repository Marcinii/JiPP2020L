using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public abstract class db_operations
    {
        public static List<history> download_data(int from_lp, int how_much_take_lp)
        {
            using (Model1 context = new Model1())
            {
                List<history> records = context.history
                    .OrderBy(h => h.id)
                    .Skip(from_lp)
                    .Take(how_much_take_lp)
                    .ToList();
                return records;
            }
        }

        public static void insert_data(string umowa, string brutto, string netto)
        {
            using (Model1 context = new Model1())
            {
                history new_record = new history()
                {
                    umowa = umowa,
                    brutto = brutto,
                    netto = netto

                };
                context.history.Add(new_record);
                context.SaveChanges();
            }
        }
    }
}
