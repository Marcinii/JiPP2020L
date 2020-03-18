using System;

namespace Project
{
    public interface IKonwerter
    {
        public string Name { get; }

        public List<string> Units { get; }
        
        public void VarUnit(double x, int y);

    }
}
