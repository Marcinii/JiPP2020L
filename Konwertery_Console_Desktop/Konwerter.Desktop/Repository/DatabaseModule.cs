using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Desktop.Repository
{
    public class DatabaseModule
    {
        public static List<CONVERSIONS> getAllConversions()
        {
            using (ConverterDBEntities context = new ConverterDBEntities())
            {
                List<CONVERSIONS> conversions = context.CONVERSIONS.ToList();

                return conversions;
            }
        }

        public static void insert(CONVERSIONS item)
        {
            using (ConverterDBEntities context = new ConverterDBEntities())
            {
                context.CONVERSIONS.Add(item);
                context.SaveChanges();
            }
        }

        public static List<CONVERSIONS> getConversionsByType(string type)
        {
            using (ConverterDBEntities context = new ConverterDBEntities())
            {
                List<CONVERSIONS> conversions = context.CONVERSIONS
                    .SqlQuery("SELECT * FROM CONVERSIONS WHERE name = @type", new SqlParameter("@type", type)).ToList();

                return conversions;
            }
        }
    }
}
