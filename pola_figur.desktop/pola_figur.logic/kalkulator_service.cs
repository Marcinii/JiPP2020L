using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pola_figur.logic
{
    public class kalkulator_service
    {
        public List<IPola_figur> DajKonwertery()
        {
            return new List<IPola_figur>()
            {
                new Kolo(),
                new Kwadrat()
            };
        }
    }
}
