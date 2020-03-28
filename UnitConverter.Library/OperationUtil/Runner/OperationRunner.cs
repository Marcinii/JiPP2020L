using UnitConverter.Library.OperationUtil.Repository;

namespace UnitConverter.Library.OperationUtil.Runner
{

    /// <summary>
    /// Klasa abstrakcyjna, która zawiera zestaw pól i metod do uruchamiania operacji
    /// </summary>
    /// <param name="operationRepository">Repozytorium, z którego chcemy uruchomić operację</param>
    /// <typeparam name="T">Typ elementu przechowywanego w repozytorium</typeparam>
    /// <see cref="Operation"/>
    /// <see cref="OperationRepository{T}"/>
    public abstract class OperationRunner<T> where T : Operation
    {
        public OperationRepository<T> operationRepository { get; private set; }

        protected OperationRunner(OperationRepository<T> operationRepository)
        {
            this.operationRepository = operationRepository;
        }


        /// <summary>
        /// Metoda abstrakcyjna, która zawierać będzie procedury do wywołania operacji
        /// </summary>
        public abstract void run();
    }
}
