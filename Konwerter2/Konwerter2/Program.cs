using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter2
{
    class Program
    {

        static void Main(string[] args)
        {
            bool kontynuacja = true;

            List<IKonwerter> konwertery = new List<IKonwerter>()
            {
                new KonwerterTemperatury(),
                new KonwerterDlugosci(),
                new KonwerterMasy(),
                new KonwerterCzasu()
            };

            List<IKonwerterWyboru> konwerterytemperatury = new List<IKonwerterWyboru>()
            {
                new CelsjuszaNaFarenheita(),
                new FarenheitaNaCelsjusza()
            };

            List<IKonwerterWyboru> konwerterydlugosci = new List<IKonwerterWyboru>()
            {
                new MileNaKilometry(),
                new KilometryNaMile(),
                new MetryNaKilometry()
            };

            List<IKonwerterWyboru> konwerterymasy = new List<IKonwerterWyboru>()
            {
                new KilogramyNaFunty(),
                new FuntyNaKilogramy()
            };

            List<IKonwerterWyboru> konwerteryczasu = new List<IKonwerterWyboru>()
            {
                new MinutyNaSekundy(),
                new SekundyNaMinuty()
            };

            while (kontynuacja)
            {

                Console.WriteLine("Podaj liczbę do konwersji: ");
                string wartosc = Console.ReadLine();

                Console.WriteLine("Wybierz konwerter: ");

                for (int i = 0; i < konwertery.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, konwertery[i].Name);

                }

                string wybor = Console.ReadLine();
                int wyborjednostki = int.Parse(wybor);

                Console.WriteLine("Wybór konwertera: {0}", konwertery[wyborjednostki - 1].Name);

                Console.WriteLine("Wybierz zamiane: ");

                switch (wyborjednostki)
                {
                    case 1:
                        for (int i = 0; i < konwerterytemperatury.Count; i++)
                        {
                            Console.WriteLine("({0}) {1}", i + 1, konwerterytemperatury[i].Name);
                        }
                        string parametr = Console.ReadLine();
                        int parametrjednostki = int.Parse(parametr);
                        Console.WriteLine("Wybór zamiany: {0}", konwerterytemperatury[parametrjednostki - 1].Name);
                        double wartoscjednostki = double.Parse(wartosc);
                        Console.WriteLine("Wynik konwersji: {0}", konwerterytemperatury[parametrjednostki - 1].Convert(wartoscjednostki));
                        break;
                    case 2:
                        for (int i = 0; i < konwerterydlugosci.Count; i++)
                        {
                            Console.WriteLine("({0}) {1}", i + 1, konwerterydlugosci[i].Name);
                        }
                        parametr = Console.ReadLine();
                        parametrjednostki = int.Parse(parametr);
                        wartoscjednostki = double.Parse(wartosc);
                        Console.WriteLine("Wynik konwersji: {0}", konwerterydlugosci[parametrjednostki - 1].Convert(wartoscjednostki));
                        break;
                    case 3:
                        for (int i = 0; i < konwerterymasy.Count; i++)
                        {
                            Console.WriteLine("({0}) {1}", i + 1, konwerterymasy[i].Name);
                        }
                        parametr = Console.ReadLine();
                        parametrjednostki = int.Parse(parametr);
                        wartoscjednostki = double.Parse(wartosc);
                        Console.WriteLine("Wynik konwersji: {0}", konwerterymasy[parametrjednostki - 1].Convert(wartoscjednostki));
                        break;
                    case 4:
                        for (int i = 0; i < konwerteryczasu.Count; i++)
                        {
                            Console.WriteLine("({0}) {1}", i + 1, konwerteryczasu[i].Name);
                        }
                        parametr = Console.ReadLine();
                        parametrjednostki = int.Parse(parametr);
                        wartoscjednostki = double.Parse(wartosc);
                        Console.WriteLine("Wynik konwersji: {0}", konwerteryczasu[parametrjednostki - 1].Convert(wartoscjednostki));
                        break;
                        default:
                        break;
                }

                kontynuacja = false;
            }
        }
    }
}
