﻿using System;
using System.Collections.Generic;

namespace KonwerterJednostek
{
    public class TemperatureConverter: IConverter
    {
        public string Name => "Konwerter Temperatury";

        public List<string> Units => new List<string>()
        {
            "C",
            "F"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            if (unitFrom.ToUpperInvariant() == Units[0] && unitTo.ToUpperInvariant() == Units[1])
            {
                value *= (decimal) 1.8;
                value += 32;
                return value;
            }
            else if (unitFrom.ToUpperInvariant() == Units[1] && unitTo.ToUpperInvariant() == Units[0])
            {
                value -= 32;
                value /= (decimal) 1.8;
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
