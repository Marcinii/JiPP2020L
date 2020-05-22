using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class kmnam : IConverter
    {
        public string Name => "kilometry na mile";

        public string Konwertuj(string input)
        {
            if (!(decimal.TryParse(input, out decimal l))) { l = 0; } //KM NA MILE
            return (l / (161 / 100)).ToString();
        }
    }
}
