using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("(q) celsjusze na farenheity");
            Console.WriteLine("(w) farenheity na celsjusze");
            Console.WriteLine("(e) kilometry na mile");
            Console.WriteLine("(r) mile na kilometry");
            Console.WriteLine("(t) kilogramy na funty");
            Console.WriteLine("(y) funty na kilogramy");
            Console.WriteLine();
            char w;
            w = Convert.ToChar(Console.ReadLine());
            decimal l;
            decimal r;
            Console.Write("podaj liczbe:");
            l = Convert.ToDecimal(Console.ReadLine());
            if (w == 'q')
            {
                r = l * 9 / 5 + 32;
                Console.WriteLine(r);
            }
            else if (w == 'w')
            {
                r = (l - 32) * 5 / 9;
                Console.WriteLine(r);
            }
            else if (w == 'e')
            {
                r = l / (161 / 100);
                Console.WriteLine(r);
            }
            else if (w == 'r')
            {
                r = l * (161 / 100);
                Console.WriteLine(r);
            }
            else if (w == 't')
            {
                r = l * (2205 / 1000);
                Console.WriteLine(r);
            }
            else if (w == 'y')
            {
                r = l / (2205 / 1000);
                Console.WriteLine(r);
            }
        }
    }
}
