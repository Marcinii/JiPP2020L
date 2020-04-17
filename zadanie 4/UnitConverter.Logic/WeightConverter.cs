using System.Collections.Generic;

namespace przelicznik
{
    public class WeightConverter : IConverter
    {

        public List<string> Units => new List<string>()
        {
            "kg",
            "funty",
            "tony"
        };
        decimal wynik;
        public string Name => "wagi";
        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            switch (unitFrom)
            {
                case "kg":
                    if (unitTo == "funty")
                    {
                        wynik = valueToConvert * 2.20462262m;
                    }
                    if (unitTo == "tony")
                    {
                        wynik = valueToConvert / 1000;
                    }
                    break;
                case "tony":
                    if (unitTo == "kg")
                    {
                        wynik = valueToConvert * 1000;
                    }
                    if (unitTo == "funty")
                    {
                        wynik = valueToConvert * 2204.62262m;
                    }
                    break;
                case "funty":
                    if (unitTo == "tony")
                    {
                        wynik = valueToConvert * 0.00045359237m;
                    }
                    if (unitTo == "kg")
                    {
                        wynik = valueToConvert * 0.45359237m;
                    }
                    break;
            }

            return wynik;
        }
        
    }
}
