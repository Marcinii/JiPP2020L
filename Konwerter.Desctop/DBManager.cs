using KonwerterJednostek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Konwerter.Desctop
{
    class DBManager
    {
        private List<Statistic> statistics;

        private int skipIndexCount;

        private const int RowsPerPage = 20;

        public DBManager()
        {
            LoadDB();
        }

        public List<Statistic> LoadDB()
        {
            using (StatisticDataEntities1 context = new StatisticDataEntities1())
            {
                statistics = context.Statistics.OrderBy(x => x.Id).ToList();
                return statistics;
            }
        }

        public void SaveToDB(Statistic statistic, DataGrid dataGrid)
        {
            using (StatisticDataEntities1 context = new StatisticDataEntities1())
            {
                context.Statistics.Add(statistic);
                context.SaveChanges();

                statistics = context.Statistics.ToList();
                dataGrid.ItemsSource = statistics;
            }
        }

        private List<Statistic> ByDate(DateTime? dateFrom, DateTime? dateTo)
        {
            if (dateFrom != null)
            {
                statistics = statistics.Where(statistic => statistic.conversion_data >= dateFrom).ToList();
            }
            else if (dateTo != null)
            {
                statistics = statistics.Where(statistic => statistic.conversion_data <= dateTo).ToList();
            }
            else if (dateTo != null && dateFrom != null)
            {
                statistics = statistics.Where(statistic => statistic.conversion_data >= dateFrom && statistic.conversion_data <= dateTo).ToList();
            }

            return statistics;
        }

        private List<Statistic> ByConverter(string name)
        {
            if (name != "Wszystkie")
            {
                statistics = statistics.Where(statistic => statistic.converter_type == name).ToList();
            }
            return statistics;
        }

        public List<Statistic> Filter(string name, DateTime? dateFrom, DateTime? dateTo)
        {
            LoadDB();
            ByConverter(name);
            ByDate(dateFrom, dateTo);
            skipIndexCount = 0;
            return statistics.Take(RowsPerPage).ToList();
        }

        public List<Statistic> TakeNext()
        {
            if(skipIndexCount < statistics.Count - RowsPerPage)
            {
                skipIndexCount += RowsPerPage;
            }
            
            return statistics.Skip(skipIndexCount).Take(RowsPerPage).ToList();
        }

        public List<Statistic> TakePrev()
        {
            if(skipIndexCount > 0)
            {
                skipIndexCount -= RowsPerPage;
            }
            return statistics.Skip(skipIndexCount).Take(RowsPerPage).ToList();
        }

        public List<string> Top3c()
        {
            Dictionary<string, int> konwertery = new Dictionary<string, int>();
            foreach(Statistic s in statistics)
            {
                if(!konwertery.Keys.ToList().Exists(x => x == s.converter_type))
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
