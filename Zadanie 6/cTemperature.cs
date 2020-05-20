using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using application;

namespace application
{
	public class cTemperature : iUnit
	{
		public List<string> UnitsList = new List<string>
		{
			"Farenheit --> Celsius",
			"Celsius --> Farenheit"
		};


		List<string> iUnit.UnitsList => throw new NotImplementedException();

		
	}

}