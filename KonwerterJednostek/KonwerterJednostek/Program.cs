using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace KonwerterJednostek
{
    class Program
    {
        private string Temperatura()
        {
            string bck = null;
            char c;
            float val, fval;
            Console.Write("Wpisz wartosc: ");
            fval = float.Parse(Console.ReadLine());
            Console.Write("Wpisz jednostke (C/F): ");
            c = char.Parse(Console.ReadLine());
            val = fval;
            if (char.ToUpperInvariant(c).Equals('C'))
            {
                val *= 1.8f;
                val += 32;
                bck = fval + "°C = " + val + "°F";
                return bck;
            }
            else if (char.ToUpperInvariant(c).Equals('F'))
            {
                val -= 32;
                val /= 1.8f;
                bck = fval + "°F = " + val + "°C";
                return bck;
            }
            else
            {
                Console.WriteLine("Wprowadzono niepoprawna jednostke, nastapi powrot do menu wyboru");
                return null;
            }
        }

        private string Odleglosc()
        {
            string bck = null;
            char c;
            float val, fval;
            Console.Write("Wpisz wartosc: ");
            fval = float.Parse(Console.ReadLine());
            Console.Write("Wpisz jednostke (K/M): ");
            c = char.Parse(Console.ReadLine());
            val = fval;
            if (char.ToUpperInvariant(c).Equals('K'))
            {
                val *= 0.62137f;
                bck = fval + "KM = " + val + "M";
                return bck;
            }
            else if (char.ToUpperInvariant(c).Equals('M'))
            {
                val /= 0.62137f;
                bck = fval + "M = " + val + "KM";
                return bck;
            }
            else
            {
                Console.WriteLine("Wprowadzono niepoprawna jednostke, nastapi powrot do menu wyboru");
                return null;
            }
        }

        private string Masa()
        {
            string bck = null;
            char c;
            float val, fval;
            Console.Write("Wpisz wartosc: ");
            fval = float.Parse(Console.ReadLine());
            Console.Write("Wpisz jednostke (K/L): ");
            c = char.Parse(Console.ReadLine());
            val = fval;
            if (char.ToUpperInvariant(c).Equals('K'))
            {
                val *= 2.204625f;
                bck = fval + "KG = " + val + "LB";
                return bck;
            }
            else if (char.ToUpperInvariant(c).Equals('L'))
            {
                val /= 2.204625f;
                bck = fval + "LB = " + val + "KG";
                return bck;
            }
            else
            {
                Console.WriteLine("Wprowadzono niepoprawna jednostke, nastapi powrot do menu wyboru");
                return null;
            }
        }

        private void Konwerter()
        {
            int x = 0;
            Console.WriteLine("Jaki rodzaj jednostkek chcialbys przekonwertowac?");
            Console.WriteLine("1. Temperatura - Celcjusz/Fahrenheit");
            Console.WriteLine("2. Odleglosc - Kilometr/Mila");
            Console.WriteLine("3. Masa - Kilogram/Funt");
            Console.WriteLine("--------------------------------------------------------");
            Console.Write("Wybor: ");
            x = Convert.ToInt32(Console.ReadLine());
            switch(x)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine(Temperatura());
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine(Odleglosc());
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine(Masa());
                    break;
                default:
                    break;
            }
            Console.WriteLine("Czy zakonczyc program? Y/N");
            if (Console.ReadLine().ToUpper() != "Y")
            {
                Console.Clear();
                Konwerter();
            }
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj!");
            new Program().Konwerter();
        }
    }
}
