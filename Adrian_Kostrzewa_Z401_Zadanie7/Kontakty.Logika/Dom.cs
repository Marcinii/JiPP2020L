using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakty
{
    public class Dom : ITypKontaktu
    {
        string Nazwisko;
        string Kontakt;
        public string NazwaTypu => "Telefon domowy";

        public int NumerTypu => 1;
    }
}
