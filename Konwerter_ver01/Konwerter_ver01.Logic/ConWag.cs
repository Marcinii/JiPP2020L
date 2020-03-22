using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_ver01
{
    public class ConWag : IConverter
    {
        public string Name => "Wagi";

        public List<string> Jedn => new List<string>()
        {
        "kg", "funt", "tona"
        };

        public double Convert(string JednZ, string JednDo, double Wart)
        {
            if (JednZ == "kg" || JednZ == "kilogram")
            {
                if (JednDo == "f" || JednDo == "funt")
                {
                    return Wart * 2.2046;
                }
                if (JednDo == "t" || JednDo == "tona")
                {
                    return Wart / 1000;
                }
                if (JednDo == "kg" || JednDo == "kilogram") { return Wart; }
                else Console.WriteLine("Program nie obsługuje konwersji z {0} do {1}. ", JednZ, JednDo);
            }
            if (JednZ == "f" || JednZ == "funt")
            {
                if (JednDo == "kg" || JednDo == "kilogram")
                {
                    return Wart / 2.2046;
                }
                if (JednDo == "t" || JednDo == "tona")
                {
                    return (Wart / 2.2046) / 1000;
                }
                if (JednDo == "f" || JednDo == "funt") { return Wart; }
                else Console.WriteLine("Program nie obsługuje konwersji z {0} do {1}. ", JednZ, JednDo);
            }
            if (JednZ == "t" || JednZ == "tona")
            {
                if (JednDo == "kg" || JednDo == "kilogram")
                {
                    return Wart * 1000;
                }
                if (JednDo == "f" || JednDo == "funt")
                {
                    return (Wart / 1000) * 2.2046;
                }
                if (JednDo == "t" || JednDo == "tona") { return Wart; }
                else Console.WriteLine("Program nie obsługuje konwersji z {0} do {1}. ", JednZ, JednDo);
            }
            else Console.WriteLine("Program nie obsługuje konwersji z {0} do {1}. ", JednZ, JednDo); return 0;
        }
    }
}
