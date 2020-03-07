using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverterApp.Util
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
        public static double roundTo(double value, int digits)
        {
            int x = (int) Math.Pow(10, digits);
            return Math.Round(value * x) / x;
        }
    }
}
