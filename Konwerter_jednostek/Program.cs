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
            List<IKonwerter> konwertery = new List<IKonwerter>()
            {
                new Temperatura(),
                new Masa(),
                new Objetosc(),
                new Odleglosc()
            };

            bool kont = true;
            char wyborC;

            //while (shouldContinue)
            do
                {
                    Console.WriteLine("Wybierz opcje: ");

                    for (int i = 0; i < konwertery.Count; i++)
                    {
                        Console.WriteLine("({0}) {1}", i + 1, konwertery[i].Nazwa);
                    }

                    string opcja = Console.ReadLine();
                    int wybor = int.Parse(opcja);


                    Console.Write("Podaj jednostke z: ");
                    string JednostkaZ = Console.ReadLine();

                    Console.Write("Podaj jednostkę na: ");
                    string JednostkaNa = Console.ReadLine();

                    Console.Write("Podaj liczbę do konwersji: ");
                    string liczba = Console.ReadLine();
                    double wartosc = double.Parse(liczba);

                //int choice = int.Parse(inputChoice); // TryParse!
                  //  decimal value = decimal.Parse(inputValue); // TryParse!

                    Console.WriteLine("Wynik konwersji: {0}", konwertery[wybor - 1].Konwerter(JednostkaZ, JednostkaNa, wartosc));

                Console.Write("Dokonac ponownej konwersji (T/N): ");
                wyborC = Convert.ToChar(Console.ReadLine());
                if (wyborC=='N' || wyborC=='n') {kont = false;}
                } while (kont);
        }
    }

    
}
