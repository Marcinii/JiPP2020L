using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakty
{
    public class Snapchat : ITypKontaktu
    {
        string Nazwisko;
        string Kontakt;

        public string NazwaTypu => "Snapchat";

        public int NumerTypu => 5;
    }
}
