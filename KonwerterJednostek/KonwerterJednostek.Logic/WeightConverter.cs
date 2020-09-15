using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    public class WeightConverter: IConverter
    {
        public string Name => "Masy";

        public List<string> Units => new List<string>()
        {
            "KG",
            "LB"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            if (unitFrom.ToUpperInvariant() == Units[0])
            {
                value *= (decimal) 2.204625;
                return value;
            }
            else if (unitFrom.ToUpperInvariant() == Units[1])
            {
                value /= (decimal) 2.204625;
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
