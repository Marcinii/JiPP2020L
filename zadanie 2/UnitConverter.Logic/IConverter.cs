 using System;
using System.Collections.Generic;
using System.Text;

namespace przelicznik
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        string Choice { get; }
        double Convert(double choice, double liczba, double wynik);
        

    }
}
