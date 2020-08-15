using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("KALKULATOR - JEDNOSTEK");
            Console.WriteLine("Wybierz operację: ");
            Console.WriteLine("1.Temperatury (Celcjusz / Farenheit)");
            Console.WriteLine("2.Długości (Kilometry / Mile)");
            Console.WriteLine("3.Masy (Kilogramy / Funty)");

            string operacja = Console.ReadLine();
            switch (operacja)
            {
                case "1":
                    Console.WriteLine("Wybrano Temperatury! Wybierz potrzebny konwenter: ");
                    Console.WriteLine("1.Celcjusz na Farenheit");
                    Console.WriteLine("2.Farenheit na Celcjusz");

                    string operacjaT = Console.ReadLine();
                    Console.WriteLine("Podaj liczbę do konwersji: ");
                    var wartoscT = Console.ReadLine();
                    var valueT = Convert.ToInt32(wartoscT);

                    switch (operacjaT) //T jak Temperatury
                    {
                    case "1":
                    Console.WriteLine(valueT + " C to " + Przelicznik.ZamianaTemperatur(valueT, operacjaT) + " F"); break;
                    case "2":
                    Console.WriteLine(valueT + " F to " + Przelicznik.ZamianaTemperatur(valueT, operacjaT) + " C"); break;
                    default: break;
                    }
                    break;

                    case "2":
                        Console.WriteLine("Wybrano Długosci! Wybierz potrzebny konwenter: ");
                        Console.WriteLine("1.Kilometry na Mile");
                        Console.WriteLine("2.Mile na Kilometry");

                        string operacjaD = Console.ReadLine();
                        Console.WriteLine("Podaj liczbę do konwersji: ");
                        var wartoscD = Console.ReadLine();
                        var valueD = Convert.ToInt32(wartoscD);

                    switch (operacjaD) //D jak Długości
                            {
                        case "1":
                            Console.WriteLine(valueD + " km to " + Przelicznik.ZamianaDlugosci(valueD, operacjaD) + " Mm"); break;
                        case "2":
                            Console.WriteLine(valueD + " Mm to " + Przelicznik.ZamianaDlugosci(valueD, operacjaD) + " km"); break;
                        default: break;
                    }
                    break;

                case "3":
                    Console.WriteLine("Wybrano Masy! Wybierz potrzebny konwenter: ");
                    Console.WriteLine("1.Kilogramy na funty");
                    Console.WriteLine("2.Funty na kilogramy"); 
                    
                    string operacjaM = Console.ReadLine();
                    Console.WriteLine("Podaj liczbę do konwersji: ");
                    var wartoscM = Console.ReadLine();
                    var valueM = Convert.ToInt32(wartoscM);
                    switch (operacjaM)
                    {
                        case "1":
                            Console.WriteLine(valueM + " kg to " + Przelicznik.ZamianaMas(valueM, operacjaM) + " lb"); break;
                        case "2":
                            Console.WriteLine(valueM + " lb to " + Przelicznik.ZamianaMas(valueM, operacjaM) + " kg"); break;
                        default: break;
                    }
                    break;
                default:
                    Console.WriteLine("WYBRANO NIE ISTNIEJĄCY KONWERTER!"); break;
            }
            Console.ReadKey();
        }
    }
}