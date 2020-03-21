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
        string Result { set; }
        string onConvert(string value, string unitFrom, string unitTo);
    }
}
