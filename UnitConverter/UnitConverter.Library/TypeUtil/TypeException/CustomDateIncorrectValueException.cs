using UnitConverter.Library.TypeUtil.DateTimeType;

namespace UnitConverter.Library.TypeUtil.TypeException
{
    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="CustomTypeIncorrectValueException"/>,
    /// która rzucana jest w momencie, gdy dojdzie do nieprawidłowego utworzenia
    /// instancji typu <see cref="CustomDate"/>
    /// </summary>
    /// <see cref="CustomTypeIncorrectValueException"/>
    /// <see cref="CustomDate"/>
    public class CustomDateIncorrectValueException : CustomTypeIncorrectValueException
    {
        public CustomDateIncorrectValueException() 
            : base("Wprowadzona data jest nieprawidłowa. Data musi pasować do formatu yyyy-mm-dd") {}
    }
}
