using System.Text.RegularExpressions;

namespace UnitConverter.Library.Validator
{
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
