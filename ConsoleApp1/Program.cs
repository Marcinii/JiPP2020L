using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double temp;
            Console.WriteLine("Wybierz rodzaj konwersji:");
            Console.WriteLine("1 - Celcius do Fahrenheit");
            Console.WriteLine("2 - Fahrenheit do Celcius");
            int pickle = Convert.ToInt32(Console.ReadLine());
            switch (pickle)
            {
                case 1:
                    Console.WriteLine("Wpisz wartość:");
                    temp = Console.Read();
                    Console.WriteLine("Temperatura Fahrenheit: " + (temp * (9 / 5) + 32) + "°F");
                    break;
                case 2:
                    Console.WriteLine("Wpisz wartość:");
                    temp = Console.Read();
                    Console.WriteLine("Temperatura Fahrenheit: " + ((temp-32)/(9/5)) + "°F");
                    break;
             
            }
        }
    }
}
