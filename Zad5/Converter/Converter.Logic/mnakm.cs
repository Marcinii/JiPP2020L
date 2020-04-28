using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class mnakm : IConverter
    {
        public string Name => "mile na kilometry";

        public string Konwertuj(string input)
        {
            if (!(decimal.TryParse(input, out decimal l))) { l = 0; }//MILE NA KM
            return (l * (161 / 100)).ToString();
        }
    }
}
