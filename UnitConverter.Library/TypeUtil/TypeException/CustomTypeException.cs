using System;

namespace UnitConverter.Library.TypeUtil.TypeException
{
    public class CustomTypeException : Exception
    {
        public CustomTypeException(string message) : base(message) { }
    }
}
