using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter
{
    public interface Ikonwenter
    {
        string Nazwa { get; }
        List<string> Jednostki { get; }
        double Konwer(string z, string n, double wartowsc);
    }
}
