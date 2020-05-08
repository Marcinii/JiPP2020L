using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public interface IConverterTime
    {
        string Name { get; }
        List<string> UnitsHours { get; }
        List<string> UnitsMinutes { get; }
        decimal Convert(decimal valueToConvert);
    }
}
