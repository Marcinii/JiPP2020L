using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public class KonwerterSerwis
    {
        public List<Ikonwenter> NazwyK()
        {
            return new List<Ikonwenter>()
            {
                new CelnaFah(),
                new FahnaCel(),
                new FunnaKil(),
                new KilnaFun(),
                new KMnaM(),
                new MnaKM(),
                new KMHnaMPH(),
                new MPHnaKMH()
            };
        }
    }
}