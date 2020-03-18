using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IConverter
    {
        string ConverterName { get; }
        List<string> ConverterUnits { get; }
        double Result { set; }
        double onConvert(double value, string unitFrom, string unitTo);
    }
}
