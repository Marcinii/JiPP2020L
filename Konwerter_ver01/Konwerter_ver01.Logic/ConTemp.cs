using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_ver01
{
    public class ConTemp : IConverter
    {
        public string Name => "Temperatury";

        public List<string> Jedn => new List<string>()
        {
        "C", "F", "K"
        };


        public double Convert (string JednZ, string JednDo,  double Wart)
        {
            if (JednZ == "C" || JednZ == "c")
            {
                if (JednDo == "F" || JednDo == "f")
                {
                    return Wart * 1.8 + 32;
                }
                if (JednDo == "K" || JednDo == "k")
                {
                    return Wart + 273.15;
                }
                if (JednDo == "C" || JednDo == "c") { return Wart; }
                else Console.WriteLine("Program nie obsługuje konwersji z {0} do {1}. ", JednZ, JednDo);
            }
            if (JednZ == "F" || JednZ == "f")
            {
                if (JednDo == "C" || JednDo == "c")
                {
                    return (Wart - 32) / 1.8;
                }
                if (JednDo == "K" || JednDo == "k")
                {
                    return (Wart - 32) / 1.8 + 273.15;
                }
                if (JednDo == "F" || JednDo == "f") { return Wart; }
                else Console.WriteLine("Program nie obsługuje konwersji z {0} do {1}. ", JednZ, JednDo);
            }
            if (JednZ == "K" || JednZ == "k")
            {
                if (JednDo == "C" || JednDo == "c")
                {
                    return Wart - 273.15;
                }
                if (JednDo == "F" || JednDo == "f")
                {
                    return ((Wart - 273.15) -32) / 1.8;
                }
                if (JednDo == "K" || JednDo == "k") { return Wart; }
                else Console.WriteLine("Program nie obsługuje konwersji z {0} do {1}. ", JednZ, JednDo);
            }
            else Console.WriteLine("Program nie obsługuje konwersji z {0} do {1}. ", JednZ, JednDo); return 0;
        }
    }
}
