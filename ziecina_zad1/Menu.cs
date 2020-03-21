using System;
using System.Collections.Generic;
using System.Text;

namespace ziecina_zad1
{
    public class Menu
    {
        public Menu()
        {
            List<IConverter> convList = new List<IConverter>()
            {
                new ConvertTemperature(),
                new ConvertMass(),
                new ConvertLength(),
                new ConvertVolume()
            };
            Console.WriteLine("KONWERTER JEDNOSTEK\n\nWybierz jednostkę (1 - {0}):", convList.Count);
            for(int i = 0; i < convList.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i+1, convList[i].Name);
            }
            string chosenConverterStr = Console.ReadLine();
            int chosenConverterInt = Convert.ToInt32(chosenConverterStr);
            chosenConverterInt -= 1; //żeby była ta sama numeracja
            if (chosenConverterInt < convList.Count)
            {
                Console.WriteLine("\nWybierz jednostkę z której będziesz przeliczał (1 - {0}):", convList[chosenConverterInt].Units.Count);
                for(int i = 0; i < convList[chosenConverterInt].Units.Count; i ++)
                {
                    Console.WriteLine("{0}. {1}", i + 1, convList[chosenConverterInt].Units[i]);
                }
                int startUnit = Convert.ToInt32(Console.ReadLine()) - 1;
                if(startUnit < convList[chosenConverterInt].Units.Count)
                {
                    Console.WriteLine("\nWybierz jednostkę na którą będziesz przeliczał (1 - {0}):", convList[chosenConverterInt].Units.Count);
                    for (int i = 0; i < convList[chosenConverterInt].Units.Count; i++)
                    {
                        Console.WriteLine("{0}. {1}", i + 1, convList[chosenConverterInt].Units[i]);
                    }
                    int endUnit = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (startUnit < convList[chosenConverterInt].Units.Count)
                    {
                        Console.WriteLine("Podaj liczbę którą chcesz przeliczyć:");
                        String value = Console.ReadLine();
                        float resault = convList[chosenConverterInt].Convert(convList[chosenConverterInt].Units[startUnit], convList[chosenConverterInt].Units[endUnit], value);
                        Console.WriteLine("{0} {1} to {2} {3}.",value , convList[chosenConverterInt].Units[startUnit], resault, convList[chosenConverterInt].Units[endUnit]);
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawny wybór");
                    }
                }
                else
                {
                    Console.WriteLine("Niepoprawny wybór");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór");
            }
        }
    }
}
