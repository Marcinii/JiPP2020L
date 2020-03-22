using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
public class JiPP
{
    public static void Main(string[] args)
    {
        bool isTrue = true;
        int internalUnitChoice = 0;

        while (isTrue)
        {
            int answer = 0;
            Console.WriteLine("Unit to convert:\n1 - time \n2 - temperature \n3 - distance \n4 - weight");
            int externalchoice = Convert.ToInt32(Console.ReadLine());
            cUnitFactory factory = new cUnitConcreteFactory(); // utworzylismy obiekt ogólny danej klasy

            switch (externalchoice)
            {
                case 1:
                    {
                        iUnit time = factory.unitBuilder(externalchoice);
                        Console.WriteLine("1 - minutes --> hours \n2 - hours --> minutes");
                        internalUnitChoice = Convert.ToInt32(Console.ReadLine());
                        time.convert(internalUnitChoice);
                        internalUnitChoice = 0;
                    }
                    break;
                case 2:
                    iUnit temperature = factory.unitBuilder(externalchoice);
                    Console.WriteLine("1 - Farenheit --> Celsius \n2 - Celsisu --> Farenheit");
                    internalUnitChoice = Convert.ToInt32(Console.ReadLine());
                    temperature.convert(internalUnitChoice);
                    internalUnitChoice = 0;
                    break;
                case 3:
                    iUnit distance = factory.unitBuilder(externalchoice);
                    Console.WriteLine("1 - miles --> km \n2 - km --> miles \n3 - m --> mm \n4 - mm --> m");
                    internalUnitChoice = Convert.ToInt32(Console.ReadLine());
                    distance.convert(internalUnitChoice);
                    internalUnitChoice = 0;
                    break;
                case 4:
                    iUnit weight = factory.unitBuilder(externalchoice);
                    Console.WriteLine("1 - pounds --> kg(s) \n2 - kg --> pounds");
                    internalUnitChoice = Convert.ToInt32(Console.ReadLine());
                    weight.convert(internalUnitChoice);
                    internalUnitChoice = 0;
                    break;
                default:
                    Console.WriteLine("\nMEWOerror (=^･ｪ･^=))∫ \n");
                    internalUnitChoice = 0;
                    break;
            }

            Console.WriteLine("Convert again? \n1 - yes \n2 - no");
            answer = Convert.ToInt32(Console.ReadLine());
            if (answer == 2)
            {
                Console.WriteLine("Converter shutdown.");
                break;
            }
            else
                continue;

        }

    }
}

}