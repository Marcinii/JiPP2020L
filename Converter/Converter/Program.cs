using CommandLine;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Converter
{
    static class Program
    {

        private static IConverterManager converterManager { get; set; }

        public class Options
        {
            [Option('v', "value", Required = true, HelpText = "Value to convert")]
            public float ConvertValue { get; set; }

            [Option('t', "type", Required = true, HelpText = "Type to convertion (0=Celsius, 1=Farenheit, 2=Kilometer, 3=Mile, 4=Kilograms, 5=Funt)")]
            public ConverterType ConvertType { get; set; }



        }

        static void Main(string[] args)
        {
            
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                           .WithParsed<Options>(o =>
                           {
                               converterManager = new ConverterManager();
                               IConvertable<float> convertable = new ConvertValue<float>(o.ConvertValue);
                               Console.WriteLine("Converted value: " + converterManager.ConvertValue(convertable.getValue(), o.ConvertType) + " " + GetDescription(o.ConvertType));
                                
                           });
        }
        static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as System.ComponentModel.DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }

            return null;
        }
    }
}

