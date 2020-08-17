using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_7
{
    public class trojkat : Ifigury
    {
        public string nazwa => "Trójkąt";

        public List<string> what => new List<string>()
        {
            "pole",
            "obwód"
        };


        public double oblicz(string ktory,double a,double b, double c, double h)
        {
            if(ktory == "pole")
            {
                return pole(a, h);
            }else
            {
                return obwod(a, b, c);
            }
        }

        public double pole(double a, double h)
        {
            return (a * 0.5) * h;
        }
        public double obwod(double a, double b,double c)
        {
            return a + b + c;
        }
    }
}
