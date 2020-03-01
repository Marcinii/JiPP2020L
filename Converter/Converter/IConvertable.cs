using System;
using System.Collections.Generic;
using System.Text;

namespace Converter
{
    interface IConvertable<T>
    {

        T getValue();

    }
}
