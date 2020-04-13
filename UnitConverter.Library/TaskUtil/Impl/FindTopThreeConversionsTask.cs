using System.Collections.Generic;
using System.Linq;
using UnitConverter.Library.History;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.TypeUtil.DateTimeType;

namespace UnitConverter.Library.TaskUtil.Impl
{
    /// <summary>
    /// Klasa dziedzicząca klasę abstrakcyjną <see cref="Task{T}"/>, która jest implementacją nowego zadania.
    /// Ma on za zadanie wyszukania trzech najczęściej wykonywanych konwersji w danym przedziale czasowym.
    /// Jeżeli dany parametr nie jest wprowadzony, to nie jest on brany pod uwage w trakcie filtrowania danych
    /// </summary>
    /// <param name="customDatabaseContext">
    ///     Pole potrzebne do wykonania operacji na bazie danych
    /// </param>
    /// <see cref="CustomDatabaseContext"/>
    /// <see cref="ConversionHistory"/>
    public class FindTopThreeConversionsTask : Task<List<KeyValuePair<ConversionHistory, int>>>
    {
        private CustomDatabaseContext customDatabaseContext;

        public FindTopThreeConversionsTask(CustomDatabaseContext customDatabaseContext)
        {
            this.customDatabaseContext = customDatabaseContext;
        }

        protected override List<KeyValuePair<ConversionHistory, int>> apply(Operation operation)
        {
            CustomDate fromDate = (CustomDate)parameters["Data początkowa"].value;
            CustomDate toDate = (CustomDate)parameters["Data końcowa"].value;

            List<ConversionHistory> res = new List<ConversionHistory>(customDatabaseContext.conversionHistoryList);

            if (!fromDate.isEmpty())
                res = res.Where(x => x.createdAt >= fromDate).ToList();

            if (!toDate.isEmpty())
                res = res.Where(x => x.createdAt <= toDate).ToList();

            return res
                    .GroupBy(x => x.converterName)
                    .Select(x => new KeyValuePair<ConversionHistory, int>(x.First(), x.Count()))
                    .OrderByDescending(x => x.Value)
                    .Take(3)
                    .ToList();
        }
    }
}
