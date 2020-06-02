using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaBryly
{
    public class BrylaSerwis
    {
        public List<IBryla> GetBrylas()

        {
            return new List<IBryla>()
            {
                new Ostroslup(),
                new Prostopadloscian()

            };
            
        }
    }
}
