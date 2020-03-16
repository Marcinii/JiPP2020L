using System.Collections.Generic;
using System.Windows.Controls.Primitives;

namespace UnitConverterApp.Util
{
    /// <summary>
    /// Interfejs służący do tworzenia klas zawierających zstaw metód do zarządzania odpowiednimi kontrolkami
    /// </summary>
    /// <typeparam name="T">Klasa reprezentująca kontrolkę typu Selector</typeparam>
    /// <typeparam name="I">Klasa reprezentująca typ danych w kolekcji</typeparam>
    interface ISelectorUtils<T, I> where T : Selector
    {
        /// <summary>
        /// Metoda, która ma za zadanie inicjalzację kontrolek
        /// </summary>
        /// <param name="selector">kontrolka, do której elementy będą wstawione</param>
        /// <param name="list">Lista z elementami do wstawienia</param>
        void initialize(T selector, List<I> list);
    }
}
