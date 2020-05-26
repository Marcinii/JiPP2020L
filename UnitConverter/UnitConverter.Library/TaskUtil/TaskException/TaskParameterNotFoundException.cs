using System;

namespace UnitConverter.Library.TaskUtil.TaskException
{
    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="Exception"/>, która będzie rzucana w momencie,
    /// gdy próbujemy znaleść parametr w liście parametrów według nazwy, który w danej
    /// liscie nie istnieje
    /// </summary>
    public class TaskParameterNotFoundException : Exception
    {
        public TaskParameterNotFoundException(string name)
            : base(string.Format("Parametr o identyfikatorze \'{0}\' nie istnieje", name)) {}
    }
}
