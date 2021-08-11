using System.Collections.Generic;
using System.Text;

namespace Konwerter
{
    public class CelnaFah : Ikonwenter
    {
        public string Nazwa => "T:Cel_Fah";

        public List<string> Jednostki => new List<string>()
        {
            "C",
            "F"
        };

        public double Konwer(string z, string n, double w)
        {
            return (5D / 9 * (w - 32));
        }
    }
}
