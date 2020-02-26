using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Double liczba = 0;

            Console.WriteLine("Konwerter Jednostek");
            Console.WriteLine("Wybierz Konwerter:");
            Console.WriteLine("1.Temperatura");
            Console.WriteLine("2.Dlugosc");
            Console.WriteLine("3.Masa");
            Console.Write("Podaj Numer: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Wybierz Opcje:");
                    Console.WriteLine("1.Celsjusz->Farenheit");
                    Console.WriteLine("2.Farenheit->Celsjusz");
                    Console.Write("Podaj Numer: ");
                    switch (Console.ReadLine())
                    {
                        
                case "1":
                            Console.Write("Podaj Liczbe: ");
                            liczba = Convert.ToDouble(Console.ReadLine());
                            Console.Write($"{liczba} Celsjusza = " + (liczba * (9 / 5) + 32) + " Farenheita");
                    break;
                case "2":
                            Console.Write("Podaj Liczbe: ");
                            liczba = Convert.ToDouble(Console.ReadLine());
                            Console.Write($"{liczba} Farenheita = " + ((liczba - 32) / (5 / 9)) + " Celsjusza");
                    break;
            }
            break;
                case "2":
                    Console.WriteLine("Wybierz Opcje:");
            Console.WriteLine("1.Kilometry->Mile");
            Console.WriteLine("2.Mile->Kilometry");
            Console.Write("Podaj Numer: ");
            switch (Console.ReadLine())
            {
                        case "1":
                            Console.Write("Podaj Liczbe: ");
                            liczba = Convert.ToDouble(Console.ReadLine());
                            Console.Write($"{liczba} Kilometry = " + (liczba / 1.609344) + " Mile");
            break;
                        case "2":
                            Console.Write("Podaj Liczbe: ");
                            liczba = Convert.ToDouble(Console.ReadLine());
                            Console.Write($"{liczba} Mile = " + (liczba * 1.609344) + " Kilometry");
            break;
        }
                    break;
                case "3":
                    Console.WriteLine("Wybierz Opcje:");
                    Console.WriteLine("1.Kilogramy->Funty");
                    Console.WriteLine("2.Funty->Kilogramy");
                    Console.Write("Podaj Numer: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Write("Podaj Liczbe: ");
                            liczba = Convert.ToDouble(Console.ReadLine());
                            Console.Write($"{liczba} Kilogramy = " + (liczba/0.45359237) + " Funty");
                            break;
                        case "2":
                            Console.Write("Podaj Liczbe: ");
                            liczba = Convert.ToDouble(Console.ReadLine());
                            Console.Write($"{liczba} Funty = " + (liczba*0.45359237) + " Kilogramy");
                            break;
                    }
                    break;
            }
Console.ReadKey();
        }
    }
}