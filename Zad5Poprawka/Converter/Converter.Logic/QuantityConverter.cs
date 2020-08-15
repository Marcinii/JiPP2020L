using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class QuantityConverter : IConverter
    {
        public string name => "Ilosci";

        public List<string> Units => new List<string>
        {
            "Sztuka",
            "Tuzin",  // 12 sztuk
            "Gros"   // 144 sztuk
        };

        public decimal Convert(string convertFrom, string convertTo, decimal value)
        {
            {
                if (convertFrom.Equals("Sztuka"))
                {
                    if (convertTo.Equals("Tuzin"))
                    {
                        return value / 12m;
                    }
                    else if (convertTo.Equals("Gros"))
                    {
                        return value / 144m;
                    }
                    Console.WriteLine("Blędne informacje.");
                    return -1;
                }
                else if (convertFrom.Equals("Tuzin"))
                {
                    if (convertTo.Equals("Sztuka"))
                    {
                        return value * 12;
                    }
                    else if (convertTo.Equals("Gros"))
                    {
                        return value / 12 * 144;
                    }
                    Console.WriteLine("Blędne informacje.");
                    return -1;
                }
                else if (convertFrom.Equals("Gros"))
                {
                    if (convertTo.Equals("Sztuka"))
                    {
                        return value / 144;
                    }
                    else if (convertTo.Equals("Tuzin"))
                    {
                        return value / 12;
                    }
                    return -1;
                }
                Console.WriteLine("Blędne informacje.");
                return -1;
            }
        }
    }
}
