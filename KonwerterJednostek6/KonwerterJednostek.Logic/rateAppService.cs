using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class rateAppService
    {
        int rateAppValue;

        public int GetValue()
        {
            statystykiEntities1 db = new statystykiEntities1();
            List<rate> r = db.rate.ToList();
            foreach(rate rate in r)
            {
                rateAppValue = rate.rateValue ?? default(int);
            }
            return rateAppValue;
        }
    }
}
