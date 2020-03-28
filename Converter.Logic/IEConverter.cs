using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter
{
    public interface IEConverter
    {
        string Name { get; }
        List<string> Units { get; }

        float ConvertUnit(string from, string to, float Value);
        string ConvertUnit(string from, string to, string Value);
    }
}
