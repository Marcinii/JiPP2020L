using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitconverter.logic
{
    public class parse
    {
        public static decimal convert_string_to_decimal(string variable)
        {
            decimal converted_variable;
            try
            {
                converted_variable = decimal.Parse(variable);
            }
            catch (FormatException)
            {
                converted_variable = 0;
                Console.WriteLine($"Nieprawidłowa dana wejsciowa: " + converted_variable);
            }
            return converted_variable;
        }
        public static int convert_string_to_int(string variable)
        {
            int converted_variable;
            try
            {
                converted_variable = int.Parse(variable);
            }
            catch (FormatException)
            {
                converted_variable = 0;
                Console.WriteLine($"Nieprawidłowa dana wejsciowa: " + converted_variable);
            }
            return converted_variable;
        }
    }
}
