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
            Console.WriteLine(DateTime.Now);
            DisplayDataEF();
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
                CONVERSIONS conversion = new CONVERSIONS();
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
                        conversion.name = converterList[0].ConverterName;
                        showUnitsAndConvert(converterList[0], conversion);
                        break;
                    case 2:
                        conversion.name = converterList[1].ConverterName;
                        showUnitsAndConvert(converterList[1], conversion);
                        break;
                    case 3:
                        conversion.name = converterList[2].ConverterName;
                        showUnitsAndConvert(converterList[2], conversion);
                        break;
                    case 4:
                        conversion.name = converterList[3].ConverterName;
                        showUnitsAndConvert(converterList[3], conversion);
                        break;
                    default:
                        Console.WriteLine("Wybrano nieprawidłową opcję");
                        isRunning = false;
                        break;
                }
            }

        }

        public static void showUnitsAndConvert(IConverter converter, CONVERSIONS conversionDb)
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
            conversionDb.unitFrom = chooseFrom;

            Console.WriteLine("Wpisz jednostke, na ktora chcesz zamienic:");
            chooseTo = Console.ReadLine();
            conversionDb.unitTo = chooseTo;

            Console.WriteLine("Wpisz ilosc:");
            quantity = Console.ReadLine();
            conversionDb.valueToConvert = quantity;
            string result = converter.onConvert(quantity, chooseFrom, chooseTo);
            conversionDb.valueAfterConvert = result;
            conversionDb.dateOfConversion = DateTime.Now;

            InsertDataEF(conversionDb);
            Console.WriteLine(result + " {0}", chooseTo);
        }

        public static void DisplayDataEF()
        {
            using(CONVERTER_DBEntities context = new CONVERTER_DBEntities())
            {
                List<CONVERSIONS> conv = context.CONVERSIONS.ToList();

                foreach(CONVERSIONS c in conv)
                {
                    Console.WriteLine(c.name);
                }
            }
        }

        public static void InsertDataEF(CONVERSIONS conv)
        {
            using (CONVERTER_DBEntities context = new CONVERTER_DBEntities())
            {
                //Console.WriteLine(conv.name+conv.unitFrom+conv.unitTo+conv.valueAfterConvert);

                context.CONVERSIONS.Add(conv);
                context.SaveChanges();
            }
        }
    }
}