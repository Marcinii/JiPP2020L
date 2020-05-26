using UnitConverter.Library.TypeUtil.TypeException;
using UnitConverter.Library.Validator;

namespace UnitConverter.Library.TypeUtil
{
    /// <summary>
    /// Klasa, która ma za zadanie przetworzenie ciągu znaków na nasz typ danych
    /// </summary>
    /// <param name="customObject">Obiekt, na który zostanie skonwertowany ciąg znaków</param>
    /// <param name="exception">Wyjątek rzutowanty w momenciee niepowodzenia</param>
    /// <param name="validator">Obiekt, który posłuży do walidaji ciągu znaków</param>
    /// <see cref="ICustomType"/>
    /// <see cref="CustomTypeException"/>
    /// <see cref="CustomTypeValidator"/>
    public class CustomTypeValueParser
    {
        private ICustomType customObject;
        private CustomTypeException exception;
        private CustomTypeValidator validator;

        public CustomTypeValueParser(ICustomType customObject, CustomTypeValidator validator, CustomTypeException exception)
        {
            this.customObject = customObject;
            this.validator = validator;
            this.exception = exception;
        }


        /// <summary>
        /// Metoda przetwarzająca ciąg znaków do naszego typu danych
        /// </summary>
        /// <param name="value">Wprowdzony ciąg znaków</param>
        /// <returns>Zwraca obiekt z wartością, która została przetworzona z ciągu znaków</returns>
        /// <exception cref="CustomTypeException">
        ///     Rzutuje się w momencie, walidacja nie powiedzie się
        /// </exception>
        public ICustomType parse(string value)
        {
            if(!validator.validate(value))
                throw exception;

            return customObject.fromString(value);
        }
    }
}
