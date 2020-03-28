using UnitConverter.Library.TypeUtil.TypeException;
using UnitConverter.Library.Validator;

namespace UnitConverter.Library.TypeUtil
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="ICustomType" />, która posiada zestaw
    /// podstawowych pól i metod, które będą potrzebne do zarządzania wartością naszego typu danych
    /// </summary>
    /// <param name="validationRegex">
    ///     Wyrażenie regularne, które posłuży jako szablon podczas wprowadzania wartości.
    ///     Posłuży ona do sprawdzenia, czy wprowadzona wartość jest prawidłowa
    /// </param>
    /// <param name="typeParser">
    ///     Obiekt, które posłuży do przetworzenia wprowadzonego ciągu znaków na nasz typ
    /// </param>
    /// <param name="validator">Obiekt, służący do walidacji wprowdzonego ciągu znaków</param>
    /// <param name="exception">
    ///     Pole przechowujące instancję wyjątku, które będzie rzutowane w przypadku niepowodzenia walidacji
    /// </param>
    /// <param name="value">Przechowywana wartość</param>
    /// <typeparam name="T">Dowolny typ danych</typeparam>
    public abstract class CustomObject<T> : ICustomType
    {
        protected abstract string validationRegex { get; }
        protected CustomTypeValueParser typeParser { get; }
        protected CustomTypeValidator validator { get; }
        protected abstract CustomTypeException exception { get; }
        internal T value { get; set; }


        protected CustomObject(T value)
        {
            this.value = value;
            this.validator = new CustomTypeValidator(validationRegex);
            this.typeParser = new CustomTypeValueParser(this, validator, exception);
        }

        public override string ToString() => $"{value}";

        public ICustomType fromString(string input)
        {
            if(!validator.validate(input)) throw exception;

            this.value = this.parseValue(input);
            return this;
        }



        /// <summary>
        /// Metoda abstrakcyjna, która ma posłużyć do przekonwertowania ciągu znaków na typt <see cref="T"/>
        /// </summary>
        /// <param name="input">Wprowadzony cią znaków</param>
        /// <returns>Zwraca obiekt z przekonwertowaną wartość</returns>
        protected abstract T parseValue(string input);



        /// <summary>
        /// Metoda wyciąga wartość pola <see cref="value"/> i zwraca jego wartość
        /// </summary>
        /// <returns>Zwraca wartość parametru <see cref="value" /></returns>
        public T toPrimitiveValue() => value;
    }
}
