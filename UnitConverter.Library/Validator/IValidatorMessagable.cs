namespace UnitConverter.Library.Validator
{
    public interface IValidatorMessagable
    {
        /// <summary>
        /// Zwraca wiadomość w momencie, gdy doszło do niepowodzenia w trakcie walidacji danych wejściowych
        /// </summary>
        /// <returns></returns>
        string getMessage();
    }
}
