using System;
using System.Collections.Generic;
using System.Text;

namespace Converter
{
    interface IConverterManager
    {

        int ConvertValue(int Value, ConverterType type);

        double ConvertValue(double Value, ConverterType type);

        float ConvertValue(float Value, ConverterType type);


    }
}
