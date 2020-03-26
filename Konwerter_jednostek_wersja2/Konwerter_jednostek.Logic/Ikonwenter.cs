using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek_wersja2
{
    public interface Ikonwenter
    {
        string Name { get; }
        List<string> Units { get; }
        string Convert(string unitFrom, string unitTo, string valueToConvert);
       
        //string Convert(string unitFrom, string unitTo, string valueToConvert);
    }
}
