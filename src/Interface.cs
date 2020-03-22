using System;

namespace Project
{
    public interface IKonwerter
    {
        string Name { get; }

        List<string> Units { get; }
        
        void VarUnit(double x, int y);

    }
}
