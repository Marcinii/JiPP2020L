using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakty
{
    public class Email : ITypKontaktu
    {
        string Nazwisko;
        string Kontakt;

        public string NazwaTypu => "Adres e-mail";

        public int NumerTypu => 2;
    }
}
