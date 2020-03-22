using System;
using System.Collections.Generic;
using System.Text;

namespace ZAD2
{
    public interface IProgram
    {
        string Name { get; }
        List<string> j_ { get; }
        double Konwersja(string j_z, string j_do, double liczba);
    }
}
