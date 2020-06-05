using System.Collections.Generic;

namespace Project_7
{
    public interface iCzytnik
    {
        string Name { get; }
        List<string> whatToCount { get; }
        int Przelicz(string option, string path);
    }
}
