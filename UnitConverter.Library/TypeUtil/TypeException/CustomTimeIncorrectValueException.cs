using UnitConverter.Library.TypeUtil.DateTimeType;

namespace UnitConverter.Library.TypeUtil.TypeException
{
    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="CustomTypeIncorrectValueException"/>,
    /// która rzucana jest w momencie, gdy dojdzie do nieprawidłowego utworzenia
    /// instancji typu <see cref="CustomTime"/>
    /// </summary>
    /// <see cref="CustomTypeIncorrectValueException"/>
    /// <see cref="CustomTime"/>
    public class CustomTimeIncorrectValueException : CustomTypeIncorrectValueException
    {
        public CustomTimeIncorrectValueException() : base("Wprowadzona godzina jest nieprawidłowa") {}
    }
}
