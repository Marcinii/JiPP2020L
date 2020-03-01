using System;
using System.Collections.Generic;
using System.Text;

namespace Converter
{
    class ConvertValue<T> : IConvertable<T>
    {

        private readonly T Value;

        public ConvertValue(T Value)
        {
            this.Value = Value;
        }

        public T getValue()
        {
            return this.Value;
        }
    }
}
