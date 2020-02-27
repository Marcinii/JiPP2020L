using System;


namespace ConsoleApp1
{
    class Program
    {
        static void Zapytanie(string wybor)
        {
            if (wybor == "T" || wybor == "t")
                Main(null);
        }
        static void Main(string[] args)
        {
            

            double temp;
            string czyPowtorzyc;
            Console.WriteLine("Wybierz rodzaj konwersji:");
            Console.WriteLine("1 - Celcius do Fahrenheit");
            Console.WriteLine("2 - Fahrenheit do Celcius");
            Console.WriteLine("3 - Kilometry na metry");
            Console.WriteLine("4 - Metry na kilometry");
            Console.WriteLine("5 - Kilogramy na funty");
            Console.WriteLine("6 - Funty na kilogramy");
            Console.WriteLine("Wybór: ");
            int pickle = 0;
            pickle = Convert.ToInt32(Console.ReadLine());

            if (pickle < 1 || pickle > 6)
            {
                Console.WriteLine("Niepoprawny wybor. Naciśnij ENTER i uruchom program ponownie: ");
                Console.Read();
                System.Environment.Exit(1);
            }

            switch (pickle)
            {
                case 1:
                    Console.WriteLine("Wpisz wartość:");
                    temp = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Wynik \n" + temp + "°C to " + (temp * 9 / 5 + 32) + "°F \n Czy wykonać program jeszcze raz? (T/N)");
                    czyPowtorzyc = Console.ReadLine();
                    Zapytanie(czyPowtorzyc);
                    break;
                case 2:
                    Console.WriteLine("Wpisz wartość:");
                    temp = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Wynik \n" + temp + "°F to " + ((temp-32) * 5/9) + "°C \n Czy wykonać program jeszcze raz? (T/N)");
                    czyPowtorzyc = Console.ReadLine();
                    Zapytanie(czyPowtorzyc);
                    break;
                case 3:
                    Console.WriteLine("Wpisz wartość:");
                    temp = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Wynik \n" + temp + "km to " + temp * 1000 + "m \n Czy wykonać program jeszcze raz? (T/N)");
                    czyPowtorzyc = Console.ReadLine();
                    Zapytanie(czyPowtorzyc);
                    break;
                case 4:
                    Console.WriteLine("Wpisz wartość:");
                    temp = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Wynik \n" + temp + "m to " + temp / 1000 + "km \n Czy wykonać program jeszcze raz? (T/N)");
                    czyPowtorzyc = Console.ReadLine();
                    Zapytanie(czyPowtorzyc);
                    break;
                case 5:
                    Console.WriteLine("Wpisz wartość:");
                    temp = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Wynik \n" + temp + "kg to " + temp / 0.45359237 + " funtów \n Czy wykonać program jeszcze raz? (T/N)");
                    czyPowtorzyc = Console.ReadLine();
                    Zapytanie(czyPowtorzyc);
                    break;
                case 6:
                    Console.WriteLine("Wpisz wartość:");
                    temp = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Wynik \n" + temp + " funtów to " + temp * 0.45359237 + "kg \n Czy wykonać program jeszcze raz? (T/N)");
                    czyPowtorzyc = Console.ReadLine();
                    Zapytanie(czyPowtorzyc);
                    break;
            }
        }
    }
}
