using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_converter
{
    public interface IConverter
    {
        string Name { get; }
        List<string> AvailableUnits { get; }

        bool IsInputValid(string inputValue);
        double ToBaseUnit(string sourceUnit, double value);
        double Convert(string sourceUnit, string targetUnit, double value);
    }
}
