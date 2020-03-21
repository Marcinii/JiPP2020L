using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_ver01
{
    public class ConOdl : IConverter
    {
        public string Name => "Odległości";

        public List<string> Jedn => new List<string>()
        {
        "km", "mi", "m"
        };
        public double Convert(string JednZ, string JednDo, double Wart)
        {
            if (JednZ == "km" || JednZ == "kilometr")
            {
                if (JednDo == "mi" || JednDo == "mila")
                {
                    return Wart * 0.62137;
                }
                if (JednDo == "m" || JednDo == "metr")
                {
                    return Wart *1000;
                }
                else Console.WriteLine("Program nie obsługuje konwersji z {0} do {1}. ", JednZ, JednDo);
            }
            if (JednZ == "mi" || JednZ == "mila")
            {
                if (JednDo == "km" || JednDo == "kilometr")
                {
                    return Wart / 0.62137;
                }
                if (JednDo == "m" || JednDo == "metr")
                {
                    return (Wart / 0.62137)*1000;
                }
                else Console.WriteLine("Program nie obsługuje konwersji z {0} do {1}. ", JednZ, JednDo);
            }
            if (JednZ == "m" || JednZ == "metr")
            {
                if (JednDo == "km" || JednDo == "kilometr")
                {
                    return Wart /1000;
                }
                if (JednDo == "mi" || JednDo == "mila")
                {
                    return (Wart /1000) * 0.62137;
                }
                else Console.WriteLine("Program nie obsługuje konwersji z {0} do {1}. ", JednZ, JednDo);
            }
            else Console.WriteLine("Program nie obsługuje konwersji z {0} do {1}. ", JednZ, JednDo); return 0;
        }
    }
}
