using System.Text.RegularExpressions;

namespace BankApplication.Library.ValidatorUtil
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="IValidator"/>, która ma za zadanie walidację wprowadzonego numeru konta bankowego
    /// </summary>
    /// <see cref="IValidator"/>
    public class AccountNumberValidator : IValidator
    {
        public bool validate(string input) => Regex.IsMatch(input, @"^[0-9]{26}$");
    }
}
