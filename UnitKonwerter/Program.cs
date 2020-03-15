using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitKonwerter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IKonwerter> converters = new List<IKonwerter>()
            {
                new KonwerterPredkosci(),
                new KonwerterTemperatury(),
                new KonwerterDlugosci(),
                new KonwerterMasy()
            };
                bool wyjscie = true;
                while (wyjscie)
                {
                    Console.WriteLine("Wybierz opcje: ");
                
                    for (int i = 0; i < converters.Count;i++)
                        {
                        Console.WriteLine("({0}) {1}", i+1, converters[i].Name);
                        }
                    string wybor = Console.ReadLine();
                    int wyborswitch = int.Parse(wybor);

                    Console.WriteLine("Podaj jednostke z: ");
                    string unitFrom = Console.ReadLine();

                    Console.WriteLine("Podaj jednostke do: ");
                    string unitTo = Console.ReadLine();

                    Console.WriteLine("Podaj liczbe do konwersji: ");
                    string inputValue = Console.ReadLine();
                    decimal value = decimal.Parse(inputValue);

                    decimal result = converters[wyborswitch - 1].Convert(unitFrom, unitTo, value);
                    Console.WriteLine("Wynik konwersji: {0}", result);
                    wyjscie = false;
                }
        }
    }
}
