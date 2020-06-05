using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_7
{
    class komp : Ikomputery
    {
        public string Name => "Komputery";

        public List<string> Komputery => new List<string>()
        {
            "Laptopy",
            "Stacjonarki",
            "Mac"
        };

        public void komputery(string nazwakompa, string numerseryjny)
        {

            
        }
    }
}
