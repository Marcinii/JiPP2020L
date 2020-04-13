namespace UnitConverter.Library.TaskUtil.Parameter
{
    /// <summary>
    /// Enumeracja określająca poziom widoczności danego parametru
    /// </summary>
    public enum TaskParameterLevel
    {
        /// <summary>
        /// Wartość, która ustala, że dany parametr jest niewidoczny z poziomy interfejsu aplikacji.
        /// Taki parametr można wykorzystać z poziomu kodu w celu ustalenia wartości w tle
        /// </summary>
        HIDDEN,

        /// <summary>
        /// Wartość, która ustala, że parametr jest opcjonalny, czyli można go wprowadzić, ale nie ma żadnego przymusu
        /// Jeżeli nie zostanie wprowadzona żadna wartość - parametr ustawiany jest na wartość domyślną danego typu
        /// </summary>
        OPTIONAL,

        /// <summary>
        /// Wartość, która ustala, że parametr jest wymagany do wprowadzenia
        /// </summary>
        REQUIRED
    }
}
