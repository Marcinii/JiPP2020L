using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kalkulator.Logic;

namespace Kalkulator
{
    class Program
    {
        static void Main(string[] args)
        {

            List<IDzialanie> Dzialania = new List<IDzialanie>
            {
                new Add(),
                new Sub(),
                new Multi(),
                new Divide()
            };

            bool kontynuacja = true;

            while (kontynuacja)
            {

                for (int i = 0; i < Dzialania.Count; i++)
                {
                    Console.WriteLine("[" + (i + 1) + "] " + Dzialania[i].Nazwa);
                }



                Console.Write("Wybor Dzialania Arytmetycznego: ");
                int wybor = Int32.Parse(Console.ReadLine());
                Console.Write("Podaj pierwsza wartosc: ");
                //double value = Double.Parse(Console.ReadLine());
                double firstpick = Double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj druga wartosc");
                double secondpick = Double.Parse(Console.ReadLine());

                Console.WriteLine("Wynik = " + Dzialania[wybor - 1]?.Oblicz(firstpick, secondpick));

                kontynuacja = false;

            }


        }
    }
}