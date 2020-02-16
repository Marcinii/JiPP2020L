using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitConverter
{

    class Converter
    {
        double inp_v; Unit inp_u;
        List<Tuple<double, Unit>> out_vals = new List<Tuple<double, Unit>>();
        bool calculated = false;
        bool cmd = false;
        Dictionary<DateTime, Record> history = new Dictionary<DateTime, Record> { };

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
            Console.WriteLine("\tTemperatura:");
            Console.WriteLine("\t\tC\t(Stopnie Celsjusza)");
            Console.WriteLine("\t\tF\t(Stopnie Fahrenheita)");
            Console.WriteLine("\t\tK\t(Stopnie Kelvina)");
            Console.WriteLine("\tMasa:");
            Console.WriteLine("\t\tkg\t(Kilogramy)");
            Console.WriteLine("\t\tlb\t(Funty)");
            Console.WriteLine("\t\toz\t(Uncje)");
            Console.WriteLine("\tDystans:");
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
                // Temperatures
                case "c":
                    inp_u = Unit.Celsius;
                    return true;
                case "f":
                    inp_u = Unit.Fahrenheit;
                    return true;
                case "k":
                    inp_u = Unit.Kelvin;
                    return true;
                // Mass
                case "kg":
                    inp_u = Unit.Kilograms;
                    return true;
                case "lb":
                    inp_u = Unit.Pounds;
                    return true;
                case "oz":
                    inp_u = Unit.Ounces;
                    return true;
                // Distance
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
        void AddOutVal(double val, Unit u)
        {
            out_vals.Add(new Tuple<double, Unit>(val, u));
        }
        void Convert()
        {
            if (!cmd)
            {
                switch (inp_u)
                {
                    // Temperatures
                    case Unit.Celsius:
                        AddOutVal(CelsiusToKelvin(inp_v), Unit.Kelvin);
                        AddOutVal(CelsiusToFahrenheit(inp_v), Unit.Fahrenheit);
                        break;
                    case Unit.Fahrenheit:
                        AddOutVal(FahrenheitToCelsius(inp_v), Unit.Celsius);
                        AddOutVal(FahrenheitToKelvin(inp_v), Unit.Kelvin);
                        break;
                    case Unit.Kelvin:
                        AddOutVal(KelvinToCelsius(inp_v), Unit.Celsius);
                        AddOutVal(KelvinToFahrenheit(inp_v), Unit.Fahrenheit);
                        break;
                    // Mass
                    case Unit.Kilograms:
                        AddOutVal(KilogramsToPounds(inp_v), Unit.Pounds);
                        AddOutVal(KilogramsToOunces(inp_v), Unit.Ounces);
                        break;
                    case Unit.Pounds:
                        AddOutVal(PoundsToKilograms(inp_v), Unit.Kilograms);
                        AddOutVal(PoundsToOunces(inp_v), Unit.Ounces);
                        break;
                    case Unit.Ounces:
                        AddOutVal(OuncesToKilograms(inp_v), Unit.Kilograms);
                        AddOutVal(OuncesToPounds(inp_v), Unit.Pounds);
                        break;
                    // Distance
                    case Unit.Kilometers:
                        AddOutVal(KilometersToMiles(inp_v), Unit.Miles);
                        break;
                    case Unit.Miles:
                        AddOutVal(MilesToKilometers(inp_v), Unit.Kilometers);
                        break;
                    default:
                        break;

                }
                calculated = true;
                history.Add(DateTime.Now, new Record(inp_v, inp_u, new List<Tuple<double, Unit>>(out_vals)));
            }

        }
        string OutStr()
        {
            StringBuilder s = new StringBuilder();
            foreach(Tuple<double, Unit> out_ in out_vals)
            {
                s.Append($"{inp_v} {UnitName(inp_u)} = {out_.Item1} {UnitName(out_.Item2)}\n");
            }
            return s.ToString().Trim('\n');
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
            foreach (KeyValuePair<DateTime, Record> entry in history)
            {
                Console.WriteLine($"{entry.Key}");
                Record r = entry.Value;
                Console.Write($"{r.inp_v} {UnitName(r.inp_u)} =");
                foreach (Tuple<double, Unit> out_ in r)
                {
                    Console.WriteLine($"\t{out_.Item1} {UnitName(out_.Item2)}");
                }
            }
        }
        void Clear()
        {
            inp_v = default; inp_u = default;
            out_vals.Clear();
            calculated = false;
        }
        //################################################
        public class Record : IEnumerable<Tuple<double, Unit>>
        {
            public double inp_v; public Unit inp_u;
            public List<Tuple<double, Unit>> out_v;
            public Record(double v, Unit u, List<Tuple<double, Unit>> out_v)
            {
                inp_v = v;
                inp_u = u;
                this.out_v = out_v;
            }

            public IEnumerator<Tuple<double, Unit>> GetEnumerator()
            {
                return out_v.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return out_v.GetEnumerator();
            }
        }
        //################################################
        // Temperatures
        static double CelsiusToFahrenheit(double inp) 
        {
            return inp * (9 / 5) + 32;
        }
        static double CelsiusToKelvin(double inp)
        {
            return inp + 273.15;
        }
        static double FahrenheitToCelsius(double inp)
        {
            return (inp - 32) * 5 / 9;
        }
        static double FahrenheitToKelvin(double inp)
        {
            return (inp + 459.67) * 5 / 9;
        }
        static double KelvinToCelsius(double inp)
        {
            return inp - 273.15;
        }
        static double KelvinToFahrenheit(double inp)
        {
            return (inp * 9 / 5) - 459.67;
        }
        // Mass
        static double KilogramsToPounds(double inp)
        {
            return inp * 2.2046;
        }
        static double KilogramsToOunces(double inp)
        {
            return inp * 35.2739619496;
        }
        static double OuncesToPounds(double inp)
        {
            return inp * 0.0625;
        }
        static double OuncesToKilograms(double inp)
        {
            return inp * 0.0283495231;
        }
        static double PoundsToKilograms(double inp)
        {
            return inp / 2.2046;
        }
        static double PoundsToOunces(double inp)
        {
            return inp / 0.0625;
        }
        // Distance
        static double KilometersToMiles(double inp)
        {
            return inp * 0.621371192;
        }
        static double MilesToKilometers(double inp)
        {
            return inp / 0.621371192;
        }
        //################################################
        public enum Unit
        {
            Celsius,
            Fahrenheit,
            Kelvin,
            Kilometers,
            Miles,
            Kilograms,
            Pounds,
            Ounces
        }
        public static string UnitName(Unit unit)
        {
            switch (unit)
            {
                case Unit.Celsius:
                    return "C";
                case Unit.Fahrenheit:
                    return "F";
                case Unit.Kelvin:
                    return "K";
                case Unit.Kilograms:
                    return "kg";
                case Unit.Pounds:
                    return "lb";
                case Unit.Ounces:
                    return "oz";
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
