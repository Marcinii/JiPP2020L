using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    public class KonwerterSerwis
    {
        public List<IKonwerter> GetConverters()
        
        {
            return new List<IKonwerter>()
            {
                new Temperatura(),
                new Masa(),
                new Objetosc(),
                new Odleglosc(),
                new Czas()
            };
        }

    }
}
