namespace UnitConverter.Library.OperationUtil.Repository
{
    /// <summary>
    /// Klasa inicjalizująca reppozytorium z konwerterami.
    /// </summary>
    public abstract class OperationRepositoryInitializer<T, O> where T : OperationRepository<O> where O : Operation
    {
        protected T repository { get; }

        protected OperationRepositoryInitializer(T repository)
        {
            this.repository = repository;
        }


        /// <summary>
        /// Inicjalizuje repozytorium z konwerterami. Każdy knwerter dostaje odpowiednie jednostki wraz ze wzorami konwertującymi
        /// </summary>
        /// <param name="operationRepository"></param>
        public abstract void initializeRepository();
    }
}
