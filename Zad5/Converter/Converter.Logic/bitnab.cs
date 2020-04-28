using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class bitnab : IConverter
    {
        public string Name => "bity na bajty";

        public string Konwertuj(string input)
        {
            if (!(decimal.TryParse(input, out decimal l))) { l = 0; } //KONWERTER Z BITU NA BAJT
            return (l / 8).ToString();

        }
    }
}
