using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class kmnac : IConverter
    {
        public string Name => "kilometry na cale";

        public string Konwertuj(string input)
        {
            if (!(decimal.TryParse(input, out decimal l))) { l = 0; } //KM NA CALE
            return (l * (393700787 / 10000)).ToString();
        }
    }
}
