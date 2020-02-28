using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1_S4
{
    class Program_Przelicznik:Operacja
    {
        static void Main(string[] args)
        {
            Console.WriteLine("KAL-PRZELICZNIK");
            int wybor = 0;
            Operacja operacja = new Operacja();

            while (wybor != 5)
            {
                Console.WriteLine("Wybierz operacje: ");
                Console.WriteLine("(1) Przelicznik temperatur Celcjusz / Farenheite");
                Console.WriteLine("(2) Przelicznik długośći Kilometry / Mile");
                Console.WriteLine("(3) Przelicznik mas Kilogramy / Funty");     
                Console.WriteLine("(4) Pomoc");
                Console.WriteLine("(5) Zakoncz program");
                wybor = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch(wybor)
                {
                    case 1:
                        operacja.Temperatura();
                        break;
                    case 2:
                        operacja.Dlugosc();
                        break;
                    case 3:
                        operacja.Masa();
                        break;
                    case 4:
                        operacja.Pomoc();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Nie wybrano operacji");
                        break;                  
                }
            }
        }
    }
}
