namespace UnitConverter.Library.Core
{
    /// <summary>
    /// Interfejs służący do utworzenia podstawowej klasy do konwertowania jednostek miar.
    /// </summary>
    public interface IConverter
    {
        /// <summary>
        /// Metoda konwertująca liczby zgodnie z wybranymi jednostkami
        /// </summary>
        /// <returns>Zwraca wartość liczby skonwertowanej na inną jednostkę</returns>
        double convert();

        /// <summary>
        /// Wyświetla w konsoli wynik konwersji
        /// </summary>
        void print();
    }
}
