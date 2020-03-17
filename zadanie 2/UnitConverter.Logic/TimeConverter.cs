using System.Collections.Generic;

namespace przelicznik
{


    public class TimeConverter : IConverter
    {
        decimal wynik;
        public string Name => "Czas";
        public List<string> Units => new List<string>()
        {
            "S",
            "Min ",
            "H"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            switch (unitFrom)
            {
                case "S":
                    if (unitTo == "H")
                    {
                        wynik = valueToConvert / 3600;
                    }
                    if (unitTo == "Min")
                    {
                        wynik = valueToConvert / 60;
                    }
                    break;
                case "H":
                    if (unitTo == "Min")
                    {
                        wynik = valueToConvert / 60;
                    }
                    if (unitTo == "S")
                    {
                        wynik = valueToConvert * 3600;
                    }
                    break;
                case "Min":
                    if (unitTo == "S")
                    {
                        wynik = valueToConvert * 60;
                    }
                    if (unitTo == "H")
                    {
                        wynik = valueToConvert / 60;
                    }
                    break;
            }

            return wynik;
        }

        }
    }