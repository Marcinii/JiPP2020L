using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakty.Logika
{
    public class Empty : ITypKontaktu
    {
        string Nazwisko;
        string Kontakt;
        public string NazwaTypu => "";

        public int NumerTypu => 6;
    }
}
