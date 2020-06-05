using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_7
{
    class osoby : Iklient
    {
        public string Name => "Klienci";

        public List<string> Klienci => new List<string>()
        {
            "Mazowsze",
            "Podlasie",
            "Małopolskie"
        };


        public void klienci(string imie, string nazwisko, string email, string numertele)
        {


        }
   


    }
}
