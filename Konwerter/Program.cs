using System;
using System.Collections.Generic;

namespace Konwerter
{
    class Program
    {
        static void Main(string[] args)
        {

             List<IEConverter> Converters = new List<IEConverter>()
            {
                new WeightConverter(),
                new LengthConverter(),
                new TempConverter(),
                new VolumeConverter()

            };

            Console.WriteLine("Wpisz odpowiednią nazwe konwertera");

            foreach (IEConverter converter in Converters)
            {
                Console.WriteLine(converter.Name);
            }

            string name = Console.ReadLine();
            Console.WriteLine("Wartość do konwersji");
            float value = float.Parse(Console.ReadLine());
            Console.WriteLine("Z jakiej jednostki konwertujemy?");
            string from = Console.ReadLine();
            Console.WriteLine("Do jakiej jednostki konwertujemy?");
            string to = Console.ReadLine();

            switch (name) 
            {
                case "Waga":
                    Converters[0].ConvertUnit(from,to,value);
                    break;
                case "Temperatury":
                    Converters[2].ConvertUnit(from, to, value);
                    break;
                case "Dlugosc":
                    Converters[1].ConvertUnit(from, to, value);
                    break;
                case "Pojemnosc":
                    Converters[3].ConvertUnit(from, to, value);
                    break;
            }
        }

        
}
       
}
