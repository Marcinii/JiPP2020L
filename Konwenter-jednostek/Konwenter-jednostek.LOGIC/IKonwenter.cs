using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter_jednostek
{
    public interface IKonwenter
    {
        string Nazwa { get; }
        string jednostkii { get; }
       

         List<string> Jednostki { get; }

        double Konwertuj(string z, string doo, double a);
    }
}
