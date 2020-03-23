namespace UnitConverter.Library.TypeUtil.TypeException
{
    public class CustomDoubleIncorrectValueException : CustomTypeIncorrectValueException
    {
        public CustomDoubleIncorrectValueException() : base("Podana wartość nie jest poprawną liczbą zmiennoprzecinkową") { }
    }
}
