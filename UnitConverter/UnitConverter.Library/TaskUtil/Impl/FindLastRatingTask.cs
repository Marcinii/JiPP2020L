using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnitConverter.Library.History;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.RatingUtil;

namespace UnitConverter.Library.TaskUtil.Impl
{
    /// <summary>
    /// Klasa dziedzicząca klasę abstrakcyjną <see cref="Task{T}"/>, która jest implementacją nowego zadania. Ma ona za zadanie wyszukać ostatnią ocenę wystawioną przez użytkownika aplikacji
    /// </summary>
    /// <param name="customDatabaseContext">
    ///     Pole potrzebne do wykonania operacji na bazie danych
    /// </param>
    /// <see cref="Task{T}"/>
    /// <see cref="Rating"/>
    /// <see cref="CustomDatabaseContext"/>
    public class FindLastRatingTask : Task<Rating>
    {
        private CustomDatabaseContext customDatabaseContext;

        public FindLastRatingTask(CustomDatabaseContext customDatabaseContext)
        {
            this.customDatabaseContext = customDatabaseContext;
        }

        protected override Rating apply(Operation operation)
        {
            List<Rating> res = customDatabaseContext.ratings.ToList();
            Random random = new Random();

            Thread.Sleep(random.Next(200, 500));

            if(res.OrderByDescending(x => x.createdAt).ToList().Count > 0)
            {
                return res.OrderByDescending(x => x.createdAt).ToList()[0];
            }
            else
            {
                return null;
            }
        }
    }
}
