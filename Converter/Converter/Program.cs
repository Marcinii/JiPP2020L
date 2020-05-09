using CommandLine;
using Converter.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Converter
{
    static class Program
    {

        static readonly Dictionary<ConverterType, IConvert> converterMethods = new Dictionary<ConverterType, IConvert>()
        {
            { ConverterType.JOULE, new EnergyConverter() },
            { ConverterType.CALORIES, new EnergyConverter() },
            { ConverterType.FARENHEIT, new TemperatureConverter() },
            { ConverterType.CELSIUS, new TemperatureConverter() },
            { ConverterType.KILOMETER, new Logic.LengthConverter() },
            { ConverterType.MILE, new Logic.LengthConverter() },
            {ConverterType.TIME, new Logic.TimeConverter() },
        };

        public class Options
        {
            [Option('v', "value", Required = true, HelpText = "Value to convert")]
            public float ConvertValue { get; set; }

            [Option('t', "type", Required = true, HelpText = "Type to convertion (0=Celsius, 1=Farenheit, 2=Kilometer, 3=Mile, 4=Kilograms, 5=Funt, 6=Joules, 7=Calories)")]
            public ConverterType ConvertType { get; set; }



        }

        static void Main(string[] args)
        {

            CommandLine.Parser.Default.ParseArguments<Options>(args)
                           .WithParsed<Options>(o =>
                           {
                               if (!converterMethods.ContainsKey(o.ConvertType))
                               {
                                   Console.WriteLine("This converter is not supported at this moment!");
                                   return;
                               }
                               IConvertable<float> convertable = new ConvertValue<float>(o.ConvertValue);
                               IConvert convert = converterMethods[o.ConvertType];
                               Console.WriteLine("Converted value: " + convert.convertValue(convertable.getValue(), o.ConvertType) + " " + EnumUtil.GetDescription(o.ConvertType));
                           });
        }

    }

}

