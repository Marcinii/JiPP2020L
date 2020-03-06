namespace UnitConverter.Core
{
    /// <summary>
    /// Interfejs służący do tworzenia klas odpowiedzialnych za wprowadzane dane wejściowe
    /// </summary>
    /// <typeparam name="T">Dowolny wejściowy typ parametru, którego chcemy zwalidować</typeparam>
    interface IValidator<T>
    {
        /// <summary>
        /// Metoda walidująca wprowadzone dane
        /// </summary>
        /// <param name="input">Wartość wejściowa, którą chcemy poddać walidacji</param>
        /// <returns>Zwraca {true}, jeśli wartość wejściowa spełni wymagania, lub {false} w przeciwnym przypadku</returns>
        public bool validate(T input);

        /// <summary>
        /// Zwraca wiadomość w momencie, gdy doszło do niepowodzenia w trakcie walidacji danych wejściowych
        /// </summary>
        /// <returns></returns>
        public string getMessage();
    }
}
