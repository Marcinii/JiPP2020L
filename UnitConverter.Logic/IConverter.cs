using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public interface IConverter
    {
        string Name {
            get;
        }

        Dictionary<string, Func<double, double>> UnitsToBasic
        {
            get;
        }

        Dictionary<string, Func<double, double>> UnitsFromBasic
        {
            get;
        }

        Dictionary<string, string> Shortcuts
        {
            get;
        }

        List<string> Units
        {
            get;
        }

        double convert(string unitFrom, string unitTo, double value);
    }
}
