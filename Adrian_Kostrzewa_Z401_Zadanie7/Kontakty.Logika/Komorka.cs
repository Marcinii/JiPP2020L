using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakty
{
    public class Komorka : ITypKontaktu
    {
        string Nazwisko;
        string Kontakt;

        public string NazwaTypu => "Telefon komórkowy";

        public int NumerTypu => 3;
    }
}
