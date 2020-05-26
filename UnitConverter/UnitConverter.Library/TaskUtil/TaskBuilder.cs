using UnitConverter.Library.TaskUtil.Parameter;

namespace UnitConverter.Library.TaskUtil
{
    /// <summary>
    /// Klasa służąca do utworzenia nowej instancji zadania.
    /// </summary>
    /// <param name="value">
    ///     Pole przechowujące obiekt, który będziemy budować
    /// </param>
    /// <see cref="IRunnable"/>
    public class TaskBuilder
    {
        protected IRunnable value { get; set; }


        /// <summary>
        /// Metoda, którą musimy wprowadzić instancję obiektu, które reprezentuje zadanie
        /// </summary>
        /// <param name="value">Instancja obieku, który posiada definicję zadania</param>
        /// <returns>Zwraca samego siebie</returns>
        /// <see cref="IRunnable"/>
        public TaskBuilder instance(IRunnable value)
        {
            this.value = value;
            return this;
        }



        /// <summary>
        /// Metoda dodająca nowe parmetty do zadania
        /// </summary>
        /// <param name="value">Instancja obieku, który posiada definicję zadania</param>
        /// <returns>Zwraca samego siebie</returns>
        /// <see cref="TaskParameter"/>
        public virtual TaskBuilder parameters(params TaskParameter[] parameters)
        {
            foreach (TaskParameter parameter in parameters)
                value.addParameter(parameter);

            return this;
        }



        /// <summary>
        /// Metoda dodająca obiekt, który przechowuje instrukje, uruchamiające się przed właściwym wywołaniem zadania
        /// </summary>
        /// <param name="function">Instancja obiektu, która reprezentujące funkcję uruchamiającą się przed wywołaniem zadania</param>
        /// <returns></returns>
        public TaskBuilder beforeRun(TaskRunFunction function)
        {
            this.value.beforeRun(function);
            return this;
        }



        /// <summary>
        /// Metoda dodająca obiekt, który przechowuje instrukje, uruchamiające się po właściwym wywołaniu zadania
        /// </summary>
        /// <param name="function">Instancja obiektu, która reprezentujące funkcję uruchamiającą się po wywołaniu zadania</param>
        /// <returns></returns>
        public TaskBuilder afterRun(TaskRunFunction function)
        {
            this.value.afterRun(function);
            return this;
        }



        /// <summary>
        /// Metoda, która buduje obiekt i go zwraca
        /// </summary>
        /// <returns>Zbudowany obiekt</returns>
        /// <see cref="Task{T}"/>
        public virtual IRunnable build() => this.value;
    }
}
