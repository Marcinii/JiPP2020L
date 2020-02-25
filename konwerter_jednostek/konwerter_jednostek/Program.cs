using System;

namespace konwerter_jednostek

{
    class konwerter
    {
        public static double DoOperation(double var_1, double var_2, string op)
        {
            double wynik = double.NaN;// wynik nie może być = 0
            
            switch (op)
            {
                case "a":
                    wynik = (var_1 - 32 )* 5 / 9;
                    break;
                case "b":
                    wynik = (var_1 * 9 / 5) + 32;
                    break;
                case "c":
                    wynik = var_1 * var_2;
                    break;
                case "d":
                        //nie dzielimy przez 0
                    if (var_2 != 0)
                    {
                        
                        wynik = var_1 / var_2;
                    }
                    break;
                default:
                    break;
            }
            return wynik;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Konwerter Jednostek\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // zadeklarownaie zmiennej
                string varInput1 = "";
                double wynik = 0;

                // zapytanie o zmienna var1
                Console.Write("Podaj wartosc do konwersji: ");
                varInput1 = Console.ReadLine();

                double cleanvar_1 = 0;
                while (!double.TryParse(varInput1, out cleanvar_1))
                {
                    Console.Write("Wartosc nie moze wynosic 0 podaj inna wartosc: ");
                    varInput1 = Console.ReadLine();
                    
                }
                double cleanvar_2 = 1.61;
                // wybor konwersji
                Console.WriteLine("Wybierz co chcesz Zrobic:");
                Console.WriteLine("\ta - Konwersja Fahrenheita na Celcjusza");
                Console.WriteLine("\tb - Konwersja celcjusza na Fahrenheita");
                Console.WriteLine("\tc - Konwersja Mil na Kliometry");
                Console.WriteLine("\td - Konwersja Kilometrow na Mile");
                Console.Write("twoja opcja to? ");

                string op = Console.ReadLine();


                    wynik = konwerter.DoOperation(cleanvar_1, cleanvar_2, op);
                    if (double.IsNaN(wynik))
                    {
                        Console.WriteLine("blad nie moze byc dzielone przez 0.\n");
                    }
                    else Console.WriteLine("Twoj wynik konwersji wynosi: {0:0.##}\n", wynik);
  

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Wcisnij w aby wyjsc z programu: ");
                if (Console.ReadLine() == "w") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }
    }
}
