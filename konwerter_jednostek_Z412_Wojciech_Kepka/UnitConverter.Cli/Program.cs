using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitConverter.Lib;
using static UnitConverter.Lib.Units;

namespace UnitConverter.Cli
{

    class Converter
    {
        double inpVal; Unit inpUnit;
        List<Tuple<double, Unit>> outVals = new List<Tuple<double, Unit>>();
        bool calculated = false;
        bool cmd = false;
        Dictionary<DateTime, Record> history = new Dictionary<DateTime, Record> { };

        DistanceConverter dConv = new DistanceConverter();
        MassConverter mConv = new MassConverter();
        SpeedConverter sConv = new SpeedConverter();
        TemperatureConverter tConv = new TemperatureConverter();

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
            Console.WriteLine("\tPredkosc:");
            Console.WriteLine("\t\tkm/h\t(Kilometry na godzine)");
            Console.WriteLine("\t\tmi/h\t(Mile na godzine)");
            Console.WriteLine("\t\tm/s\t(Metry na sekunde)");
            Console.WriteLine("\t\tknots\t(Wezly)");
            Console.WriteLine("Przykładowy input:");
            Console.WriteLine("\t10 kg");
            Console.WriteLine("\t-3.14 F");
            Console.WriteLine("Dostępne komendy:");
            Console.WriteLine("\thelp\tDrukuj pomoc");
            Console.WriteLine("\tclear\tWyczyść okno");
            Console.WriteLine("\thistory\tHistoria wyników");
            Console.WriteLine("#########################################");
        }
        bool SetInpVal(string userInp)
        {
            try
            {
                this.inpVal = Double.Parse(userInp);
                return true;
            }
            catch (System.FormatException)
            {
                Console.WriteLine($"'{userInp}' nie jest poprawną liczbą. Spróbuj ponownie");
                return false;
            }
        }
        bool SetInpUnit(string userInp)
        {
            try
            {
                inpUnit = UnitFromString(userInp);
                return true;
            }
            catch (UnexpectedEnumValueException<Unit> e)
            {
                Console.WriteLine($"Podana jednostka '{userInp}' jest nieobsługiwana - {e}. Spróbuj ponownie.");
                return false;
            }
        }
        bool Parse(string userInp)
        // Parses input like '10 kg', '15.5 C'...
        {
            switch (userInp)
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
                    String[] inp = userInp.Split(' ');
                    cmd = false;
                    try
                    {
                        if (SetInpVal(inp[0]) && SetInpUnit(inp[1])) { return true; }
                        else { return false; }
                    }
                    catch (System.IndexOutOfRangeException)
                    {
                        Console.WriteLine($"Podana komenda '{userInp}' nie istnieje.");
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
                switch (inpUnit)
                {
                    // Temperatures
                    case Unit.Celsius:
                        outVals.Add(tConv.Convert(inpVal, inpUnit, Unit.Kelvin));
                        outVals.Add(tConv.Convert(inpVal, inpUnit, Unit.Fahrenheit));
                        break;
                    case Unit.Fahrenheit:
                        outVals.Add(tConv.Convert(inpVal, inpUnit, Unit.Celsius));
                        outVals.Add(tConv.Convert(inpVal, inpUnit, Unit.Kelvin));
                        break;
                    case Unit.Kelvin:
                        outVals.Add(tConv.Convert(inpVal, inpUnit, Unit.Celsius));
                        outVals.Add(tConv.Convert(inpVal, inpUnit, Unit.Fahrenheit));
                        break;
                    // Mass
                    case Unit.Kilograms:
                        outVals.Add(mConv.Convert(inpVal, inpUnit, Unit.Pounds));
                        outVals.Add(mConv.Convert(inpVal, inpUnit, Unit.Ounces));
                        break;
                    case Unit.Pounds:
                        outVals.Add(mConv.Convert(inpVal, inpUnit, Unit.Kilograms));
                        outVals.Add(mConv.Convert(inpVal, inpUnit, Unit.Ounces));
                        break;
                    case Unit.Ounces:
                        outVals.Add(mConv.Convert(inpVal, inpUnit, Unit.Kilograms));
                        outVals.Add(mConv.Convert(inpVal, inpUnit, Unit.Pounds));
                        break;
                    // Distance
                    case Unit.Kilometers:
                        outVals.Add(dConv.Convert(inpVal, inpUnit, Unit.Miles));
                        break;
                    case Unit.Miles:
                        outVals.Add(dConv.Convert(inpVal, inpUnit, Unit.Kilometers));
                        break;
                    // Speed
                    case Unit.KilometersPerHour:
                        outVals.Add(sConv.Convert(inpVal, inpUnit, Unit.Knots));
                        outVals.Add(sConv.Convert(inpVal, inpUnit, Unit.MilesPerHour));
                        outVals.Add(sConv.Convert(inpVal, inpUnit, Unit.MetersPerSecond));
                        break;
                    case Unit.MetersPerSecond:
                        outVals.Add(sConv.Convert(inpVal, inpUnit, Unit.Knots));
                        outVals.Add(sConv.Convert(inpVal, inpUnit, Unit.MilesPerHour));
                        outVals.Add(sConv.Convert(inpVal, inpUnit, Unit.KilometersPerHour));
                        break;
                    case Unit.MilesPerHour:
                        outVals.Add(sConv.Convert(inpVal, inpUnit, Unit.Knots));
                        outVals.Add(sConv.Convert(inpVal, inpUnit, Unit.MetersPerSecond));
                        outVals.Add(sConv.Convert(inpVal, inpUnit, Unit.KilometersPerHour));
                        break;
                    case Unit.Knots:
                        outVals.Add(sConv.Convert(inpVal, inpUnit, Unit.MetersPerSecond));
                        outVals.Add(sConv.Convert(inpVal, inpUnit, Unit.MilesPerHour));
                        outVals.Add(sConv.Convert(inpVal, inpUnit, Unit.KilometersPerHour));
                        break;
                    default:
                        break;

                }
                calculated = true;
                history.Add(DateTime.Now, new Record(inpVal, inpUnit, new List<Tuple<double, Unit>>(outVals)));
            }

        }
        string OutStr()
        {
            StringBuilder s = new StringBuilder();
            foreach(Tuple<double, Unit> out_ in outVals)
            {
                s.Append($"{inpVal} {UnitName(inpUnit)} = {out_.Item1} {UnitName(out_.Item2)}\n");
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
                Console.Write($"\t{r.inpVal} {UnitName(r.inpUnit)} =");
                foreach (Tuple<double, Unit> out_ in r)
                {
                    Console.WriteLine($"\t\t{out_.Item1} {UnitName(out_.Item2)}");
                }
            }
        }
        void Clear()
        {
            inpVal = default; inpUnit = default;
            outVals.Clear();
            calculated = false;
        }
        //################################################
        public class Record : IEnumerable<Tuple<double, Unit>>
        {
            public double inpVal; public Unit inpUnit;
            public List<Tuple<double, Unit>> outVal;
            public Record(double v, Unit u, List<Tuple<double, Unit>> out_v)
            {
                inpVal = v;
                inpUnit = u;
                this.outVal = out_v;
            }

            public IEnumerator<Tuple<double, Unit>> GetEnumerator()
            {
                return outVal.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return outVal.GetEnumerator();
            }
        }
        //################################################

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
