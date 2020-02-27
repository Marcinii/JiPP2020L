using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[1] Zamiana stopni Celsjusza na Farenheita");
            Console.WriteLine("[2] Zamiana stopni Farenheita na Celsjusza");
            Console.WriteLine("[3] Zamiana km na mile");
            Console.WriteLine("[4] Zamiana mil na km");
            Console.WriteLine("[5] Zamiana kg na funty");
            Console.WriteLine("[6] Zamiana funtow na kg");

            Console.Write("Wybor: ");
            int choise = Int32.Parse(Console.ReadLine());
            Console.Write("Podaj wartosc: ");

            int value = Int32.Parse(Console.ReadLine());

            switch(choise)
            {
                case 1:
                    Console.WriteLine("Wynik = " + Converter.Temperature.CToF(value));
                    break;
                case 2:
                    Console.WriteLine("Wynik = " + Converter.Temperature.FToC(value));
                    break;
                case 3:
                    Console.WriteLine("Wynik = " + Converter.Length.KmToMiles(value));
                    break;
                case 4:
                    Console.WriteLine("Wynik = " + Converter.Length.MilesToKm(value));
                    break;
                case 5:
                    Console.WriteLine("Wynik = " + Converter.Weight.KgToLb(value));
                    break;
                case 6:
                    Console.WriteLine("Wynik = " + Converter.Weight.LbToKg(value));
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybor");
                    break;            
            }

        }
    }
}