using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class cDistance : iUnit
    {

        public List<string> UnitsList = new List<string>
        {
            "km --> miles",
            "miles --> km",
            "m --> mm",
            "mm --> m"
        };

        List<string> iUnit.UnitsList => throw new NotImplementedException();

        public void convert(int _internalUnitChoice)
        {
            Console.WriteLine("\nEnter value: ");
            double unitValue = Convert.ToDouble(Console.ReadLine());

            switch (_internalUnitChoice)
            {
                case 1: //miles-> km
                    Console.WriteLine(unitValue * 0.62137 + " mile(s)" + "\n");
                    break;
                case 2: // km->miles
                    Console.WriteLine(unitValue / 0.62137 + " km(s)" + "\n");
                    break;
                case 3: //m->mm
                    Console.WriteLine(unitValue * 1000 + " mm" + "\n");
                    break;
                case 4: // mm->m
                    Console.WriteLine(unitValue / 1000 + " m" + "\n");
                    break;
            }
        }
    }
}