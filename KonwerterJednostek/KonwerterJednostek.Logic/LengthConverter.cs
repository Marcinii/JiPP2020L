using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    public class LengthConverter: IConverter
    {
        public string Name => "Długości";

        public List<string> Units => new List<string>()
        {
            "KM",
            "MI",
            "M"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            if (unitFrom.ToUpperInvariant() == Units[0] && unitTo.ToUpperInvariant() == Units[1])
            {
                value *= (decimal) 0.62137;
                return value;
            }
            else if (unitFrom.ToUpperInvariant() == Units[1] && unitTo.ToUpperInvariant() == Units[0])
            {
                value /= (decimal) 0.62137;
                return value;
            }
            else if (unitFrom.ToUpperInvariant() == Units[2] && unitTo.ToUpperInvariant() == Units[0])
            {
                value /= 1000;
                return value;
            }
            else if (unitFrom.ToUpperInvariant() == Units[0] && unitTo.ToUpperInvariant() == Units[2])
            {
                value *= 1000;
                return value;
            }
            else
            {
                Console.WriteLine("Wprowadzono niepoprawną jednostkę, nastapi powrót do menu wyboru");
                return 0;
            }
        }
    }
}
