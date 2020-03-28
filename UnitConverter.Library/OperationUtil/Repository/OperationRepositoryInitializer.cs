namespace UnitConverter.Library.OperationUtil.Repository
{
    /// <summary>
    /// Klasa abstrakcyjna, która posiada zestaw metod do zainicjalizowania repozytorium z operacjami.
    /// 
    /// <param name="repository">Repozytorium, któe chcemy zainicjalizować</param>
    /// <typeparamref name="T">
    ///     Typ danych reprezentujący klasę repozytorium, które chcemy zainicjalizować.
    /// </typeparamref>
    /// <typeparamref name="O">
    ///     Typ danych reprezentujący klasę elementu danego repozytorium
    /// </typeparamref>
    /// </summary>
    /// <see cref="OperationRepository{T}"/>
    /// <see cref="Operation"/>
    public abstract class OperationRepositoryInitializer<T, O> where T : OperationRepository<O> where O : Operation
    {
        protected T repository { get; }

        protected OperationRepositoryInitializer(T repository)
        {
            this.repository = repository;
        }


        /// <summary>
        /// Metoda, w której inicjalizujemy repozytorium
        /// </summary>
        public abstract void initializeRepository();
    }
}
