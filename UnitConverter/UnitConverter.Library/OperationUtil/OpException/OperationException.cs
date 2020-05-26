using System;

namespace UnitConverter.Library.OperationUtil.OpException
{
    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="Exception"/>, która reprezentuje wyjątek rzutowany
    /// wraz z niepowodzeniem wykonanej odpowiedniej operacji
    /// </summary>
    /// <see cref="Exception"/>
    public class OperationException : Exception
    {
        public OperationException(string message) : base(message) { }
    }
}
