﻿using System;
using System.Collections.Generic;

namespace unitConverterv2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IConvert> converters = new List<IConvert>()
            {
                new tempConverter(),
                new lengthCon(),
                new weightConverter(),
                new SurfaceConvert(),
                

            };
            Console.WriteLine("Wybierz Opcje");
            for (int i = 0; i < converters.Count; i++)
            {
                Console.WriteLine("({0}) {1}", i + 1, converters[i].Name);
            }
            string inputChoice = Console.ReadLine();
            int index = Convert.ToInt32(inputChoice) - 1;

            Console.WriteLine("Wybierz Z jakiej jednostki: ");

            for (int i = 0; i < converters[index].Units.Count; i++)
            {
                Console.WriteLine("({0}) {1}", i + 1, converters[index].Units[i]);
            }
            string fUnit = Console.ReadLine();
            int fromUnit = int.Parse(fUnit) - 1;


            Console.WriteLine("Wybierz Do jakiej jednostki: ");
            for (int i = 0; i < converters[index].Units.Count; i++)
            {
                Console.WriteLine("({0}) {1}", i + 1, converters[index].Units[i]);
            }
            string tUnit = Console.ReadLine();
            int ToUnit = int.Parse(tUnit) - 1;

            Console.WriteLine("Podaj liczbę do konwersji: ");
            string getValue = Console.ReadLine();
            decimal value = decimal.Parse(getValue);

            decimal result = converters[index].Convert(fromUnit, ToUnit, value);

            Console.WriteLine("Wynik konwersji: " + result);

            Console.ReadKey();
        }
    }
}
