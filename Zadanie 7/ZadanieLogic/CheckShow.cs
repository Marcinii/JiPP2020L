using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieLogic
{
    public class CheckShow
    {
        public List<IChecker> GetCheck()
        {
            return new List<IChecker>()
            {
                new Podzielnosc()
            };
        }
    }
}
