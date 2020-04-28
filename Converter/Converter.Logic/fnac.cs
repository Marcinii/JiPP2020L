using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class fnac : IConverter
    {
        public string Name => "farenheity na celcjusze";

        public string Konwertuj(string input)
        {
            if (!(decimal.TryParse(input, out decimal l))) { l = 0; } //FARENHEIT NACELSJSZE
            return ((l - 32) * 5 / 9).ToString();
        }
    }
}
