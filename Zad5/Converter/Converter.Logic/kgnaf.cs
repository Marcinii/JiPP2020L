using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class kgnaf : IConverter
    {
        public string Name => "kilogramy na funty";

        public string Konwertuj(string input)
        {
            if (!(decimal.TryParse(input, out decimal l))) { l = 0; } //KG NAFUNTY
            return (l * (2205 / 1000)).ToString();
        }
    }
}
