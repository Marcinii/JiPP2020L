using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaBryly
{
    class Prostopadloscian : IBryla 
    {
        public double Objetosc(double PP, string wysokoscH)
        {
            if (double.TryParse(wysokoscH, out double H)) { }
            else H = 0;
            if (H <= 0) return 0;

            return PP * H;
        }

        public string NazwaB => "Prostopadłoscian";
        
    }
}
