using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book 
{
    public class Private : Ibook
    {
        public string Nazwa => "Kontakty prywatne";

        public List<string> Dane => new List<string>()
        {
            "Nr telefonu", "E-mail", "Data urodzin"
        };
    }
}
