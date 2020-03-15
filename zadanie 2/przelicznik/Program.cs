using przelicznik;
using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter
{

    class Konwerter
    {
        static void Main(string[] args)
        {
            List<IConverter> converters = new List<IConverter>()
            {
            new TemperatureConverter(),
            new WeightConverter(),
            new LenghtConverter(),
            new TimeConverter()
            };
            bool shouldContinue = true;
            while (shouldContinue)
            {
                Console.WriteLine("Konwerter jednostek\r\n");
                Console.WriteLine("Jaką operację chcesz wykonać? Wybierz z listy poniżej:\n");
                for (int i = 0; i < converters.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, converters[i].Name);
                }
                string inputChoice = Console.ReadLine();
                double choice = double.Parse(inputChoice);
                Console.Write("Wpisz liczbę początkową: ");
                double liczba = Convert.ToDouble(Console.ReadLine());                
                
                Console.WriteLine(choice);
                if (choice == 1)
                {                  
                    TemperatureConverter conv1 = new TemperatureConverter();
                    Console.WriteLine(converters[0].Choice);
                    double second= Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine($"Twój wynik: {conv1.Convert(second, liczba, 0 )} ");
                }
                if (choice == 2)
                {                
                    WeightConverter conv4 = new WeightConverter();
                    Console.WriteLine(converters[1].Choice);
                    double second = Convert.ToDouble(Console.ReadLine());                  
                    Console.WriteLine($"Twój wynik: {conv4.Convert(second, liczba, 0)} ");
                }
                if (choice == 3)
                {                   
                    LenghtConverter conv7 = new LenghtConverter();
                    Console.WriteLine(converters[2].Choice);
                    double second = Convert.ToDouble(Console.ReadLine());                   
                    Console.WriteLine($"Twój wynik: {conv7.Convert(second, liczba, 0)} ");
                }
                if (choice == 4)
                {                  
                    TimeConverter conv8 = new TimeConverter();
                    Console.WriteLine(converters[3].Choice);
                    double second = Convert.ToDouble(Console.ReadLine());                   
                    Console.WriteLine($"Twój wynik: {conv8.Convert(second, liczba, 0)} ");
                }                        
                }
            }
        }   
    }

