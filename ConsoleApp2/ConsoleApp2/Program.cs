using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Wybierz jednostki: ");
            Console.WriteLine("1.Temperatury (Celcjusz, Farenheit \n2.Długości (Kilometry, Mile) \n3.Masy (Kilogramy, Funty)");
            
            string symbol1 = Console.ReadLine();
            switch (symbol1)
            {
                case "1":
                    Console.WriteLine("1.Temperatury (Celcjusz, Farenheit) \n Wybierz: \n 1.Celcjusz na Farenheit \n 2.Farenheit na Celcjusz");
                    string symbol2 = Console.ReadLine();
                    Console.WriteLine("Podaj liczbę: ");
                    var jednostka = Console.ReadLine();
                    var value = Convert.ToInt32(jednostka);
                    switch (symbol2)
                    {
                        case "1":
                            Console.WriteLine(value + " C to " + Przelicznik.liczTemperature(value, symbol2)+" F");
                            break;
                        case "2":
                            Console.WriteLine(value + " F to " + Przelicznik.liczTemperature(value, symbol2)+" C");
                            break;
                        default:
                            Console.WriteLine("Podaj poprawną wartość!");
                                break;
                    }
                    break;
                case "2":
                    Console.WriteLine("2.Długości (Kilometry, Mile) \n Wybierz: \n 1.Kilometry na Mile \n 2.Mile na Kilometry");
                    string symbol3 = Console.ReadLine();
                    Console.WriteLine("Podaj liczbę: ");
                    var jednostka2 = Console.ReadLine();
                    var value2 = Convert.ToInt32(jednostka2);
                    switch (symbol3)
                    {
                        case "1":
                            Console.WriteLine(value2 + " km to " + Przelicznik.liczDlugosci(value2, symbol3)+" Mm");
                            break;
                        case "2":
                            Console.WriteLine(value2 + " Mm to " + Przelicznik.liczDlugosci(value2, symbol3)+" km");
                            break;
                        default:
                            Console.WriteLine("Podaj poprawną wartość!");
                            break;
                    }
                    break;
                case "3":
                    Console.WriteLine("3.Masy (Kilogramy, Funty) \n Wybierz: \n 1.Kilogramy na Funty \n 2.Funty na Kilogramy");
                    string symbol4 = Console.ReadLine();
                    Console.WriteLine("Podaj liczbę: ");
                    var jednostka3 = Console.ReadLine();
                    var value3 = Convert.ToInt32(jednostka3);
                    switch (symbol4)
                    {
                        case "1":
                            Console.WriteLine(value3 + " kg to " + Przelicznik.liczMase(value3, symbol4)+" lb");
                            break;
                        case "2":
                            Console.WriteLine(value3 + " lb to " + Przelicznik.liczMase(value3, symbol4)+" kg");
                            break;
                        default:
                            Console.WriteLine("Podaj poprawną wartość!");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            Console.ReadKey();
        }
    }
}
