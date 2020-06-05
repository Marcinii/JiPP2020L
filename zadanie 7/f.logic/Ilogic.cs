using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_7
{
    public interface Ilogic
    {
      
    }

    public interface Iklient
    {
        string Name { get; }
        List<string> Klienci { get; }
        void klienci(string imie, string nazwisko, string email, string numertele);

    }

    public interface Ikomputery
    {
        string Name { get; }
        List<string> Komputery { get; }
        void komputery(string nazwakompa, string numerseryjny);

    }

}
