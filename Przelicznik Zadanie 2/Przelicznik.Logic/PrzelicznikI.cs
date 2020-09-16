using System;
using System.Collections.Generic;
using System.Text;

namespace Przelicznik.Logic
{
    public interface PrzelicznikI
    {   
        string Name { get; }
        List<string> jednostka { get; }
        double przelicz(string jednostka1, string jednostka2, double liczba);
        string przeliczCzas(string czas);
    }
}
