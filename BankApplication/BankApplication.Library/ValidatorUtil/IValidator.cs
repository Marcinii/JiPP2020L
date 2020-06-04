namespace BankApplication.Library.ValidatorUtil
{
    /// <summary>
    /// Interjs, który będziemy wykorzystywali do wykonywania podstawowych walidacji wartości
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Metoda ma za zadanie sprawdzić poprawność wprowadzonej wartości wejściowej
        /// </summary>
        /// <param name="input">Wartość wejściowa do sprawdzenia</param>
        /// <returns>
        ///     Zwraca true jeżeli wartość jest zgodna z wymaganiami.
        ///     W przeciwnym przypadku - false.
        /// </returns>
        bool validate(string input);
    }
}
