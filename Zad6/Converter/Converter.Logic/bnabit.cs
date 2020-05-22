using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class bnabit : IConverter
    {
        public string Name => "bajty na bity";

        //public decimal wartosc;
        //public bnabit() { wartosc = 0; }
        public string Konwertuj(string input)
        {
            if (!(decimal.TryParse(input, out decimal l))) { l = 0; } //BAJT NA BIT
            return (l * 8).ToString();
        }
    }
}
