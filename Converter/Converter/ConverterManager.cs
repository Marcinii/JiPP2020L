using System;
using System.Collections.Generic;
using System.Text;

namespace Converter
{
    class ConverterManager : IConverterManager
    {
        public int ConvertValue(int Value, ConverterType type)
        {
            switch (type)
            {
                case ConverterType.CELSIUS:
                    return Convert.ToInt32((Value - 32) / 1.8);
                case ConverterType.FARENHEIT:
                    return Convert.ToInt32((Value * 1.8) + 32);
                case ConverterType.MILE:
                    return Convert.ToInt32(Value / 1.609344);
                case ConverterType.KILOMETER:
                    return Convert.ToInt32(Value * 1.609344);
                case ConverterType.FUNT:
                    return Convert.ToInt32(Value * 2.4419);
                case ConverterType.KILOGRAMS:
                    return Convert.ToInt32(Value / 2.4419);
                default:
                    return -1;
            }
        }

        public double ConvertValue(double Value, ConverterType type)
        {
            switch (type)
            {
                case ConverterType.CELSIUS:
                    return Convert.ToDouble((Value - 32) / 1.8);
                case ConverterType.FARENHEIT:
                    return Convert.ToDouble((Value * 1.8) + 32);
                case ConverterType.MILE:
                    return Convert.ToDouble(Value / 1.609344);
                case ConverterType.KILOMETER:
                    return Convert.ToDouble(Value * 1.609344);
                case ConverterType.FUNT:
                    return Convert.ToDouble(Value * 2.4419);
                case ConverterType.KILOGRAMS:
                    return Convert.ToDouble(Value / 2.4419);
                default:
                    return -1;
            }
        }

        public float ConvertValue(float Value, ConverterType type)
        {
            switch (type)
            {
                case ConverterType.CELSIUS:
                    return (float) ((Value - 32) / 1.8);
                case ConverterType.FARENHEIT:
                    return (float) (Value * 1.8) + 32;
                case ConverterType.MILE:
                    return (float) (Value / 1.609344);
                case ConverterType.KILOMETER:
                    return (float) (Value * 1.609344);
                case ConverterType.FUNT:
                    return (float) (Value * 2.4419);
                case ConverterType.KILOGRAMS:
                    return (float) (Value / 2.4419);
                default:
                    return -1;
            }
        }
    }
}
