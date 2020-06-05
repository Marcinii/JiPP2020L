using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterPrzedrostkow;

namespace Konwerter.Logic
{
    public class Lista
    {
        public List<IPrzedrostki> GetKonwerters()
        {
            return new List<IPrzedrostki>()
            {
                new Deka_class(),
                new Hekto_class(),
                new Kilo_class()
            };
        }
    }
}
