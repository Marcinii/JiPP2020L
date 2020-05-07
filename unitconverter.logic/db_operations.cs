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
        public static List<conversions> download_data(int f_converter, DateTime? f_date_from, DateTime? f_date_to, int from_lp, int how_much_take_lp) 
        {
            if (f_converter != 0)
            {
                if(f_date_from != null && f_date_from != null)
                {
                    using (Code1st_unitsconverterstats context = new Code1st_unitsconverterstats())
                    {
                        List<conversions> records = context.conversions
                            .Where(c => c.converter == f_converter)
                            .Where(c => c.conversion_date > f_date_from)
                            .Where(c => c.conversion_date < f_date_to)
                            .OrderBy(c => c.id)
                            .Skip(from_lp)
                            .Take(how_much_take_lp)
                            .ToList();
                        return records;
                    }
                }
                else
                {
                    using (Code1st_unitsconverterstats context = new Code1st_unitsconverterstats())
                    {
                        List<conversions> records = context.conversions.Where(c => c.converter == f_converter)
                            .OrderBy(c => c.id)
                            .Skip(from_lp)
                            .Take(how_much_take_lp)
                            .ToList();
                        return records;
                    }
                }    
            }
            else
            {
                /*using (Code1st_unitsconverterstats context = new Code1st_unitsconverterstats())
                {
                    List<conversions> records = context.conversions.ToList();
                    return records;
                }*/
                if (f_date_from != null && f_date_from != null)
                {
                    using (Code1st_unitsconverterstats context = new Code1st_unitsconverterstats())
                    {
                        List<conversions> records = context.conversions
                            .Where(c => c.conversion_date > f_date_from)
                            .Where(c => c.conversion_date < f_date_to)
                            .OrderBy(c => c.id)
                            .Skip(from_lp)
                            .Take(how_much_take_lp)
                            .ToList();
                        return records;
                    }
                }
                else
                {
                    using (Code1st_unitsconverterstats context = new Code1st_unitsconverterstats())
                    {
                        List<conversions> records = context.conversions
                            .OrderBy(c => c.id)
                            .Skip(from_lp)
                            .Take(how_much_take_lp)
                            .ToList();
                        return records;
                    }
                }
            }    
        }

        public static string make_rank(List<conversions> records)
        {
            /*List<string> conversions = new List<string>() { };
            List<int> how_much = new List<int>() { };
            string conversion, find_conversion;
            int index;
            foreach (conversions r in records)
            {
                conversion = r.units_from + "=>" + r.units_to;
                find_conversion = conversions.Find(c => c.Equals(conversion));
                if (find_conversion == "false")
                {
                    conversions.Add(find_conversion);
                    how_much.Add(1);
                }
                else
                {
                    index = conversions.FindIndex(x => x == conversion);
                    how_much[index]++;
                }
            }*/
            /*foreach (conversions r in records)
            {
                r.units_from
            }*/
            int int_first = 0, temp_int_first = 0;
            string string_first = "null", without="null";
            string[] result = new string[3];
            int how_much = records.Count;
            for (int k = 0; k<3; k++) {
                for (int i = 0; i < how_much; i++)
                {
                    for (int j = 0; j < how_much; j++)
                    {
                        if (records[i].units_from + records[i].units_to == records[j].units_from + records[j].units_to &&
                            records[i].units_from + records[i].units_to != without)
                        {
                            temp_int_first++;
                        }
                        if (temp_int_first > int_first)
                        {
                            string_first = records[i].units_from + " => " + records[i].units_to;
                            without = records[i].units_from + records[i].units_to; 
                            result[k] = string_first;
                        }
                    }
                }
                int_first = 0; temp_int_first = 0;
            }
            //return result;
            return string_first;
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

        public static void insert_rate(int gave_rate)
        {
            using (Code1st_unitsconverterstats context = new Code1st_unitsconverterstats())
            {
                rates new_record = new rates()
                {
                    rate = gave_rate
                };
                context.rates.Add(new_record);
                context.SaveChanges();
            }
        }

        public static List<rates> download_last_rate()
        {
            using (Code1st_unitsconverterstats context = new Code1st_unitsconverterstats())
            {
                List<rates> records = context.rates
                    .OrderByDescending(r => r.id)
                    .Take(1)
                    .ToList();
                return records;
            }
        }
    }
}
