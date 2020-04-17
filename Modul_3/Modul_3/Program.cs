using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //    List<Ikonwerter> konwertetr = new List<Ikonwerter>(){
            //     new Temperatura(),
            //     new Dlugosc(),
            //    new Waga(),
            //     new Czas()
            //};
            //    while (true)
            //    {
            //        Console.WriteLine("Wybierz opcje:");
            //        int i = 1;
            //        foreach (Ikonwerter tmp in konwertetr)
            //        {
            //            Console.WriteLine("({0}){1}", i, konwertetr[i - 1].nazwa);
            //            i++;
            //        }
            //        int x = int.Parse(Console.ReadLine());
            //        Console.WriteLine("Wybierz opcje:");
            //        for (int j = 0; j < konwertetr[x - 1].Unit.Count; j++)
            //        {
            //            Console.WriteLine("({0}){1}", j + 1, konwertetr[x - 1].Unit[j]);
            //        }
            //        int y = int.Parse(Console.ReadLine());
            //        Console.WriteLine("Podaj wartosc do zmiany");
            ////        double wynik = double.Parse(Console.ReadLine());
            ////        Console.WriteLine("Wynik z : {0} = {1}\n ", konwertetr[x - 1].Unit[y - 1], konwertetr[x - 1].Zamiana(wynik, y));
            ////    }

            //}
            using (JIPPEntities context = new JIPPEntities())
            {
                List<Stata> statas = context.Statas.ToList();
                foreach (Stata e in statas)
                {
                    Console.WriteLine(e.Rodzaj_Konwertera);
                    Console.ReadKey();
                }
            }

        }
    }
}