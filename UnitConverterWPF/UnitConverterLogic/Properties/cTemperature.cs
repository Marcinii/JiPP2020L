using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class cTemperature : iUnit
	{
		public List<string> UnitsList = new List<string>
		{
			"Farenheit --> Celsius",
			"Celsius --> Farenheit"
		};

	

		List<string> iUnit.UnitsList => throw new NotImplementedException();

		public void convert(int _internalUnitChoice)
		{
			Console.WriteLine("\nEnter value: ");
			double unitValue = Convert.ToDouble(Console.ReadLine());

			switch (_internalUnitChoice)
			{
				case 1: //F->C
					Console.WriteLine(((unitValue - 32) / 1.8) + " [C]" + "\n");
					break;
				case 2: //C->F
					Console.WriteLine(((unitValue * 1.8) + 32) + " [F]" + "\n");
					break;
			}
		}
	}

}