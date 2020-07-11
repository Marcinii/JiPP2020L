using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace UI.Rules
{
    public class CapacityValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(int.TryParse(value?.ToString(), NumberStyles.Any, null, out var checkedInt))
                return new ValidationResult(false, "Value has to be number.");

            if (checkedInt < 0)
                return new ValidationResult(false, "Capacity value can not be less than 0.");

            return ValidationResult.ValidResult;
        }
    }
}
