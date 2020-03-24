using System.Collections.Generic;

namespace przelicznik
{


    public class ClockConverter : IConverter
    {
        decimal wynik;
        public string Name => "Czas24";
        public List<string> Units => new List<string>()
        {
            "Zegar 24H",
            "Zegar 12H ",
           
        };
        public string choose;
        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {


            if (valueToConvert < 12)
            {
                wynik = valueToConvert;
            }
            if (valueToConvert >= 12)
            {
                wynik = valueToConvert - 12;
            }
           





            return wynik;
        }

    }
}