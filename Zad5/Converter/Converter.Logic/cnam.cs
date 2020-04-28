using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class cnam : IConverter
    {
        public string Name => "cale na mile";

        public string Konwertuj(string input)
        {
            if (!(decimal.TryParse(input, out decimal l))) { l = 0; } // CALE NA MILE
            return (l / 63360).ToString();
        }
    }
}
