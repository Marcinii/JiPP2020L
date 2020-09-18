using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kontakty.Logika;

namespace Kontakty.Logika
{
    public class KontaktySerwis
    {
        public List<ITypKontaktu> NazwyTypow()
        {
            return new List<ITypKontaktu>()
            {
                new Dom(),
                new Email(),
                new Komorka(),
                new Linkedin(),
                new Snapchat()
            };
        }
        public List<ITypKontaktu> NazwyTypow2()
        {
            return new List<ITypKontaktu>()
            {
                new Dom(),
                new Email(),
                new Komorka(),
                new Linkedin(),
                new Snapchat(),
                new Empty()
            };
        }
    }
}
