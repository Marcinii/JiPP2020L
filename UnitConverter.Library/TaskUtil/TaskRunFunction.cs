namespace UnitConverter.Library.TaskUtil
{
    /// <summary>
    /// Interfejs, który posłuży jako funkcja, która będzie wykonywana w odpowiednich momentach
    /// wywoływania zadania. To pozwoli nam na manimupacje zadaniem a także wykonaniem innych
    /// pobocznych funkcji, które mogą odpowiednio przygotować środowisko do wykonania zadania
    /// </summary>
    public interface TaskRunFunction
    {

        /// <summary>
        /// Metoda, w której defniujemy instrukcje, które będą się wykonywć
        /// w odpowiednim momencie wykonywania zadania
        /// </summary>
        /// <param name="runnable">Wywoływane zadanie</param>
        void apply(IRunnable runnable);
    }
}
