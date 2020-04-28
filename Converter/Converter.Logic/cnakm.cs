using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class cnakm : IConverter
    {
        public string Name => "cale na kilometry";

        public string Konwertuj(string input)
        {
            if (!(decimal.TryParse(input, out decimal l))) { l = 0; } // CALE NA KILOMETRY
            return (l / (393700787 / 10000)).ToString();
        }
    }
}
