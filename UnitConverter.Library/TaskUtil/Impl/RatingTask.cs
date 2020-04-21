using UnitConverter.Library.History;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.RatingUtil;
using UnitConverter.Library.TypeUtil.Number;
using UnitConverter.Library.TypeUtil.Void;

namespace UnitConverter.Library.TaskUtil.Impl
{
    /// <summary>
    /// Klasa dziedzicząca klasę abstrakcyjną <see cref="Task{T}"/>, która jest implementacją nowego zadania. Ma ona za zadanie wstawienie do bazy danych nowej oceny.
    /// </summary>
    /// <param name="customDatabaseContext">
    ///     Pole potrzebne do wykonania operacji na bazie danych
    /// </param>
    /// <see cref="Task{T}"/>
    /// <see cref="CustomVoid"/>
    /// <see cref="CustomDatabaseContext"/>
    public class RatingTask : Task<CustomVoid>
    {
        private CustomDatabaseContext customDatabaseContext;

        public RatingTask(CustomDatabaseContext customDatabaseContext)
        {
            this.customDatabaseContext = customDatabaseContext;
        }



        protected override CustomVoid apply(Operation operation) => new CustomVoid(() =>
        {
            Rating rating = new Rating(
                ((CustomInteger)parameters["Ocena"].value).toPrimitiveValue()
            );

            customDatabaseContext.ratings.Add(rating);
            customDatabaseContext.SaveChanges();
        });
    }
}
