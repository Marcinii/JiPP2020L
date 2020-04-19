using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class TimeKonwerter : IKonwerter
    {
        public string Name => "Konwerter czasu";

        public List<string> Units => new List<string>(){"AM/PM",""};

        public double VarUnit(double x, int y)
        {
            char[] s = new char [2];
            x.ToString().CopyTo(x.ToString().Length - 2, s, 0, 2);
            double t1 = 0, t2 = Convert.ToDouble(new string (s));
            if (x.ToString().Length > 2) t1 = Convert.ToDouble(x.ToString().Remove(x.ToString().Length - 2));
            if (y == 0)
            {
                if(t1 > 12)
                {
                    t1 = t1 - 12;
                }
                x = t1 * 100 + t2;
                return x;
            }
            else if(y == 1)
            {
                return x;
            }
            else if(y == 2)
            {
                if (t1 == 12) return t2;
                x = (t1 + 12) * 100 + t2;
                return x;
            }
            else
            {
                return 0;
            }

        }
    }
}
