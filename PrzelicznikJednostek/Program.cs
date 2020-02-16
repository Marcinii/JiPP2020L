using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzelicznikJednostek
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wybierz jednostki: \n");
            Console.WriteLine("1 - Temperatura - C -> F \n" +
                "2 - Temperatura - F -> C \n" +
                "3 - Dlugosc - km -> mile \n" +
                "4 - Dlugosc - mile -> km \n" +
                "5 - Waga - kg -> funty \n" +
                "6 - Waga - funty -> kg \n");

            string wybor;

            wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":
                    
                    break;
                case "2":

                    break;

                case "3":

                    break;
                case "4":

                    break;

                case "5":

                    break;

                case "6":

                    break;
            }
        }
    }
}
