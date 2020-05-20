using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public interface IConvert
    {

        float convertValue(float Value, ConverterType type);

        string convertedTo();

    }
}
