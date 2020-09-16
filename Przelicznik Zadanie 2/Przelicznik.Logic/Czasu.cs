using System.Collections.Generic;

namespace Przelicznik.Logic
{
    public class Czasu : PrzelicznikI
    {
        public string Name => "Przelicznik czasu";

        public List<string> jednostka => new List<string>
        {
        };

        public double przelicz(string jednostka1, string jednostka2, double liczba)
        {
            return 0;
        }

        public string przeliczCzas(string czas)
        {
            if (czas.Split(' ').Length == 2)
            {
                var czesci = czas.Split(' ');
                if (czesci[1] == "am")
                {
                    return czesci[0];
                }
                else
                {
                    return (int.Parse(czesci[0]) + 12).ToString();
                }
            }
            else
            {
                if (int.Parse(czas) > 12)
                {
                    return (int.Parse(czas) - 12).ToString() + " pm";
                }
                else
                {
                    return czas + " am";
                }
            }
        }
    }
}