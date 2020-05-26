using System.Collections.Generic;
using UnitConverter.Library.TypeUtil.TypeException;

namespace UnitConverter.Library.TypeUtil
{
    /// <summary>
    /// Klasa dziedzicząca klasę abstrakcyjną <see cref="CustomObject{T}"/>, 
    /// która reprezentuje typ danych przechowjący ciąg znaków
    /// </summary>
    /// <see cref="CustomObject{T}"/>
    public class CustomString : CustomObject<string>
    {
        protected override string validationRegex => ".*";
        protected override CustomTypeException exception => new CustomTypeException("");

        public int Length
        {
            get => value.Length;
        }

        public CustomString() : base("") { }
        public CustomString(string value) : base(value) { }

        public static implicit operator CustomString(string value) => new CustomString(value);
        public static CustomString operator +(CustomString customString, string value) => new CustomString(customString.value + value);
        public static CustomString operator +(CustomString customString, char c) => new CustomString(customString.value + c);
        public static bool operator ==(CustomString string1, CustomString string2) => string1.value == string2.value;
        public static bool operator !=(CustomString string1, CustomString string2) => string1.value != string2.value;
        public static bool operator ==(string value, CustomString customString) => customString.value == value;
        public static bool operator !=(string value, CustomString customString) => customString.value != value;

        protected override string parseValue(string input) => input;

        public override bool isEmpty() => value == "";


        /// <summary>
        /// Metoda, która ma za zadanie zwrócić sformatowany ciąg znaków.
        /// Pozwoli to ułatwić tworzenie ciągów znaków, gdzie mamy do czynienia
        /// z wielokrotnym użyciem łączenia ciągów znaków
        /// </summary>
        /// <param name="value">
        ///     Pole przechowujące szablon ciągu znaków gotowy do przetworzenia
        /// </param>
        /// <param name="values">
        ///     Wartości obiektów, które będą wstawiane w ten ciąg
        /// </param>
        /// <returns>Sformatowany ciąg znaków</returns>
        public static CustomString format(CustomString value, params object[] values)
        {
            return new CustomString(string.Format(value.value, values));
        }



        public override bool Equals(object obj)
        {
            return obj is CustomString @string &&
                   validationRegex == @string.validationRegex &&
                   EqualityComparer<CustomTypeException>.Default.Equals(exception, @string.exception) &&
                   Length == @string.Length;
        }

        public override int GetHashCode()
        {
            int hashCode = 1432717168;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(validationRegex);
            hashCode = hashCode * -1521134295 + EqualityComparer<CustomTypeException>.Default.GetHashCode(exception);
            hashCode = hashCode * -1521134295 + Length.GetHashCode();
            return hashCode;
        }
    }
}
