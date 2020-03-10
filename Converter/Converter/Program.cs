using System;

namespace Converter
{
    class Converter
    {
        public double convertToC(double x)
        {
            double temp = (x - 32) * (5.0 / 9.0);
            return temp;
        }
        public double convertToF(double x)
        {
            double temp = x * (9.0 / 5.0) + 32.0;
            return temp;
        }
        public double convertToKm(double x)
        {
            double temp = 0.621371192 * x;
            return temp;
        }
        public double convertToMiles(double x)
        {
            double temp = 1.609344 * x;
            return temp;
        }
        public double convertToKg(double x)
        {
            double temp = 0.45359237 * x;
            return temp;
        }
        public double convertToPounds(double x)
        {
            double temp = 2.20462262 * x;
            return temp;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Converter c = new Converter();
            bool status = true;

            while (status)
            {
                Console.WriteLine("1 - Konwersja Faranheit -> Celsjusz");
                Console.WriteLine("2 - Konwersja Celsjusz -> Faranheit");
                Console.WriteLine("3 - Konwersja Kilometry -> Mile");
                Console.WriteLine("4 - Konwersja Mile -> Kilometry");
                Console.WriteLine("5 - Konwersja Kilogramy -> Funty");
                Console.WriteLine("6 - Konwersja Funty -> Kilogramy");
                Console.WriteLine("9 - wyjscie");
                Console.WriteLine("Your input: ");
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            {
                                Console.WriteLine("Podaj temperature (C): ");
                                double temp = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Wynik: {0} F", c.convertToF(temp));
                                Console.WriteLine("\nPress any key");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 2:
                            {
                                Console.WriteLine("Podaj temperature (Faranheity): ");
                                double temp = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Wynik: {0} C", c.convertToC(temp));
                                Console.WriteLine("\nPress any key");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 3:
                            {
                                Console.WriteLine("Podaj dlugosc (Kilometry): ");
                                double temp = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Wynik: {0} Mi", c.convertToMiles(temp));
                                Console.WriteLine("\nPress any key");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 4:
                            {
                                Console.WriteLine("Podaj dlugosc (Mile): ");
                                double temp = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Wynik: {0} Km", c.convertToKm(temp));
                                Console.WriteLine("\nPress any key");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 5:
                            {
                                Console.WriteLine("Podaj mase (Kg): ");
                                double temp = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Wynik: {0} lb", c.convertToPounds(temp));
                                Console.WriteLine("\nPress any key");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 6:
                            {
                                Console.WriteLine("Podaj mase (Lb): ");
                                double temp = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Wynik: {0} Kg", c.convertToKg(temp));
                                Console.WriteLine("\nPress any key");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 9:
                            status = false;
                            Console.WriteLine(": )");
                            break;
                        default:
                            Console.WriteLine("Consider other option");
                            Console.WriteLine("\nPress any key");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }

}
