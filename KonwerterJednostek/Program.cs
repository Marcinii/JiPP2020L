using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    class Program
    {
        static double CelciusToFarenheit(double c)
        {
            return c * 1.8 + 32;
        }
        static double FahrenheitToCelcius(double f)
        {
            return (f - 32) * 1.8;
        }
        static double KilometresToMiles(double km)
        {
            return km * 0.62137;
        }
        static double MilesToKilometres(double mi)
        {
            return mi / 0.62137;
        }
        static double KilogramsToPounds(double kg)
        {
            return kg / 0.45359237;
        }
        static double PoundsToKilograms(double lb)
        {
            return lb * 0.45359237;
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine("Konwerter");
            System.Console.WriteLine("[1] Celsjusze <--> Farenheity");
            System.Console.WriteLine("[2] Kilometry <--> Mile");
            System.Console.WriteLine("[3] Kilogram <--> Funty");

            int wyborjeden = int.Parse(Console.ReadLine());
            int wybordwa;

            switch (wyborjeden) {

                case 1:
                    System.Console.WriteLine("Wybrałeś: Celsjusze <-->Farenheity");
                    System.Console.WriteLine("[1] Celsjusze <--> Farenheity");
                    System.Console.WriteLine("[2] Farenheity <--> Celsjusze");
                    wybordwa = int.Parse(Console.ReadLine());
                    Console.Write("Wprowadź wartość: ");
                    switch (wybordwa)
                    {
                        case 1:
                            Console.WriteLine(CelciusToFarenheit(double.Parse(Console.ReadLine())));
                        break;

                        case 2:
                            Console.WriteLine(FahrenheitToCelcius(double.Parse(Console.ReadLine())));
                            break;

                        default:
                            System.Console.WriteLine("Wybór nieprawidłowy, wybrałeś: " + wyborjeden);
                            break;
                    }
                    break;
                case 2:
                    System.Console.WriteLine("Wybrałeś: Kilometry <--> Mile");
                    System.Console.WriteLine("[1] Kilometry <--> Mile");
                    System.Console.WriteLine("[2] Mile  <-->  Kilometry");
                    wybordwa = int.Parse(Console.ReadLine());
                    Console.Write("Wprowadź wartość: ");
                    switch (wybordwa)
                    {
                        case 1:
                            Console.WriteLine(KilometresToMiles(double.Parse(Console.ReadLine())));
                            break;

                        case 2:
                            Console.WriteLine(MilesToKilometres(double.Parse(Console.ReadLine())));
                            break;

                        default:
                            System.Console.WriteLine("Wybór nieprawidłowy, wybrałeś: " + wyborjeden);
                            break;
                    }
                    break;

                case 3:
                    System.Console.WriteLine("Wybrałeś: Kilogramy <--> Funty");
                    System.Console.WriteLine("[1] Kilogramy <--> Funty");
                    System.Console.WriteLine("[2] Funty <--> Kilogramy");
                    wybordwa = int.Parse(Console.ReadLine());
                    Console.Write("Wprowadź wartość: ");
                    switch (wybordwa)
                    {
                        case 1:
                            Console.WriteLine(KilogramsToPounds(double.Parse(Console.ReadLine())));
                            break;

                        case 2:
                            Console.WriteLine(PoundsToKilograms(double.Parse(Console.ReadLine())));
                            break;

                        default:
                            System.Console.WriteLine("Wybór nieprawidłowy, wybrałeś: " + wyborjeden);
                            break;
                    }
                    break;

                default:
                    System.Console.WriteLine("Wybór nieprawidłowy, wybrałeś: " + wyborjeden);
                    break;
            }

            Console.ReadLine();
        }
    }
}
