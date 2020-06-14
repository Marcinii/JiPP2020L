using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Logic;

namespace UnitConverter.Cli
{
    class CliConverter
    {
        string user_input;

        double input_value;
        double output_value;
        string input_unit;
        string output_unit;
        IConverter current_converter;

        List<IConverter> converters = new List<IConverter>()
        {
            new ByteConverter(),
            new DistanceConverter(),
            new MassConverter(),
            new TemperatureConverter(),
            new TimeConverter(),
        };

        CliConverter()
        {
            Console.WriteLine("Unit converter\n");
            Console.WriteLine("Avaliable units:");
            Console.WriteLine("----------------");
            Console.WriteLine("Bytes: b, kb, mb, gb");
            Console.WriteLine("Distance: km, mi");
            Console.WriteLine("Mass: kg, lb, oz");
            Console.WriteLine("Temperature: C, F, K");
            Console.WriteLine("Time: 12h, 24h\n\n");
            Console.WriteLine("To convert time type for example:\n\t'12:40 am' to convert to 24h format\n\t'23:30' to convert to 12h format'");
        }

        bool SetInputValue(string input)
        {
            try
            {
                this.input_value = Double.Parse(input);
                return true;
            }
            catch (System.FormatException)
            {
                Console.WriteLine($"Invalid input value \"{input}\"");
                return false;
            }
        }

        bool SetInputUnit(string input)
        {
            foreach (IConverter conv in this.converters)
            {
                if (conv.Units.Contains(input))
                {
                    this.input_unit = input;
                    this.current_converter = conv;
                    return true;
                }
            }
            Console.WriteLine($"Invalid input unit \"{input}\"");
            return false;
        }

        bool SetOutputUnit(string input)
        {
            foreach (IConverter conv in this.converters)
            {
                if (conv.Units.Contains(input)
                    && conv == this.current_converter)
                {
                    this.output_unit = input;
                    return true;
                }
            }
            Console.WriteLine($"Invalid output unit \"{input}\"");
            return false;
        }

        void GetUserInput(string message)
        {
            Console.Write(message);
            user_input = Console.ReadLine();
        }

        bool ParseUserInputFrom()
        {
            String[] input = user_input.Split(' ');
            if (input.Length == 2)
            {
                if (input[0].Contains(':'))
                {
                    // Zamieniamy : na . aby konwersja czasu działała
                    input[0] = input[0].Replace(':', '.');
                }
                var is_success_value = SetInputValue(input[0]);
                var is_success_unit = SetInputUnit(input[1]);
                return is_success_unit && is_success_value;
            }
            else if (input.Length == 1)
            {
                if (input[0].Contains(':'))
                {
                    input[0] = input[0].Replace(':', '.');
                    var is_success_value = SetInputValue(input[0]);
                    SetInputUnit("");
                    return is_success_value;
                }
            }

            return false;
        }

        bool ParseUserInputTo()
        {
            return SetOutputUnit(user_input);
        }

        void DisplayTime()
        {
            var hours = Math.Floor(output_value);
            var minutes = Math.Floor((output_value - hours) * 100);
            Console.WriteLine($"{hours}:{minutes} {output_unit}");
        }

        void Convert()
        {
            var output = this.current_converter.Convert(input_value, input_unit, output_unit);
            this.output_value = output.Item1;
            this.output_unit = output.Item2;
            if (this.current_converter.Name == "Time")
            {
                DisplayTime();
            }
            else
            {
                Console.WriteLine($"{output_value} {output_unit}");
            }
        }

        void MainLoop()
        {
            while (true)
            {
                Console.WriteLine("-----------------");
                while (true)
                {
                    GetUserInput("From: ");
                    if (ParseUserInputFrom())
                    {
                        break;
                    }
                }
                if (this.current_converter.Name != "Time")
                {
                    while (true)
                    {
                        GetUserInput("To: ");
                        if (ParseUserInputTo())
                        {
                            break;
                        }
                    }
                }
                else
                {
                    this.output_unit = "";
                }

                Convert();
            }
        }


        static void Main(string[] args)
        {
            CliConverter converter = new CliConverter();
            converter.MainLoop();
        }
    }
}
