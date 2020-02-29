using System;

namespace Konwerter_jednostek
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {

                int num1 = 0;
                string sterownik;
                Console.WriteLine("---------------------------\n");
                Console.WriteLine("    KONWERTER JEDNOSTEK\n");
                Console.WriteLine("---------------------------\n");
                Console.WriteLine("Witaj w konwerterze jednostek, wybierz jedną z dostępnych opcji:\n");
                Console.WriteLine("\ta - Konwersja temperatury      SKALA CELSJUSZA <=> SKALA FARENHEITA");
                Console.WriteLine("\tb - Konwersja długości         KILOMETRY <=> MILE");
                Console.WriteLine("\tc - Konwersja masy             KILOGRAM <=> FUNT");
                Console.WriteLine("\td - Wyjście\n");

                switch (Console.ReadLine())
                {
                    case "a":
                        Console.Clear();
                        Console.WriteLine("---------------------------\n");
                        Console.WriteLine("   KONWERTER TEMPERATURY\n");
                        Console.WriteLine("---------------------------\n");
                        Console.WriteLine("Wybierz jedną z opcji:\n");
                        Console.WriteLine("\ta - Konwersja ze stopni Farenheita na stopnie Celsjusza");
                        Console.WriteLine("\tb - Konwersja ze stopni Celsjusza na stopnie Fahrenheita");
                        Console.WriteLine("\tc - Powrót");
                        sterownik = Console.ReadLine();
                        if (sterownik == "a")
                        {
                            Console.WriteLine("Wprowadź wartość, którą chcesz przekonwertować ze stopni Farenheita na stopnie Celsjusza i wciśnij ENTER:");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Wynik to: " + ((num1 - 32) / 1.8) + "° Celsjusza");
                            break;
                        }
                        else if (sterownik == "b")
                        {
                            Console.WriteLine("Wprowadź wartość, którą chcesz przekonwertować ze stopni Celsjusza na stopnie Farenheita i wciśnij ENTER:");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Wynik to: " + ((num1 * 1.8) + 32) + "° Farenheita");
                            break;
                        }
                        else if (sterownik == "c")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wybierz prawidłową opcję!");
                        }


                        break;
                    case "b":
                        Console.Clear();
                        Console.WriteLine("---------------------------\n");
                        Console.WriteLine("    KONWERTER DŁUGOŚCI\n");
                        Console.WriteLine("---------------------------\n");
                        Console.WriteLine("Wybierz jedną z opcji:\n");
                        Console.WriteLine("\ta - Konwersja z kilometrów na mile");
                        Console.WriteLine("\tb - Konwersja z mil na kilometry");
                        Console.WriteLine("\tc - Powrót");
                        sterownik = Console.ReadLine();
                        if (sterownik == "a")
                        {
                            Console.WriteLine("Wprowadź wartość, którą chcesz przekonwertować z kilometrów na mile i wciśnij ENTER:");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Wynik to: " + (num1 * 0.621) + " mil");
                            break;
                        }
                        else if (sterownik == "b")
                        {
                            Console.WriteLine("Wprowadź wartość, którą chcesz przekonwertować z mil na kilometry i wciśnij ENTER:");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Wynik to: " + (num1 / 0.621) + " kilometrów");
                            break;
                        }
                        else if (sterownik == "c")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wybierz prawidłową opcję!");
                        }
                        break;
                    case "c":
                        Console.Clear();
                        Console.WriteLine("---------------------------\n");
                        Console.WriteLine("      KONWERTER MASY\n");
                        Console.WriteLine("---------------------------\n");
                        Console.WriteLine("Wybierz jedną z opcji:\n");
                        Console.WriteLine("\ta - Konwersja z kilogramów na funty");
                        Console.WriteLine("\tb - Konwersja z funtów na kilogramy");
                        Console.WriteLine("\tc - Powrót");
                        sterownik = Console.ReadLine();
                        if (sterownik == "a")
                        {
                            Console.WriteLine("Wprowadź wartość, którą chcesz przekonwertować z kilogramów na funty i wciśnij ENTER:");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Wynik to: " + (num1 * 2.204) + " funtów");
                            break;
                        }
                        else if (sterownik == "b")
                        {
                            Console.WriteLine("Wprowadź wartość, którą chcesz przekonwertować z funtów na kilogramy i wciśnij ENTER:");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Wynik to: " + (num1 / 2.204) + " kilogramów");
                            break;
                        }
                        else if (sterownik == "c")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wybierz prawidłową opcję!");
                        }
                        break;
                    case "d":
                        Console.WriteLine("Do widzenia!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wybierz prawidłową opcję!");
                        break;

                }
                Console.Write("Wciśnij dowolny przycisk, aby wrócić do głównego menu");
                Console.ReadKey();
                Console.Clear();
            }
            while (true);
        }
    }
}
