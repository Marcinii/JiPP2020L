using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Project 1 - Maciej Dziub Z404");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("CONVERTER 1.0 | C/F | km/mi | kg/lb");
            Console.WriteLine("------------------------------------");
            Converter converter1 = new Converter();
            converter1.convert();
            Console.WriteLine("------------------------------------");
            Console.ReadKey();
        }
    }
}