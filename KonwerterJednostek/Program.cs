using KonwerterJednostek.Logic;
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
            List<IKonwerter> converters = new List<IKonwerter>()
                {
                    new CelciusToFarenheit(),
                    new FahrenheitToCelcius(),
                    new KilogramsToPounds(),
                    new KilometresToMiles(),
                    new MilesToKilometres(),
                    new PoundsToKilograms(),
                    new Cisnienie_Pa_To_hPa()
                 };

                    Console.WriteLine("Wybierz opcję: ");
                    Console.WriteLine("km,mil | c,f | kg,lb");
                for (int i = 0; i < converters.Count; i++)
                    {
                        Console.WriteLine("[{0}] - {1}", i + 1, converters[i].Name);
                    }
                    Console.WriteLine("Podaj Wybór: ");
                    string inputChoice = Console.ReadLine();
                    int choice = int.Parse(inputChoice); // TryParse można użuć bo zwraca tak albo nie

                    Console.WriteLine("Podaj jednostek z: ");
                    var unitFrom = Console.ReadLine();

                    Console.WriteLine("Podaj jednostkę do: ");
                    var unitTo = Console.ReadLine();

                    Console.WriteLine("Podaj liczbę do konwersji: ");
                    var inputValue = Console.ReadLine();


                    double value = double.Parse(inputValue); // TryParse można użuć bo zwraca tak albo nie

                    Console.WriteLine("Wynik konwersji: {0}", converters[choice - 1].Convert(value));
                    Console.ReadKey();
            }
        }
    }
