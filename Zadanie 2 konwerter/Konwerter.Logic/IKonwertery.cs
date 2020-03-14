using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Logic
{
    public interface IKonwertery
    {
        double Wynik { get; }
        void Konwertuj_i_Pokaz(string z_jednostki, string do_jednostki, double dana);
        double Konwertuj(string z_jednostki, string do_jednostki, double dana);
    }
}
