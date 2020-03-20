using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public interface IConverter
    {
        string Name { get; }

        List<string> Units { get; }

        double Convert(int from, int to, double valueToConvert);




        //Enum typesOfUnits { get; }
        //void TypesOfUnits(Enum typesOfUnits);
        //    T ValuesInEnum { get; set; }
    }
}
