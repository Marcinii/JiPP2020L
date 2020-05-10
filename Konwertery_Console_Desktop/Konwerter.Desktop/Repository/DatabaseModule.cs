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

        public static List<CONVERSIONS> getConversionsByParams(string type, string dateFrom, string dateTo)
        {
            using (ConverterDBEntities context = new ConverterDBEntities())
            {
                List<CONVERSIONS> conversions = context.CONVERSIONS
                    .SqlQuery("SELECT * FROM CONVERSIONS WHERE name = @type " +
                    "AND dateOfConversion BETWEEN @dateFrom AND @dateTo"
                    , new SqlParameter("@type", type), new SqlParameter("@dateFrom", dateFrom), new SqlParameter("@dateTo", dateTo)).ToList();

                return conversions;
            }
        }

        public static List<MostPopularConversion> getAllMostPopular()
        {
            using (MostPopularEntity context = new MostPopularEntity())
            {
                List<MostPopularConversion> conversions = context.MostPopularConversions
                    .SqlQuery("SELECT TOP 3 row_number() OVER(ORDER BY c.name) id, c.name, c.unitFrom, c.unitTo, COUNT(*) AS ile " +
                               "FROM(SELECT name, unitFrom, unitTo, dateOfConversion FROM CONVERSIONS) c " +
                               "GROUP BY c.name, c.unitFrom, c.unitTo " +
                               "ORDER BY ile DESC").ToList();

                return conversions;
            }
        }

        public static List<MostPopularConversion> getMostPopularByType(string type)
        {
            using (MostPopularEntity context = new MostPopularEntity())
            {
                List<MostPopularConversion> conversions = context.MostPopularConversions
                    .SqlQuery("SELECT TOP 3 row_number() OVER(ORDER BY c.name) id, c.name, c.unitFrom, c.unitTo, COUNT(*) AS ile " +
                               "FROM(SELECT name, unitFrom, unitTo, dateOfConversion FROM CONVERSIONS WHERE name = @type) c " +
                               "GROUP BY c.name, c.unitFrom, c.unitTo " +
                               "ORDER BY ile DESC", new SqlParameter("@type", type)).ToList();

                return conversions;
            }
        }

        public static void insertGrade(GRADES item)
        {
            using (GradeModel context = new GradeModel())
            {
                context.GRADES.Add(item);
                context.SaveChanges();
            }
        }

        public static List<GRADES> getGrade()
        {
            using (GradeModel context = new GradeModel())
            {
                List<GRADES> grades = context.GRADES
                    .SqlQuery("SELECT TOP 1 * FROM GRADES ORDER BY id DESC").ToList();

                return grades;
            }
        }
    }
}
