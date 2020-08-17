using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_7
{
   public class kwadrat : Ifigury
    {
        public string nazwa => "Kwadrat";

        public List<string> what => new List<string>() {
        
                "obwód",
                "pole"
        };

        public double oblicz(string ktory, double a,double b,double c, double h)
        {
           if(ktory == "obwód")
            {
                return obwod(a);
            }
            else
            {
                return pole(a);
            }
        }
        private double obwod(double a)
        {
            return 4 * a;
        }
        private double pole(double a)
        {
            return a * a;
        }
    }
}
