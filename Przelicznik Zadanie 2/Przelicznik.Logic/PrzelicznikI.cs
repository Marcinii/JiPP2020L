using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
   public interface PrzelicznikI
    {   
        string Name { get; }
        List<string> jednostka { get; }
        double przelicz(string jednostka1, string jednostka2, double liczba);
    }
}
