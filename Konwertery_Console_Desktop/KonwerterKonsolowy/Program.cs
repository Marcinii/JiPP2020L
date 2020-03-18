using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace KonwerterKonsolowy
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            string choose;

            List<IConverter> converterList = new List<IConverter>
            {
                new LenghtConversion(),
                new WeightConversion(),
                new TemperatureConversion(),
                new PowerConversion()
            };

            while(isRunning)
            {
                int counter = 0;
                Console.WriteLine("Konwerter jednostek. Wybierz kategorię:");
                foreach( IConverter converter in converterList)
                {
                    Console.WriteLine(++counter + " " + converter.ConverterName);
                }
                choose = Console.ReadLine();
                

                switch(Int16.Parse(choose))
                {
                    case 1:
                        showUnitsAndConvert(converterList[0]);
                        break;
                    case 2:
                        showUnitsAndConvert(converterList[1]);
                        break;
                    case 3:
                        showUnitsAndConvert(converterList[2]);
                        break;
                    case 4:
                        showUnitsAndConvert(converterList[3]);
                        break;
                    default:
                        Console.WriteLine("Wybrano nieprawidłową opcję");
                        isRunning = false;
                        break;
                }
            }

        }

        public static void showUnitsAndConvert(IConverter converter)
        {
            string chooseFrom;
            string chooseTo;
            string quantity;
            Console.WriteLine("Dostępne jednostki:");
            foreach(string unit in converter.ConverterUnits)
            {
                Console.WriteLine(unit);
            }
            Console.WriteLine("Wpisz jednostke, z ktorej zamieniasz:");
            chooseFrom = Console.ReadLine();
            Console.WriteLine("Wpisz jednostke, na ktora chcesz zamienic:");
            chooseTo = Console.ReadLine();
            Console.WriteLine("Wpisz ilosc:");
            quantity = Console.ReadLine();
            Console.WriteLine(converter.onConvert(Double.Parse(quantity), chooseFrom, chooseTo) + " {0}", chooseTo);
        }
    }
}