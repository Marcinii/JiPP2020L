using System.Collections.Generic;

namespace przelicznik
{

    public class LenghtConverter : IConverter
    {
        public string Name => "Długości";
        decimal wynik;
        public List<string> Units => new List<string>()
        {
            "mile",
            "kilometry",
            "metry"



        };
        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            switch (unitFrom)
            {
                case "mile":
                    if (unitTo == "kilometry")
                    {
                        wynik = valueToConvert * 1.609344m;
                    }
                    if (unitTo == "metry")
                    {
                        wynik = valueToConvert * 1609.344m;
                    }
                    break;
                case "metry":
                    if (unitTo == "kilometry")
                    {
                        wynik = valueToConvert / 1000;
                    }
                    if (unitTo == "mile")
                    {
                        wynik = valueToConvert * 0.000621371192m;
                    }
                    break;
                case "kilometry":
                    if (unitTo == "metry")
                    {
                        wynik = valueToConvert * 1000;
                    }
                    if (unitTo == "mile")
                    {
                        wynik = valueToConvert / 1.609344m;
                    }
                    break;
            }

            return wynik;
        }





    }

}



