using UnitConverter.Library.TypeUtil.Number;

namespace UnitConverter.Library.TypeUtil.TypeException
{
    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="CustomTypeIncorrectValueException"/>,
    /// która rzucana jest w momencie, gdy dojdzie do nieprawidłowego utworzenia
    /// instancji typu <see cref="CustomInteger"/>
    /// </summary>
    /// <see cref="CustomTypeIncorrectValueException"/>
    /// <see cref="CustomInteger"/>
    public class CustomIntegerIncorrectValueException : CustomTypeException
    {
        public CustomIntegerIncorrectValueException() : base("Podana wartość nie jest poprawną liczbą całkowitą") {}
    }
}
