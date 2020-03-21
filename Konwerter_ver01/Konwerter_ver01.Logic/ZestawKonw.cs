using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_ver01
{
    public class ZestawKonw 
    {
        public List<IConverter> GetConverter()
        {
            return new List<IConverter>()
            {
                new ConTemp(),
                new ConOdl(),
                new ConWag(),
                new ConSpe()
            };
        }
    }
}
