using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnitConverter.Library.History;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.TypeUtil;
using UnitConverter.Library.TypeUtil.DateTimeType;

namespace UnitConverter.Library.TaskUtil.Impl
{
    /// <summary>
    /// Klasa dziedzicząca klasę abstrakcyjną <see cref="Task{T}"/>, która jest implementacją nowego zadania.
    /// Ma on za zadanie wyszukania historii wykonanycch konwersji zgodnie z podanymi parametrami.
    /// Jeżeli dany parametr nie jest wprowadzony, to nie jest on brany pod uwage w trakcie filtrowania danych
    /// </summary>
    /// <param name="customDatabaseContext">
    ///     Pole potrzebne do wykonania operacji na bazie danych
    /// </param>
    /// <see cref="CustomDatabaseContext"/>
    /// <see cref="ConversionHistory"/>
    public class FindAllConversionHistoryTask : Task<List<ConversionHistory>>
    {
        private CustomDatabaseContext customDatabaseContext;

        public FindAllConversionHistoryTask(CustomDatabaseContext customDatabaseContext)
        {
            this.customDatabaseContext = customDatabaseContext;
        }

        protected override List<ConversionHistory> apply(Operation operation)
        {
            CustomString conversionName = (CustomString) parameters["Nazwa konwertera"].value;
            CustomDate fromDate = (CustomDate) parameters["Data początkowa"].value;
            CustomDate toDate = (CustomDate) parameters["Data końcowa"].value;
            Random random = new Random();

            List<ConversionHistory> res = new List<ConversionHistory>(customDatabaseContext.conversionHistoryList);

            Thread.Sleep(random.Next(3000, 5000));

            if (!conversionName.isEmpty())
                res = res.Where(x => x.converterName.Contains(conversionName.toPrimitiveValue())).ToList();

            if (!fromDate.isEmpty())
                res = res.Where(x => x.createdAt >= fromDate).ToList();

            if (!toDate.isEmpty())
                res = res.Where(x => x.createdAt <= toDate).ToList();

            return res;
        }
    }
}
