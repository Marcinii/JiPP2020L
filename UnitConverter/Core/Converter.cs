using System;

namespace UnitConverter.Core
{

    /// <summary>
    /// Enumeracja służąca do rozróżnienia, na którą wartość chcemy skonwertować wprowadzoną wartość wejściową
    /// Każda wartość odpowiada odpowiedniej jednostce, na którą chcemy wartość skonwertować.
    /// Np. dla jednosteek temperatury:
    /// - FIRST będzie odpowiadać jednostka stopni Celsjusza,
    /// - SECOND będzie odpowiadać jednostka stopni Fahrenheitt'a
    /// </summary>
    enum ConvertTo
    {
        FIRST, SECOND
    }


    /// <summary>
    /// Podstawowa klasa abstrakcyjna przechowująca niezbędne dane do konwersji wartości werjściowych
    /// <param name="value">Wprowadzona wartość wejściowa</param>
    /// <param name="convertTo">
    ///     Wartość, która wskazuje, na którą wartość mamy przekonwertować parametr {value}
    /// </param>
    /// <param name="message">Wyświetlana wiadomość informująca o tym jaka jest wartość po konwersji</param>
    /// </summary>
    abstract class Converter
    {
        protected double value;
        protected ConvertTo convertTo;
        protected string message;

        protected Converter(double value, ConvertTo convertTo)
        {
            this.value = value;
            this.convertTo = convertTo;
            this.setMessage();
        }


        /// <summary>
        /// Metoda służąca do konwertowania wartości wejściowej.
        /// Jest ona abstrakcyjna, wobec czego wymagana jest jej implementacja w klasie, która będzie ją dziedziczyć
        /// </summary>
        /// <returns>Zwraca wartość liczby skonwertowanej na inną jednostkę</returns>
        protected abstract double convert();

        
        /// <summary>
        /// Metoda ustawia wyświetlaną wiadomość informująca o wartości skonwertowanej liczby.
        /// Jest ona abstrakcyjna wobec czego wymangana jest jej implementacja w klasie, która będzie ją dziedziczyć
        /// </summary>
        protected abstract void setMessage();


        /// <summary>
        /// Metoda wypisująca dane w konsoli
        /// </summary>
        public void print()
        {
            Console.WriteLine();
            Console.WriteLine("#----------------------------------------------------#");
            Console.WriteLine("# {0}", String.Format(this.message, value, convert()));
            Console.WriteLine("#----------------------------------------------------#");
        }
    }
}
