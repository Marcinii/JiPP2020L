using System;
using System.Collections.Generic;

namespace KonwerterJednostek
{
    public class PowerConverter: IConverter
    {
        public string Name => "Konwerter Mocy";

        public List<string> Units => new List<string>()
        {
            "HP",
            "BHP",
            "KW"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            if (unitFrom.ToUpperInvariant() == Units[0] && unitTo.ToUpperInvariant() == Units[1])
            {
                value /= (decimal)0.986320071;
                return value;
            }
            else if (unitFrom.ToUpperInvariant() == Units[0] && unitTo.ToUpperInvariant() == Units[2])
            {
                value *= (decimal)0.73549875;
                return value;
            }
            else if (unitFrom.ToUpperInvariant() == Units[1] && unitTo.ToUpperInvariant() == Units[0])
            {
                value *= (decimal)0.986320071;
                return value;
            }
            else if (unitFrom.ToUpperInvariant() == Units[1] && unitTo.ToUpperInvariant() == Units[2])
            {
                value *= (decimal)0.745699872;
                return value;
            }
            else if (unitFrom.ToUpperInvariant() == Units[2] && unitTo.ToUpperInvariant() == Units[0])
            {
                value /= (decimal)0.73549875;
                return value;
            }
            else if (unitFrom.ToUpperInvariant() == Units[2] && unitTo.ToUpperInvariant() == Units[1])
            {
                value /= (decimal)0.745699872;
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
