using System;
using System.Collections.Generic;
using System.Text;

namespace Converter
{
    public interface IConvertable<T>
    {

        T getValue();

    }
}
