using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public interface IConverter
    {
        string Konwertuj(string input);
        string Name { get; }
    }
}
