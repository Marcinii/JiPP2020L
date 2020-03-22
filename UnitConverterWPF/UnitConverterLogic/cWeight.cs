using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    public class cWeight : iUnit
    {
        public List<string> UnitsList => new List<string>
        {
            "kg --> pounds",
            "pounds --> kg"
        };

        public void convert(int _internalUnitChoice)
        {
            Console.WriteLine("\nEnter value: ");
            double unitValue = Convert.ToDouble(Console.ReadLine());

            switch (_internalUnitChoice)
            {
                case 1: //pounds->kg
                    Console.WriteLine(unitValue / 2.2046 + " kg(s)" + "\n");
                    break;
                case 2: // kg->pounds
                    Console.WriteLine(unitValue * 2.2046 + " pound(s)" + "\n");
                    break;
            }
        }

    }
}