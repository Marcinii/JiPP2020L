using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{

class Program_Konw
    {
        static void Main(string[] args)
        {

            int wybor = 0;
            double dane = 0;
            Temperatura_Konw T1 = new Temperatura_Konw();
            Odleglosc_Konw O1 = new Odleglosc_Konw();
            Masa_Konw M1 = new Masa_Konw();

            while (wybor != 8)
            {
                Console.WriteLine
                ("Wybierz rodzaj konwersji: \n " +
                "1) Celsjusz na Fahrenheit \n " +
                "2) Fahrenheit na Celsjusz \n " +
                "3) Kilometry na Mile \n " +
                "4) Mile na Kilometry \n " +
                "5) Funty na Kilogramy \n " +
                "6) Kilogramy na Funty \n " +
                "7) EXIT");

                wybor = int.Parse(Console.ReadLine());

                if (wybor == 7) { break; }

                Console.WriteLine("Podaj dane: ");

                dane = int.Parse(Console.ReadLine());

                switch (wybor)
                {
                    case 1:
                        Console.WriteLine(T1.Temperatura(dane, 0));
                        break;
                    case 2:
                        Console.WriteLine(T1.Temperatura(0, dane));
                        break;

                    case 3:
                        Console.WriteLine(O1.Odleglosc(dane, 0));
                        break;
                    case 4:
                        Console.WriteLine(O1.Odleglosc(0, dane));
                        break;

                    case 5:
                        Console.WriteLine(M1.Masa(0, dane));
                        break;
                    case 6:
                        Console.WriteLine(M1.Masa(dane, 0));
                        break;

                    default:
                        Console.WriteLine("Podaj wartosc z zakresu 1-7");
                        break;
                }
                Console.WriteLine("");
            }

        }
    }
}
