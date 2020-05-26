namespace UnitConverter.Library.Validator
{
    /// <summary>
    /// Interfejs służący do tworzenia klas odpowiedzialnych za wprowadzane dane wejściowe
    /// </summary>
    /// <typeparam name="T">Dowolny wejściowy typ parametru, którego chcemy zwalidować</typeparam>
    public interface IValidator<T>
    {
        /// <summary>
        /// Metoda walidująca wprowadzone dane
        /// </summary>
        /// <param name="input">Wartość wejściowa, którą chcemy poddać walidacji</param>
        /// <returns>Zwraca {true}, jeśli wartość wejściowa spełni wymagania, lub {false} w przeciwnym przypadku</returns>
        bool validate(T input);
    }
}
