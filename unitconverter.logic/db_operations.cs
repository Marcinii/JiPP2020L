using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace unitconverter.logic
{
    public abstract class db_operations
    { // class for operations on database
        public static List<conversions> download_data() //dodaj parametr, który bedzie decydowal o tym co ma byc pobierane
        {
            using (Code1st_unitsconverterstats context = new Code1st_unitsconverterstats()) 
            {
                List<conversions> records = context.conversions.ToList();
                return records;
            }
            
        }

        public static void insert_data(int converter, string units_from, string units_to, string value_from, string value_to)
        {
            using (Code1st_unitsconverterstats context = new Code1st_unitsconverterstats()) 
            {
                conversions new_record = new conversions()
                {
                    converter = converter,
                    units_from = units_from,
                    units_to = units_to,
                    value_from = value_from,
                    value_to = value_to,
                    conversion_date = DateTime.Now
                };
                context.conversions.Add(new_record);
                context.SaveChanges();
            }
        }
    }
}
