using UnitConverter.Library.TaskUtil;
using UnitConverter.Library.TypeUtil;

namespace UnitConverter.Library.OperationUtil
{

    /// <summary>
    /// Klasa abstrakcyjna reprezentującą zesta pól do wykonywania operacji
    /// 
    /// <param name="id">Numer operacji</param>
    /// <param name="name">Nazwa wykonywanej operacji</param>
    /// <param name="task">
    ///     Pole przechowującę definicji funckji, która będzie się wykonywać w momencie wywoływania operacji
    /// </param>
    /// </summary>
    /// <see cref="CustomInteger"/>
    public abstract class Operation
    {
        public CustomInteger id { get; }
        public string name { get; }
        public IRunnable task { get; protected set; }

        protected Operation(CustomInteger id, string name, IRunnable task)
        {
            this.id = id;
            this.name = name;
            this.task = task;
        }


        /// <summary>
        /// Metoda abstrakcyjna, która ma za zadanie uruchamiać operację
        /// </summary>
        public abstract void run();


        /// <summary>
        /// Metoda abstrakcyjna, która dodaje funkcje uruchamiające się przed uruchomieniem zadania <see cref="task"/>
        /// </summary>
        /// <param name="taskBeforeRunFunction">
        ///     Implementacja funckji, która będzie się uruchamiać przed wykonaniem zadania
        /// </param>
        public abstract void beforeRun(TaskRunFunction taskBeforeRunFunction);


        /// <summary>
        /// Metoda abstrakcyjna, która dodaje funkcje uruchamiające się po uruchomieniem zadania <see cref="task"/>
        /// </summary>
        /// <param name="taskAfterRunFunction">
        ///     Implementacja funckji, która będzie się uruchamiać po wykonaniem zadania
        /// </param>
        public abstract void afterRun(TaskRunFunction taskAfterRunFunction);
    }
}
