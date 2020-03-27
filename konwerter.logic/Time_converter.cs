using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter.logic
{
      public class time_converter : IkonwTime
    {
        
        public decimal ConvTime(int godz, int min)
        {
            if (godz == 24)
                godz = 0;
            else if (godz > 12)
                godz -= 12;  
     
            return godz ;

        }



    }
}
