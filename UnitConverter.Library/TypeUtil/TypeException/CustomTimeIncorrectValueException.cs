namespace UnitConverter.Library.TypeUtil.TypeException
{
    public class CustomTimeIncorrectValueException : CustomTypeIncorrectValueException
    {
        public CustomTimeIncorrectValueException() : base("Wprowadzona godzina jest nieprawidłowa") {}
    }
}
