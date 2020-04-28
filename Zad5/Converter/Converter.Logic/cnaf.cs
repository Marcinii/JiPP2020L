using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class cnaf : IConverter
    {
        public string Name => "celcjusze na farenheity";

        public string Konwertuj(string input)
        {
            if (!(decimal.TryParse(input, out decimal l))) { l = 0; }  // ST CELSUJSZA NA FARENH
            return (l * 9 / 5 + 32).ToString();
        }
    }
}
