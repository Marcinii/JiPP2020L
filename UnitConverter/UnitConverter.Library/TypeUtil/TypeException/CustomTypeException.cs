using System;

namespace UnitConverter.Library.TypeUtil.TypeException
{
    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="Exception"/>, która będzie rzucana
    /// w momencie, gdy dojdzie do problemów związane z nieprawidłowociami w moich typach danych
    /// </summary>
    public class CustomTypeException : Exception
    {
        public CustomTypeException(string message) : base(message) { }
    }
}
