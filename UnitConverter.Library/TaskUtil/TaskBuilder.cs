using UnitConverter.Library.TaskUtil.Parameter;
using UnitConverter.Library.TypeUtil;

namespace UnitConverter.Library.TaskUtil
{
    /// <summary>
    /// Klasa służąca do utworzenia nowej instancji zadania.
    /// </summary>
    /// <param name="value">
    ///     Pole przechowujące obiekt, który będziemy budować
    /// </param>
    /// <see cref="ICustomType"/>
    public class TaskBuilder
    {
        private Task<ICustomType> value;


        /// <summary>
        /// Metoda, którą musimy wprowadzić instancję obiektu, które reprezentuje zadanie
        /// </summary>
        /// <param name="value">Instancja obieku, który posiada definicję zadania</param>
        /// <returns>Zwraca samego siebie</returns>
        /// <see cref="Task{T}"/>
        /// <see cref="ICustomType"/>
        public TaskBuilder instance(Task<ICustomType> value)
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
        public TaskBuilder parameters(params TaskParameter[] parameters)
        {
            foreach (TaskParameter parameter in parameters)
                value.addParameter(parameter);

            return this;
        }



        /// <summary>
        /// Metoda, która buduje obiekt i go zwraca
        /// </summary>
        /// <returns>Zbudowany obiekt</returns>
        /// <see cref="Task{T}"/>
        public Task<ICustomType> build() => this.value;
    }
}
