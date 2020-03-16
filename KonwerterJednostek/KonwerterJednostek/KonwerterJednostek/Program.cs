using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj Liczbe: ");
            int liczba;
            liczba = int.Parse(Console.ReadLine());

            for (; ; )
            {

                Console.WriteLine("Co chcesz policzyć?");
                Console.WriteLine("1. Celsjusze na Farenheity.");
                Console.WriteLine("2. Farenheita na Celsjusze");
                Console.WriteLine("3. Kilometry na mile");
                Console.WriteLine("4. Mile na kilometry");
                Console.WriteLine("5. Kilogramy na funty");
                Console.WriteLine("6. Funty na kilogramy");

                Console.WriteLine("Wybierz: ");
                double wybor;
                wybor = double.Parse(Console.ReadLine());

                double c, f, km, m, kg, ft;


                switch (wybor)
                {
                    case 1:
                        f = ((9 / 5) * liczba) + 32;
                        Console.WriteLine(liczba + " stop(ien)/(ni) Celsjusza, to " + f + " Farenheita.");
                        Console.ReadLine();
                        break;
                    case 2:
                        c = 0.56 * (liczba - 32);

                        Console.WriteLine(liczba + " stop(ien)/(ni) Farenheita, to " + c + " Celsjusza.");
                        Console.ReadLine();
                        break;
                    case 3:
                        m = 0.62 * liczba;
                        Console.WriteLine(liczba + " kilometr(ow), to " + m + " mil(e).");
                        Console.ReadLine();
                        break;
                    case 4:
                        km = 1.6 * liczba;
                        Console.WriteLine(liczba + " mil(a), to " + km + " kilometrow.");
                        Console.ReadLine();
                        break;
                    case 5:
                        ft = 0.45 * liczba;
                        Console.WriteLine(liczba + " kilogram(ow), to " + ft + " funtow.");
                        Console.ReadLine();
                        break;
                    case 6:
                        kg = 2.2 * liczba;
                        Console.WriteLine(liczba + " funt(ow), to " + kg + " kilogramow.");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
        }
    }
}
