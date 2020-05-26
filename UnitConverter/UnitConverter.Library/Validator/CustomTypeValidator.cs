using System.Text.RegularExpressions;

namespace UnitConverter.Library.Validator
{
    /// <summary>
    /// Klasa impllementującą inerfejs <see cref="IValidator{T}"/>,
    /// która sprawdza, czy wprowadzony ciąg znaków jest zgodny z wyrażeniem regularnym
    /// </summary>
    /// <param name="regex">Wyrażene regularne</param>
    public class CustomTypeValidator : IValidator<string>
    {
        private string regex;

        public CustomTypeValidator(string regex)
        {
            this.regex = regex;
        }

        public bool validate(string input)
        {
            return Regex.IsMatch(input, regex);
        }
    }
}
