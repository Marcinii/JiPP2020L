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
            List<IConverter> konwer = new Konwerter_ver01.ZestawKonw().GetConverter();
            
            bool start = true;

            while (start)
            {
                Console.WriteLine("Konwerter jednostek. Wybierz opcję.");
                for (int i = 0; i < konwer.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, konwer[i].Name);
                }
                               
                    Console.WriteLine("Podaj numer wybranego konwertera");
                    string s = Console.ReadLine();
                    if (int.TryParse(s, out int numer)) {
                    if (numer > konwer.Count) Console.WriteLine("{0} nie jest opcją.", s);
                    else
                    {
                        Console.WriteLine("Podaj wprowadzaną jednostkę: ");
                        string JednZ = Console.ReadLine();

                        Console.WriteLine("Podaj wyprowadzaną jednostkę: ");
                        string JednDo = Console.ReadLine();

                        Console.WriteLine("Podaj wartość do przeliczenia: ");
                        string Dane = Console.ReadLine();
                        double Wart = double.Parse(Dane);
                        if (double.TryParse(Dane, out Wart)) ;
                        else Console.WriteLine("{0} nie jest opcją.", Wart);

                       string result = konwer[numer - 1].Convert(JednZ, JednDo, Dane);

                        Console.WriteLine("Podana wartość po konwersji: {0} ", result + " " + JednDo.ToString());
                    }
                }
                //start = false;
            }
        }
    }
}
