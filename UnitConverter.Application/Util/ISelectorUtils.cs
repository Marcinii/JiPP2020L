using System.Collections.Generic;
using System.Windows.Controls.Primitives;

namespace UnitConverter.Application.Util
{
    /// <summary>
    /// Klasa abstrakcyjna służąca do tworzenia klas zawierających zstaw metód do zarządzania odpowiednimi kontrolkami
    /// </summary>
    /// <typeparam name="T">Klasa reprezentująca kontrolkę typu Selector</typeparam>
    /// <typeparam name="I">Klasa reprezentująca typ danych w kolekcji</typeparam>
    public abstract class ISelectorUtils<T, I> where T : Selector
    {
        protected T selector { get; private set; }

        protected ISelectorUtils(T selector)
        {
            this.selector = selector;
        }



        /// <summary>
        /// Metoda, która ma za zadanie inicjalizację kontrolek
        /// </summary>
        /// <param name="selector">kontrolka, do której elementy będą wstawione</param>
        /// <param name="list">Lista z elementami do wstawienia</param>
        public abstract void initialize(List<I> list);



        /// <summary>
        /// Metoda zwracająca zaznaczoną wartość jako typ, który jest przechowywany w kontrolce
        /// </summary>
        /// <returns>Zwraca aktualnie zaznaczoną wartość i konwertuje ją na odpowiedni typ</returns>
        public abstract I getSelectedContent();
    }
}
