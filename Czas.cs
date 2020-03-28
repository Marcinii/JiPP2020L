using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD3
{
    public class Czas
    {
        string Name => "Czas";

        
        public double Z24hna12h(int h, int min, bool CzyAM, bool Czy24h)
        {
            double hmin = 0;
            if (Czy24h == true)
            {
                if (h > 12)
                {
                    h = h - 11;
                    CzyAM = false;
                    hmin = (double)h + ((double)min / 100);
                    return hmin;

                }
                else if (h <= 12)
                {
                    h = h + 1;
                    CzyAM = true;
                    hmin = (double)h + ((double)min / 100);
                    return hmin;
                }
                else { return 0; }
            }
            else if (Czy24h == false)
            {
                if (CzyAM == false)
                {
                    h = h + 13;
                    hmin = (double)h + ((double)min / 100);
                    return hmin;
                }
                else if (CzyAM == true)
                {
                    h = h + 1;
                    hmin = (double)h + ((double)min / 100);
                    return hmin;
                }
                else
                { return 0; }
            }
            else
            { return 0; }
        }
    }
}
