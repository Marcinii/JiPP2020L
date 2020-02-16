using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    enum Jednostka
    {
        Celsjusz,
        Farenheit,
        Kilometry,
        Mile,
        Kilogramy,
        Funty
    }
    class Konwerter
    {
        double inp_v, out_v;
        Jednostka inp_u, out_u;
        bool calculated = false;

        Konwerter()
        {
            Console.WriteLine("Konwerter jednosterk\n#########################################");
            Console.WriteLine("\nKonwertuje wybraną jednostkę na jej odpowiednik\n");
            Console.WriteLine("Dostępne Jednostki:");
            Console.WriteLine("\tkg\t(Kilogramy)");
            Console.WriteLine("\tlb\t(Funty)");
            Console.WriteLine("\tc\t(Stopnie Celsjusza)");
            Console.WriteLine("\tf\t(Stopnie Farenheita)");
            Console.WriteLine("\tkm\t(Kilometry)");
            Console.WriteLine("\tmi\t(Mile)");
        }

        bool SetInpVal(string user_inp)
        {
            try
            {
                this.inp_v = Double.Parse(user_inp);
                return true;
            }
            catch (System.FormatException)
            {
                Console.WriteLine($"{user_inp} nie jest poprawną liczbą. Spróbuj ponownie");
                return false;
            }
        }

        bool SetInpUnit(string user_inp)
        {
            switch (user_inp)
            {
                case "kg":
                    inp_u = Jednostka.Kilogramy;
                    return true;
                case "lb":
                    inp_u = Jednostka.Funty;
                    return true;
                case "c":
                    inp_u = Jednostka.Celsjusz;
                    return true;
                case "f":
                    inp_u = Jednostka.Farenheit;
                    return true;
                case "km":
                    inp_u = Jednostka.Kilometry;
                    return true;
                case "mi":
                    inp_u = Jednostka.Mile;
                    return true;
                default:
                    Console.WriteLine($"Podana jednostka {user_inp} jest nieobsługiwana. Spróbuj ponownie.");
                    return false;
            }
        }
        string OutValUnit()
        {
            switch (out_u)
            {
                case Jednostka.Celsjusz:
                    return "c";
                case Jednostka.Farenheit:
                    return "f";
                case Jednostka.Kilogramy:
                    return "kg";
                case Jednostka.Funty:
                    return "lb";
                case Jednostka.Kilometry:
                    return "km";
                case Jednostka.Mile:
                    return "mi";
                default:
                    return "";
            }
        }
        void Convert()
        {
            switch (inp_u)
            {
                case Jednostka.Celsjusz:
                    out_v = inp_v * (9 / 5) + 32;
                    out_u = Jednostka.Farenheit;
                    break;
                case Jednostka.Farenheit:
                    out_v = (inp_v - 32) * 5/9;
                    out_u = Jednostka.Celsjusz;
                    break;
                case Jednostka.Kilogramy:
                    out_v = inp_v * 2.2046;
                    out_u = Jednostka.Funty;
                    break;
                case Jednostka.Funty:
                    out_v = inp_v / 2.2046;
                    out_u = Jednostka.Kilogramy;
                    break;
                case Jednostka.Kilometry:
                    out_v = inp_v * 0.621371192;
                    out_u = Jednostka.Mile;
                    break;
                case Jednostka.Mile:
                    out_v = inp_v / 0.621371192;
                    out_u = Jednostka.Kilometry;
                    break;
                default:
                    break;

            }
            calculated = true;
        }
        void PrintOut()
        {
            if (!calculated) { Convert(); }
            Console.WriteLine($"{inp_v} {inp_u} = {out_v} {out_u}");
        }
        void Clear()
        {
            inp_v = default; inp_u = default; out_v = default; out_u = default;
            calculated = false;
        }
        static void Main(string[] args)
        {
            Konwerter conv = new Konwerter();

            // Ustawiamy wartość wejściową
            while (true) 
            {
                Console.WriteLine("Podaj wartość wejściową: ");
                string user_inp_v = Console.ReadLine();
                if (conv.SetInpVal(user_inp_v)) { break; }
            }

            // Ustawiamy jednostkę wejściową
            while (true)
            {
                Console.WriteLine("Podaj jednostkę: ");
                string user_inp_u = Console.ReadLine();
                if (conv.SetInpUnit(user_inp_u)) { break; }
            }

            conv.Convert();
            conv.PrintOut();
        }
    }
}
