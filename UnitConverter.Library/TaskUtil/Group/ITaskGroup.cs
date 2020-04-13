using System.Collections.Generic;
using UnitConverter.Library.TaskUtil.Parameter;

namespace UnitConverter.Library.TaskUtil.Group
{
    /// <summary>
    /// Interfejs, który posiada zestaw metod do utworzenia grupy zaddań
    /// </summary>
    public interface ITaskGroup
    {
        /// <summary>
        /// Metoda, która ma za zadanie zwrócenie listy zadań do wykonania
        /// </summary>
        /// <returns>lista obiektów, przechowujące zadania</returns>
        /// <see cref="IRunnable"/>
        List<IRunnable> getAllTasks();



        /// <summary>
        /// Metoda dodaje zadania do listy
        /// </summary>
        /// <param name="tasks">Lista z zadaniami do dodania</param>
        /// <see cref="IRunnable"/>
        void addTasks(params IRunnable[] tasks);



        /// <summary>
        /// Metoda dodająca nowy parametr do zadania
        /// </summary>
        /// <param name="parameter">Parametr do dodania</param>
        /// <see cref="TaskParameter"/>
        void addParameter(TaskParameter parameter);
    }
}
