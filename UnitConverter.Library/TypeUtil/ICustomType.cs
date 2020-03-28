namespace UnitConverter.Library.TypeUtil
{
    /// <summary>
    /// Interfejs, który reprezentuje nasz typ danych.
    /// </summary>
    public interface ICustomType {

        /// <summary>
        /// Metoda, która konwertuje wprowadzony ciąg znaków na nasz typ
        /// </summary>
        /// <param name="input">Wprowadzony ciąg znaków</param>
        /// <returns>Zwraca w obiekt z podaną skonwertowaną wartością</returns>
        /// <exception cref="CustomTypeException">
        ///     Rzucany jest w momencie, gdy dojdzie do niepowdzenia walidacji danych
        /// </exception>
        ICustomType fromString(string input);



        /// <summary>
        /// Metoda, która konwertuje wartość jako ciąg znaków
        /// </summary>
        /// <returns>Zwraca wartość jako iąg znaków</returns>
        string ToString();
    }
}
