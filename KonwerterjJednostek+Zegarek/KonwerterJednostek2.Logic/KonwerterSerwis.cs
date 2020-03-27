using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterjJednostek2;


namespace KonwerterjJednostek2.Logic
{
    public class KonwerterSerwis
    {
        public List<IKonwerter> GetKonwerters()
        {
            return new List<IKonwerter>()
            {
                new Temperatura_class(),
                new Odleglosc_class(),
                new Masa_class(),
                new Czas_class(),
                new Format_12_24_class()               
            };
        }
    }
}
