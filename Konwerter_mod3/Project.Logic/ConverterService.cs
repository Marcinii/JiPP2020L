using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class ConverterService
    {
        public List<IKonwerter> GetConverters()
        {
            return new List<IKonwerter>()
            {
                new LenKonwerter(),
                new TempKonwerter(),
                new MassKonwerter(),
                new PowKonwerter(),
                new TimeKonwerter()
            };
        }
    }
}
