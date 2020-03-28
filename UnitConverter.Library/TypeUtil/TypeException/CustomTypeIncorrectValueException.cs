namespace UnitConverter.Library.TypeUtil.TypeException
{

    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="CustomTypeException"/>, która jest rzutowana
    /// w momencie, gdy zostanie wprowadzona wartość nieobsługiwana przez dany mój typ danych
    /// </summary>
    /// <see cref="CustomTypeException"/>
    public class CustomTypeIncorrectValueException : CustomTypeException
    {
        public CustomTypeIncorrectValueException(string message) : base(message) {}
    }
}
