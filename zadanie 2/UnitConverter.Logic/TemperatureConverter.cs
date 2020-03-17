using System.Collections.Generic;


namespace przelicznik
{
    public class TemperatureConverter : IConverter
    {
        decimal wynik;
        public string Name => "Temperatury";

        public List<string> Units => new List<string>()
        {
            "C",
            "F ",
            "K"
        };
        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            switch (unitFrom)
            {
                case "C":
                    if (unitTo == "F")
                    {
                        wynik = (valueToConvert*9/5)+32;
                    }
                    if (unitTo == "K")
                    {
                        wynik = valueToConvert +273.15m;
                    }
                    break;
                case "F":
                    if (unitTo == "C")
                    {
                        wynik = (valueToConvert - 32) * 5 / 9;
                    }
                    if (unitTo == "K")
                    {
                        wynik = (valueToConvert -32m)/1.8m +273.15m;
                    }
                    break;
                case "K":
                    if (unitTo == "C")
                    {
                        wynik = valueToConvert * 1000;
                    }
                    if (unitTo == "F")
                    {
                        wynik = (valueToConvert-273.15m) *1.8m+32;
                    }
                    break;
            }

            return wynik;
        }
     
    }
}
