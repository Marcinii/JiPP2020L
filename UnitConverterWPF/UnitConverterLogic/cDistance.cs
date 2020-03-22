using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    public class cDistance : iUnit
    {
        public List<string> UnitsList => new List<string>
        {
            "km --> miles",
            "miles --> km",
            "m --> mm",
            "mm --> m"
        };

        public void convert(int _internalUnitChoice, double unitValue)
        {
            Console.WriteLine("\nEnter value: ");
          //  unitValue = Convert.ToDouble(Console.ReadLine());
            double outcome = 0.0;
            switch (_internalUnitChoice)
            {
                case 1: //miles-> km
                    outcome = unitValue * 0.62137;
                    break;
                case 2: // km->miles
                    outcome = unitValue / 0.62137;
                    break;
                case 3: //m->mm
                    outcome = unitValue * 1000;
                    break;
                case 4: // mm->m
                    outcome = unitValue / 1000;
                    break;
            }

         
        }

        public void convert(int choice)
        {
            throw new NotImplementedException();
        }
    }
}