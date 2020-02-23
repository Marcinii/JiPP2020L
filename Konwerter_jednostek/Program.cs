using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    class Program
    {
        static void Main(string[] args)
        {
            char wybor;
            do
            {
                Console.WriteLine("\nKonwerter jednostek");
                Console.WriteLine("\n1 - temperatury (Skala Celsjusza -> Skala Fahrenheita)\n2 - temperatury (Skala Fahrenheita -> Skala Celsjusza)\n3 - dlugosci (kilometry -> mile)\n4 - dlugosci (mile -> kilometry)\n5 - masy (kilogramy -> funty)\n6 - masy (funty -> kilogramy)\n0 - wyjscie z programu\n");
                wybor = Convert.ToChar(Console.ReadLine());
                switch (wybor)
                {
                    case '1':
                        CF T1 = new CF();
                        T1.pobierz_dane();
                        T1.info();
                        Console.ReadKey();
                        break;
                    case '2':
                        FC T2 = new FC();
                        T2.pobierz_dane();
                        T2.info();
                        Console.ReadKey();
                        break;
                    case '3':
                        KM D1 = new KM();
                        D1.pobierz_dane();
                        D1.info();
                        Console.ReadKey();
                        break;
                    case '4':
                        MK D2 = new MK();
                        D2.pobierz_dane();
                        D2.info();
                        Console.ReadKey();
                        break;
                    case '5':
                        KF M1 = new KF();
                        M1.pobierz_dane();
                        M1.info();
                        Console.ReadKey();
                        break;
                    case '6':
                        FK M2 = new FK();
                        M2.pobierz_dane();
                        M2.info();
                        Console.ReadKey();
                        break;
                    case '0':
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("\nNie dokonano wyboru\n");
                        break;
                }
            } while (true);
        }
    }
}
