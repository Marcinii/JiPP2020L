namespace UnitConverter.Library.Converter
{
    /// <summary>
    /// Interfejs służący do utworzenia podstawowej klasy do konwertowania jednostek miar.
    /// </summary>
    public interface IConverter<T>
    {
        /// <summary>
        /// Metoda konwertująca liczby zgodnie z wybranymi jednostkami
        /// </summary>
        /// <returns>Zwraca wartość liczby skonwertowanej na inną jednostkę</returns>
        T convert();

        /// <summary>
        /// Wyświetla w konsoli wynik konwersji
        /// </summary>
        void print();
    }
}
