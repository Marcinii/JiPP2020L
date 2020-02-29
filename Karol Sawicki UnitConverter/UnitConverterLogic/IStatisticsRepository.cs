using System.Collections.Generic;
using UnitConverterLogic.Model;

namespace UnitConverterLogic
{
    public interface IStatisticsRepository
    {
        void AddStatistic(Statistic statistic);
        IEnumerable<Statistic> GetStatistics();
    }
}