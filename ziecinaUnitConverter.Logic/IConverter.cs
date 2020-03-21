using System;
using System.Collections.Generic;
using System.Text;

namespace ziecina_zad1
{
    public interface IConverter
    {
        string Name
        {
            get;
        }
        List<string> Units
        {
            get;
        }
        float Convert(string startUntit, string endUnit, string value);
    }
}

