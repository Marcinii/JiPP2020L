using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
	public interface iUnit
	{
		void convert(int choice);

		List<string> UnitsList { get; }
    }
}