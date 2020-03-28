namespace UnitConverter.Library.TypeUtil.TypeException
{
    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="CustomTypeException"/>,
    /// która rzucana jest w momencie, gdy dojdzie do nieprawidłowego utworzenia
    /// instancji mojego własngo typu
    /// </summary>
    /// <see cref="CustomTypeException"/>
    public class CreateInstanceCustomTypeException : CustomTypeException
    {
        public CreateInstanceCustomTypeException(string message) : base(message) {}
    }
}
