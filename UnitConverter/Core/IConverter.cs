using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Core
{
    /// <summary>
    /// Interfejs służący do utworzenia podstawowej klasy do konwertowania jednostek miar.
    /// </summary>
    interface IConverter
    {
        /// <summary>
        /// Metoda konwertująca liczby zgodnie z wybranymi jednostkami
        /// </summary>
        /// <returns>Zwraca wartość liczby skonwertowanej na inną jednostkę</returns>
        public double convert();

        /// <summary>
        /// Wyświetla w konsoli wynik konwersji
        /// </summary>
        public void print();
    }
}
