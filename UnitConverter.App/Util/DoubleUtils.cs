using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnitConverter.App.Util
{
    /// <summary>
    /// Klasa posiadająca zestaw metód do zarządzania liczbami zmiennoprzecinkowymi
    /// </summary>
    class DoubleUtils
    {


        /// <summary>
        /// Metoda, która zaokrągla do podanego miejsca po przecinku
        /// </summary>
        /// <param name="value">Wartość, którą chcemy zaokrąglić</param>
        /// <param name="digits">Wartość, która przechowuje ilość docelowych cyfer po przecinku</param>
        /// <returns>Liczbę zaokrągloną do wprowadzonej ilości miejsc po przecinku</returns>
        public double roundTo(double value, int digits)
        {
            int x = (int) Math.Pow(10, digits);
            return Math.Round(value * x) / x;
        }



        /// <summary>
        /// Metoda formatująca wprowadzoną liczbę zmiennoprzecinkową. 
        /// Metoda rozdziela wprowadzoną liczbę na części, gdzie każda cześć składa się z od 1 do 3 cyfr.
        /// Liczby po przecinku nie są poddawane formatowaniu.
        /// 
        /// Np.
        /// Dla wartości wejściowej 12000000.12345
        /// Wartość wyjściowa to 12 000 000.12345
        /// </summary>
        /// <param name="number">Wejściowa liczba, którą chcemy sformatować</param>
        /// <returns>Sformatowana liczba jako ciąg znaków</returns>
        public string toFormattedNumber(double number)
        {
            string res = "";
            long integerNumber = (long) Math.Floor(number);

            int i = 0;
            while(integerNumber > 0)
            {
                res = (integerNumber % 10) + (i % 3 == 0 && i != 0 ? " " : "") + res;
                integerNumber /= 10;
                i++;
            }

            if (res == "") res = "0";

            return (number % 10 == 0) 
                ? res 
                : res + "," + Regex.Replace(Convert.ToString(number), @"^[0-9]+\,", "");
        }
    }
}
