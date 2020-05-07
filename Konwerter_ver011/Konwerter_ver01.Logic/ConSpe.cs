using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_ver01
{
    public class ConSpe :IConverter
    {
        public string Name => "Prędkości";

        public List<string> Jedn => new List<string>()
        {
        "km/h", "m/s"
        };


        public string Convert(string JednZ, string JednDo, string Dane)
        {
            double Wart = double.Parse(Dane);
            if (JednZ == "km/h")
            { 
                if (JednDo == "m/s")
                {
                    return (Wart * 0.2778).ToString();
                }
                if (JednDo == "km/h") { return Wart.ToString(); }
                else Console.WriteLine("Program nie obsługuje konwersji z {0} do {1}. ", JednZ, JednDo);
            }
            if (JednZ == "m/s")
            {
                if (JednDo == "km/h")
                {
                    return (Wart *3.6).ToString();
                }
                if (JednDo == "m/s") { return Wart.ToString(); }
                else Console.WriteLine("Program nie obsługuje konwersji z {0} do {1}. ", JednZ, JednDo);
            }
            else Console.WriteLine("Program nie obsługuje konwersji z {0} do {1}. ", JednZ, JednDo); return "";
        }
    }
}
