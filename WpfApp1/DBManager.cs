using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Konwerter_jedn;

namespace WpfApp1
{
    class DBManager
    {
        public List<Statistics> statistics;

        private int skipIndexCount;

        private const int RowsPerPage = 20;

        public DBManager()
        {
            LoadDB();
        }

        public List<Statistics> LoadDB()
        {
            using (StatisticsEntities context = new StatisticsEntities())
            {
                statistics = context.Statistics.OrderBy(x => x.Id).ToList();
                return statistics;
            }
        }

        public void SaveToDB(Statistics statistic, DataGrid dataGrid) //zapisz do bazy danych
        {
            using (StatisticsEntities context = new StatisticsEntities())
            {
                context.Statistics.Add(statistic);
                context.SaveChanges();

                statistics = context.Statistics.ToList();
                //dataGrid.ItemsSource = statistics;
            }
        }

        private List<Statistics> ByDate(DateTime? dateFrom, DateTime? dateTo) //pokaz po dacie
        {
            if (dateFrom.HasValue)
            {
                statistics = statistics.Where(statistic => statistic.conversion_date >= dateFrom).ToList();
            }
            if (dateTo.HasValue)
            {
                statistics = statistics.Where(statistic => statistic.conversion_date <= dateTo).ToList();
            }
            /*
            else if (dateTo.HasValue && dateFrom.HasValue)
            {
                statistics = statistics.Where(statistic => DbFunctions.TruncateTime(statistic.conversion_date) >= dateFrom && DbFunctions.TruncateTime(statistic.conversion_date) <= dateTo).ToList();
            }
            */

            return statistics;
        }

        private List<Statistics> ByConverter(string name) //pokaz wedlug wybranego konwertera
        {
            if (name != "Wszystkie")
            {
                statistics = statistics.Where(statistic => statistic.converter_type == name).ToList();
            }
            return statistics;
        }

        public List<Statistics> Filter(string name, DateTime? dateFrom, DateTime? dateTo) //filtruj wg wybranego konwertera i dat
        {
            LoadDB();


            ByConverter(name);
            ByDate(dateFrom, dateTo);
            skipIndexCount = 0;
            return statistics.ToList();//.Take(RowsPerPage).ToList();
        }

        public List<Statistics> TakeNext() //nastepna strona
        {
            if (skipIndexCount < statistics.Count - RowsPerPage)
            {
                skipIndexCount += RowsPerPage;
            }

            return statistics.Skip(skipIndexCount).Take(RowsPerPage).ToList();
        }

        public List<Statistics> TakePrev() //poprzednia strona
        {
            if (skipIndexCount > 0)
            {
                skipIndexCount -= RowsPerPage;
            }
            return statistics.Skip(skipIndexCount).Take(RowsPerPage).ToList();
        }

        public List<string> Top3c() //top 3 konwertery
        {
            Dictionary<string, int> konwertery = new Dictionary<string, int>();
            foreach (Statistics s in statistics)
            {
                if (!konwertery.Keys.ToList().Exists(x => x == s.converter_type))
                {
                    konwertery.Add(s.converter_type, 0);
                }
            }

            List<string> klucze = konwertery.Keys.ToList();

            foreach (string key in klucze)
            {
                konwertery[key] = statistics.Count(x => x.converter_type == key);
            }

            konwertery = konwertery.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            return konwertery.Keys.Take(3).ToList();
        }
    }
}
