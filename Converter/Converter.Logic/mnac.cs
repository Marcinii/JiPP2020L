using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class mnac : IConverter
    {
        public string Name => "mile na cale";

        public string Konwertuj(string input)
        {
            if (!(decimal.TryParse(input, out decimal l))) { l = 0; } //MILE NA CALE
            return (l * 63360).ToString();
        }
    }
}
