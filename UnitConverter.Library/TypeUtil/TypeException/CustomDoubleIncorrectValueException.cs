namespace UnitConverter.Library.TypeUtil.TypeException
{
    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="CustomTypeIncorrectValueException"/>,
    /// która rzucana jest w momencie, gdy dojdzie do nieprawidłowego utworzenia
    /// instancji typu <see cref="CustomDouble"/>
    /// </summary>
    /// <see cref="CustomTypeIncorrectValueException"/>
    /// <see cref="CustomDouble"/>
    public class CustomDoubleIncorrectValueException : CustomTypeIncorrectValueException
    {
        public CustomDoubleIncorrectValueException() : base("Podana wartość nie jest poprawną liczbą zmiennoprzecinkową") { }
    }
}
