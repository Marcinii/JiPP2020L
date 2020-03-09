using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter
{
    public interface IConverter
    {
        decimal Convert();
        List<string> Units { get;}
        void List_unit();
        void GiveResult();
        string name { get; }
        void Data_and_convert(string from_type, string to_type, decimal value);
    }
}