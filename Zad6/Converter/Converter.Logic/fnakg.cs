using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class fnakg : IConverter
    {
        public string Name => "funty na kilogramy";

        public string Konwertuj(string input)
        {
            if(!(decimal.TryParse(input, out decimal l))) { l = 0; } //FUNTY NA KILOGRAMY
            return (l / (2205 / 1000)).ToString();
        }
    }
}
