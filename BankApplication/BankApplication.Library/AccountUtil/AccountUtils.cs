using System;

namespace BankApplication.Library.AccountUtil
{
    /// <summary>
    /// Klasa posiadająca zestaw metod do wykonywania operacji na kotach bankowych
    /// </summary>
    public class AccountUtils
    {
        /// <summary>
        /// Metoda ma za zadanie wygenerować nowy numer konta bankowego
        /// </summary>
        /// <returns>Zwraca nowo wylosowany numer konta bankowego</returns>
        public static string generateAccountNumber()
        {
            Random random = new Random();
            string res = "";

            for(int i = 0; i < 26; i++)
                res += random.Next(0, 9).ToString();

            return res;
        }
    }
}
