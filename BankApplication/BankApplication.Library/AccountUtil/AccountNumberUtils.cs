namespace BankApplication.Library.AccountUtil
{
    /// <summary>
    /// Klasa zawierająca zestaw metod do wykonywania operacji na numerze konta bankowego
    /// </summary>
    public class AccountNumberUtils
    {
        /// <summary>
        /// Metoda ma za zadanie sformatować numer konta bankowego na bardziej czytelny
        /// </summary>
        /// <param name="accountNumber">Wejściowy nuer konta bankowego</param>
        /// <returns></returns>
        public static string toFormattedAccountNumber(string accountNumber)
        {
            string res = "";

            for(int i = 0; i < accountNumber.Length; i++)
            {
                res += accountNumber[i] + ((i % 4 == 1) ? " " : "");
            }

            return res.Trim();
        }



        /// <summary>
        /// Metoda usuwa wszystkie spacje z wprowadzonego numeru konta bankowego
        /// </summary>
        /// <param name="accountNummber"></param>
        /// <returns></returns>
        public static string removeSpaces(string accountNummber) => accountNummber.Replace(" ", "");
    }
}
