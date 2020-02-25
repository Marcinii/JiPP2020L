using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przelicznik_Jednostek
{
    class Program:operacje_1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Przeliczanie jednostek, pierwszy projekt.");
                int metoda = 0;
            operacje_1 pyt_dzialanie = new operacje_1();

            while (metoda != 4)

            {
                Console.WriteLine();
                Console.WriteLine("Prosze wybrac dzialanie: ");
                Console.WriteLine("Dla przeliczania stopni Celcjusz i Fahrenheita wybierz: '1' ");
                Console.WriteLine("Dla przeliczania odleglosci Kilometrow i MIL wybierz: '2' ");
                Console.WriteLine("Dla przeliczania wagi Kilogram i Funt wybierz: '3' ");
                Console.WriteLine("Jeżeli chcesz zakonczyc program wybeirz: '4'  ");
                Console.WriteLine();
                metoda = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (metoda)
                {
                    case 1: // przeliczanie celcjuszy i farenhtie

                        pyt_dzialanie.C_czy_F();

                        break;


                    case 2: // przeliczanie mil i km

                        pyt_dzialanie.KM_czy_M();

                        break;


                    case 3: // przeliczanie kg i funtów

                        pyt_dzialanie.KG_czy_LBS();

                        break;

                    case 4: // zamykanie pętli

                         metoda = 4;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Nie wybrano zadania!");
                        Console.WriteLine("Sprobuj jeszcze raz.");
                        Console.WriteLine();
                        break;
                }

            } 

        }
    }
}
