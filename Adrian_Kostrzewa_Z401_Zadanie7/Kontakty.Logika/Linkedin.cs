using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakty
{
    public class Linkedin : ITypKontaktu
    {
        string Nazwisko;
        string Kontakt;

        public string NazwaTypu => "Linkedin";

        public int NumerTypu => 4;
    }
}
