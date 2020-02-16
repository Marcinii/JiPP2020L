using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitConverter
{
    class Converter
    {
        double inp_v, out_v;
        Unit inp_u, out_u;
        bool calculated = false;
        bool cmd = false;
        Dictionary<DateTime, string> history = new Dictionary<DateTime, string> { };

        Converter()
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
            Console.WriteLine("\t\tC\t(Stopnie Celsjusza)");
            Console.WriteLine("\t\tF\t(Stopnie Farenheita)");
            Console.WriteLine("\tOdległość:");
            Console.WriteLine("\t\tkm\t(Kilometry)");
            Console.WriteLine("\t\tmi\t(Mile)");
            Console.WriteLine("Przykładowy input:");
            Console.WriteLine("\t10 kg");
            Console.WriteLine("\t-3.14 F");
            Console.WriteLine("Dostępne komendy:");
            Console.WriteLine("\thelp\tDrukuj pomoc");
            Console.WriteLine("\tclear\tWyczyść okno");
            Console.WriteLine("\thistory\tHistoria wyników");
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
            switch (user_inp.ToLower())
            {
                case "kg":
                    inp_u = Unit.Kilograms;
                    return true;
                case "lb":
                    inp_u = Unit.Pounds;
                    return true;
                case "c":
                    inp_u = Unit.Celsius;
                    return true;
                case "f":
                    inp_u = Unit.Farenheit;
                    return true;
                case "km":
                    inp_u = Unit.Kilometers;
                    return true;
                case "mi":
                    inp_u = Unit.Miles;
                    return true;
                default:
                    Console.WriteLine($"Podana jednostka '{user_inp}' jest nieobsługiwana. Spróbuj ponownie.");
                    return false;
            }
        }
        bool Parse(string user_inp)
        // Parses input like '10 kg', '15.5 C'...
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
                case "history":
                    PrintHistory();
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
        void Convert()
        {
            if (!cmd)
            {
                switch (inp_u)
                {
                    case Unit.Celsius:
                        out_v = CelsiusToFahrenheit(inp_v);
                        out_u = Unit.Farenheit;
                        break;
                    case Unit.Farenheit:
                        out_v = FarenheitToCelsius(inp_v);
                        out_u = Unit.Celsius;
                        break;
                    case Unit.Kilograms:
                        out_v = KilogramsToPounds(inp_v);
                        out_u = Unit.Pounds;
                        break;
                    case Unit.Pounds:
                        out_v = PoundsToKilograms(inp_v);
                        out_u = Unit.Kilograms;
                        break;
                    case Unit.Kilometers:
                        out_v = KilometersToMiles(inp_v);
                        out_u = Unit.Miles;
                        break;
                    case Unit.Miles:
                        out_v = MilesToKilometers(inp_v);
                        out_u = Unit.Kilometers;
                        break;
                    default:
                        break;

                }
                calculated = true;
                history.Add(DateTime.Now, OutStr());
            }

        }
        string OutStr()
        {
            return $"{inp_v} {UnitName(inp_u)} = {out_v} {UnitName(out_u)}";
        }
        void PrintOut()
        {
            if (!cmd)
            {
                if (!calculated) { Convert(); }
                Console.WriteLine(OutStr());
            }
        }
        void PrintHistory()
        {
            foreach (KeyValuePair<DateTime, String> entry in history)
            {
                Console.WriteLine($"{entry.Key} - '{entry.Value}'");
            }
        }
        void Clear()
        {
            inp_v = default; inp_u = default; out_v = default; out_u = default;
            calculated = false;
        }
        //################################################
        static double CelsiusToFahrenheit(double inp) 
        {
            return inp * (9 / 5) + 32;
        }
        static double FarenheitToCelsius(double inp)
        {
            return (inp - 32) * 5 / 9;
        }
        static double KilogramsToPounds(double inp)
        {
            return inp * 2.2046;
        }
        static double PoundsToKilograms(double inp)
        {
            return inp / 2.2046;
        }
        static double KilometersToMiles(double inp)
        {
            return inp * 0.621371192;
        }
        static double MilesToKilometers(double inp)
        {
            return inp / 0.621371192;
        }
        //################################################
        enum Unit
        {
            Celsius,
            Farenheit,
            Kilometers,
            Miles,
            Kilograms,
            Pounds
        }
        static string UnitName(Unit unit)
        {
            switch (unit)
            {
                case Unit.Celsius:
                    return "C";
                case Unit.Farenheit:
                    return "F";
                case Unit.Kilograms:
                    return "kg";
                case Unit.Pounds:
                    return "lb";
                case Unit.Kilometers:
                    return "km";
                case Unit.Miles:
                    return "mi";
                default:
                    return "";
            }
        }

        static void Main(string[] args)
        {
            Converter conv = new Converter();
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
