﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class TemperatureConverter: IConverter
    {
        public string Name => "Temperatury";

        public List<string> Units => new List<string>()
        {
            "C",
            "F",
            "K"
        };

        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            double wynik = 0;

            if( unitFrom == "C" && unitTo == "F")
            {
                wynik = ((9.0/5.0) * System.Convert.ToDouble(valueToConvert)) + 32.0;
            }

            else if (unitFrom == "F" && unitTo == "C")
            {
                wynik = 0.56 * (System.Convert.ToDouble(valueToConvert) - 32.0);
            }

            else if (unitFrom == "C" && unitTo == "K")
            {
                wynik = System.Convert.ToDouble(valueToConvert) + 273.15;
            }

            else if (unitFrom == "K" && unitTo == "C")
            {
                wynik = System.Convert.ToDouble(valueToConvert) - 273.15;
            }

            else if (unitFrom == "F" && unitTo == "K")
            {
                wynik = (System.Convert.ToDouble(valueToConvert) - 32.0) / 1.8;
            }

            else if (unitFrom == "K" && unitTo == "F")
            {
                wynik = (System.Convert.ToDouble(valueToConvert) - 273.15) * 1.8 + 32.0;
            }

            return System.Convert.ToString(wynik);
        }
    }
}