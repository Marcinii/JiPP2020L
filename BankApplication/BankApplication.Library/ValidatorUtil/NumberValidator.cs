using System.Text.RegularExpressions;

namespace BankApplication.Library.ValidatorUtil
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="IValidator"/>, która sprawdza, czy wprowadzona wartość jest
    /// wartością liczbową.
    /// </summary>
    /// <see cref="IValidator"/>
    public class NumberValidator : IValidator
    {
        public bool validate(string input) => Regex.IsMatch(input, @"^-?[0-9]+((\.|\,)[0-9]+)?$");
    }
}
