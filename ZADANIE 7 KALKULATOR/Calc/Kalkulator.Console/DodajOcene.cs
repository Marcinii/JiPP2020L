using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator.Console
{
    class DodajOcene
    {
        public static void OcenaDodaj(int ocena, DateTime Data)
        {
            using (Model ocen = new Model())
            {
                TabOcena dewiand = new TabOcena()
                {
                    Ocena = ocena,
                    Czas = Data
                };
                ocen.Ocenki.Add(dewiand);
                ocen.SaveChanges();
            }
        }

    }
}
