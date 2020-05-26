namespace UnitConverter.Library.OperationUtil.Runner
{

    /// <summary>
    /// Interfejs, który zawiera metodę do uruchamiania operacji
    /// </summary>
    /// <see cref="Operation"/>
    public interface IOperationRunner
    {
        /// <summary>
        /// Metoda abstrakcyjna, która zawierać będzie procedury do wywołania operacji
        /// </summary>
        /// <see cref="Operation"/>
        void run(Operation operation);
    }
}
