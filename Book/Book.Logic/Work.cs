using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class Work : Ibook
    {
        public string Nazwa => "Kontakty służbowe";

        public List<string> Dane => new List<string>()
        {
            "Firma", "Nr telefonu", "E-mail" 
        };
    }
}
