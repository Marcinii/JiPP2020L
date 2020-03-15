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

        bool IsInputValid(string inputValue, string sourceUnit);
        string ToBaseUnit(string sourceUnit, string strValue);
        string Convert(string sourceUnit, string targetUnit, string strValue);
    }
}
