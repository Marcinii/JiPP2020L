using System;

namespace BankApplication.Library.UserUtil
{
    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="Exception"/>. 
    /// Będzie ona wyrzucana podczas nieudanej próby wyszukania użytkownika.
    /// </summary>
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message){}
    }
}
