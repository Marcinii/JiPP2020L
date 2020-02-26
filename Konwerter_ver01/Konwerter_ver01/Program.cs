using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_ver01
{
    class Program
    {
        static void Main(string[] args)
        {
            start:
            Console.WriteLine("Chcesz coś przekonwertować? (jeśli TAK wpisz t)");
            char odp = char.Parse(Console.ReadLine());
            if (odp == 't')
            {
                Konwerter tmp = new Konwerter();
                tmp.numeropcji();
                tmp.konwerterjednostek();
                goto start;
            }
            
            Console.ReadKey();
        }
    }
}
