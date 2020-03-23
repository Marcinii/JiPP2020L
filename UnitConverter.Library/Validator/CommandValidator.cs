namespace UnitConverter.Library.Validator
{
 
    /// <summary>
    /// Klasa implementująca interfejs {IConverter}, służąca do walidacji wprowadzonej numeru komendy
    /// <see cref="IValidator{T}"/>
    /// </summary>
    public class CommandValidator : IValidator<int>, IValidatorMessagable
    {

        public int unitCount { get; private set; }

        public CommandValidator(int unitCount)
        {
            this.unitCount = unitCount;
        }



        public string getMessage()
        {
            return "Nie rozpoznano komendy. Wprowadź poprawny numer komendy";
        }

        public bool validate(int input)
        {
            return input < 0 || input > this.unitCount;
        }
    }
}
