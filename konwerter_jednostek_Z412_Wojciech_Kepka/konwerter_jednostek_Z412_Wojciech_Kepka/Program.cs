using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        bool cmd = false;

        Konwerter()
        {
            Console.WriteLine("Konwerter jednostek");
            Console.WriteLine("\nKonwertuje wybraną jednostkę na jej odpowiednik");
            PrintHelp();
        }

        static void PrintHelp()
        {
            Console.WriteLine("#########################################");
            Console.WriteLine("Dostępne Jednostki:");
            Console.WriteLine("\tMasa:");
            Console.WriteLine("\t\tkg\t(Kilogramy)");
            Console.WriteLine("\t\tlb\t(Funty)");
            Console.WriteLine("\tTemperatura:");
            Console.WriteLine("\t\tc\t(Stopnie Celsjusza)");
            Console.WriteLine("\t\tf\t(Stopnie Farenheita)");
            Console.WriteLine("\tOdległość:");
            Console.WriteLine("\t\tkm\t(Kilometry)");
            Console.WriteLine("\t\tmi\t(Mile)");
            Console.WriteLine("Przykładowy input:");
            Console.WriteLine("\t10 kg");
            Console.WriteLine("\t-3.14 f");
            Console.WriteLine("Dostępne komendy:");
            Console.WriteLine("\thelp\tDrukuj pomoc");
            Console.WriteLine("\tclear\tWyczyść okno");
            Console.WriteLine("#########################################");
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
                Console.WriteLine($"'{user_inp}' nie jest poprawną liczbą. Spróbuj ponownie");
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
                    Console.WriteLine($"Podana jednostka '{user_inp}' jest nieobsługiwana. Spróbuj ponownie.");
                    return false;
            }
        }
        // Parsuje input w formie '10 kg', '15.5 c'...
        bool Parse(string user_inp)
        {
            switch (user_inp)
            {
                case "help":
                    PrintHelp();
                    cmd = true;
                    return true;
                case "clear":
                    Console.Clear();
                    cmd = true;
                    return true;
                default:
                    String[] inp = user_inp.Split(' ');
                    cmd = false;
                    try
                    {
                        if (SetInpVal(inp[0]) && SetInpUnit(inp[1]))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (System.IndexOutOfRangeException)
                    {
                        Console.WriteLine($"Podana komenda '{user_inp}' nie istnieje.");
                        return false;
                    }
            }
        }
        void GetInp()
        {
            while (true)
            {
                Console.Write("=> ");
                string user_inp = Console.ReadLine();
                if (Parse(user_inp)) { break; }
            }
        }
        string UnitName(Jednostka unit)
        {
            switch (unit)
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
            if (!cmd)
            {
                switch (inp_u)
                {
                    case Jednostka.Celsjusz:
                        out_v = inp_v * (9 / 5) + 32;
                        out_u = Jednostka.Farenheit;
                        break;
                    case Jednostka.Farenheit:
                        out_v = (inp_v - 32) * 5 / 9;
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

        }
        void PrintOut()
        {
            if (!cmd)
            {
                if (!calculated) { Convert(); }
                Console.WriteLine($"{inp_v} {UnitName(inp_u)} = {out_v} {UnitName(out_u)}");
            }
        }
        void Clear()
        {
            inp_v = default; inp_u = default; out_v = default; out_u = default;
            calculated = false;
        }
        static void Main(string[] args)
        {
            Konwerter conv = new Konwerter();
            while (true)
            {

                conv.GetInp();
                conv.Convert();
                conv.PrintOut();
                conv.Clear();
            }

        }
    }
}
