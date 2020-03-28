using System;
using System.Text.RegularExpressions;
using UnitConverter.Library.TypeUtil.TypeException;

namespace UnitConverter.Library.TypeUtil
{

    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="CustomObject{T}"/>, która reprezentuje
    /// typ przechowujący liczbę zmiennoprzecinkową.
    /// Liczba ta może być liczbą ujemną (choć nie musi), oraz może niezawierać cyfer po przecinku
    /// </summary>
    /// <see cref="CustomObject{T}"/>
    public class CustomDouble : CustomObject<double>
    {
        protected override string validationRegex => @"^[-]?[0-9]+((\.|\,)[0-9]+)?$";
        protected override CustomTypeException exception => new CustomDoubleIncorrectValueException();

        public CustomDouble() : base(0.0) { }
        public CustomDouble(double value) : base(value) { }

        public static implicit operator CustomDouble(double value) => new CustomDouble(value);
        public static implicit operator CustomDouble(string value) => (CustomDouble) new CustomDouble().typeParser.parse(value);

        public static CustomDouble operator *(CustomDouble value1, CustomDouble value2) => new CustomDouble(value1.value * value2.value);
        public static CustomDouble operator *(CustomDouble value1, double value) => new CustomDouble(value1.value * value);
        public static CustomDouble operator /(CustomDouble value1, CustomDouble value2) => new CustomDouble(value1.value / value2.value);
        public static CustomDouble operator /(CustomDouble value1, double value) => new CustomDouble(value1.value / value);
        public static CustomDouble operator +(CustomDouble value1, CustomDouble value2) => new CustomDouble(value1.value + value2.value);
        public static CustomDouble operator +(CustomDouble value1, double value) => new CustomDouble(value1.value + value);
        public static CustomDouble operator -(CustomDouble value1, CustomDouble value2) => new CustomDouble(value1.value - value2.value);
        public static CustomDouble operator -(CustomDouble value1, double value) => new CustomDouble(value1.value - value);


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
        public string toFormattedString()
        {
            string res = "";
            long integerNumber = (long) Math.Floor(value);

            int i = 0;
            while (integerNumber > 0)
            {
                res = (integerNumber % 10) + (i % 3 == 0 && i != 0 ? " " : "") + res;
                integerNumber /= 10;
                i++;
            }

            if (res == "") res = "0";

            return (value % 10 == 0)
                ? res
                : res + "," + Regex.Replace(Convert.ToString(value), @"^[0-9]+\,", "");
        }


        /// <summary>
        /// Metoda, która zaokrągla do podanego miejsca po przecinku
        /// </summary>
        /// <param name="value">Wartość, którą chcemy zaokrąglić</param>
        /// <param name="digits">Wartość, która przechowuje ilość docelowych cyfer po przecinku</param>
        /// <returns>Liczbę zaokrągloną do wprowadzonej ilości miejsc po przecinku</returns>
        public double roundTo(int digits)
        {
            int x = (int)Math.Pow(10, digits);
            return Math.Round(value * x) / x;
        }

        protected override double parseValue(string input) => double.Parse(input.Replace(".", ","));
    }
}
