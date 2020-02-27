using System;

namespace KonwerterJednostek
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Konwerter jednostek");
            Console.WriteLine("Wybierz: 1. Konwertuj temperature 2. Konwertuj dlugosci 3. Konwertuj mase");

            {
                string str = Console.ReadLine();

                switch (str)
                {
                    case "1":
                        convertCeltoFar k = new convertCeltoFar();
                        k.conCeltoFar();
                        break;
                    case "2":
                        convertKmtoM j = new convertKmtoM();
                        j.conKmtoM();
                        break;
                    case "3":
                        convertKgtoF m = new convertKgtoF();
                        m.conKgtoF();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}