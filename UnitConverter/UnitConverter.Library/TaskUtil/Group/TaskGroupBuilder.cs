using UnitConverter.Library.TaskUtil.Parameter;

namespace UnitConverter.Library.TaskUtil.Group
{
    /// <summary>
    /// Klasa, która posiada zestaw metod niezbędnych do zbudowania nowego grupowego zadania
    /// </summary>
    /// <param name="value">Pole, które przechowuję instancję gotową do zbudowania</param>
    /// <see cref="TaskGroup"/>
    public class TaskGroupBuilder
    {
        private TaskGroup value;




        public TaskGroupBuilder(TaskGroup value)
        {
            this.value = value;
        }





        /// <summary>
        /// Metoda, która ma za zadanie dodawanie nowych zadań do grupy
        /// </summary>
        /// <param name="tasks">Lista zadań do dodania</param>
        /// <returns>Zwraca samą siebie</returns>
        /// <see cref="IRunnable"/>
        public TaskGroupBuilder tasks(params IRunnable[] tasks)
        {
            this.value.addTasks(tasks);
            return this;
        }



        /// <summary>
        /// Metoda, która dodaje nowe parametry do zadania.
        /// </summary>
        /// <param name="parameters">Lista parametrów do dodania</param>
        /// <returns>Zwraca samą siebie</returns>
        /// <see cref="TaskParameter"/>
        public TaskGroupBuilder parameters(params TaskParameter[] parameters)
        {
            foreach (TaskParameter parameter in parameters)
                value.addParameter(parameter);

            return this;
        }



        /// <summary>
        /// Metoda, która buduje i zwraca zbudowany obiekt
        /// </summary>
        /// <returns>Obiekt typu <see cref="IRunnable"/></returns>
        /// <see cref="IRunnable"/>
        public IRunnable build() => value;
    }
}
