using System;
using System.Collections.Generic;

namespace Project
{
    class Program
    {
        public static void Main()
        {
            int choice = 0, jednostka = 0;
            double zmienna = 0;
            bool shouldContinue = true;
            List<IKonwerter> Konwertery = new List<IKonwerter>()
            {
                new LenKonwerter(),
                new TempKonwerter(),
                new MassKonwerter(),
                new PowKonwerter()
            };

            while (shouldContinue)
            {
                
                Console.WriteLine("Witaj w menu konwertera:\n\n");
                foreach(IKonwerter I in Konwertery)
                {
                    Console.WriteLine("{0} - {1}", ++choice,I.Name);
                }
                
                choice = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.WriteLine("Wybierz zamiane jaka chcesz otrzymac:\n\n");
                for (int i = 0; i < Konwertery[choice].Units.Count; i++)
                {
                    for (int j = 0; j < Konwertery[choice].Units.Count; j++)
                    {
                        if (j != i)
                        {
                            Console.WriteLine("{0}. {1} na {2}", ++jednostka,Konwertery[choice].Units[i],Konwertery[choice].Units[j]);
                        }
                    }
                }
                jednostka = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.WriteLine("Podaj wartosc do konwersji: ");
                zmienna = Convert.ToDouble(Console.ReadLine());
                Konwertery[choice].VarUnit(zmienna,jednostka);

                Console.ReadLine();

                shouldContinue = false;

            }
        }
    }
}