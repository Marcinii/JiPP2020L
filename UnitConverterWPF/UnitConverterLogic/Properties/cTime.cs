using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class cTime : iUnit
    {
        public List<string> UnitsList = new List<string>
        {
            "hours --> minutes",
            "minutes --> hours"
        };

        List<string> iUnit.UnitsList => throw new NotImplementedException();

        public void convert(int _internalUnitChoice)
        {
            Console.WriteLine("\nEnter value: ");
            double unitValue = Convert.ToDouble(Console.ReadLine());

            switch (_internalUnitChoice)
            {
                case 1:
                    Console.WriteLine(unitValue / 60 + " hour(s)" + "\n");
                    break;
                case 2:
                    Console.WriteLine(unitValue * 60 + " minute(s)" + "\n");
                    break;
            }

        }

        void iUnit.convert(int choice)
        {
            throw new NotImplementedException();
        }
    }
}