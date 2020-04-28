using System;
using System.Collections.Generic;

namespace Project
{
    public interface IKonwerter
    {
        string Name { get; }

        List<string> Units { get; }
        
        double VarUnit(double x, int y);

    }
}
