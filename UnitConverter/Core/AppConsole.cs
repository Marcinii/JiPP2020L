using System;
using System.Text.RegularExpressions;

namespace UnitConverter.Core
{

    /// <summary>
    /// Klasa przechowująca metody statyczne, które zajmują się odczytem danych z konsoli i ich walidacją
    /// </summary>
    class AppConsole
    {
        /// <summary>
        /// Metoda odczytuje i waliduje wprowadzoną liczbę całkowitą
        /// </summary>
        /// <returns>Zwraca w pełni poprawna liczbę całkowitą</returns>
        public static int readInt()
        {
            string rawInput = Console.ReadLine();

            while(rawInput.Length == 0 || !Regex.IsMatch(rawInput, @"^[-]?[0-9]+$"))
            {
                Console.WriteLine("!!! Wprowadzona wartość jest nieprawidłowa! Wprowadź liczbę całkowitą jeszcze raz:");
                Console.Write("> ");
                rawInput = Console.ReadLine();
            }

            return Convert.ToInt32(rawInput);
        }

        /// <summary>
        /// Metoda odczytuje i waliduje wprowadzoną liczbę całkowitą. 
        /// Dodatkową funkcjonalnością tej metody jest dodanie swojego własnego walidatora.
        /// </summary>
        /// <returns>Zwraca w pełni poprawna liczbę całkowitą</returns>
        /// <see cref="IValidator{T}"/>
        public static int readInt(IValidator<int> validator)
        {
            int result = readInt();

            while(validator.validate(result))
            {
                Console.WriteLine("!!! {0}", validator.getMessage());
                Console.Write("> ");
                result = readInt();
            }

            return result;
        }

        /// <summary>
        /// Metoda odczytuje i waliduje wprowadzoną liczbę zmiennoprzecinkową
        /// </summary>
        /// <returns>Zwraca w pełni poprawna liczbę zmiennoprzecinkową</returns>
        public static double readDouble()
        {
            string rawInput = Console.ReadLine();

            while (rawInput.Length == 0 || !Regex.IsMatch(rawInput, @"^[-]?[0-9]+((\.|\,)[0-9]+)?$"))
            {
                Console.WriteLine("!!! Wprowadzona wartość jest nieprawidłowa! Wprowadź liczbę zmiennoprzecinkową jeszcze raz:");
                Console.Write("> ");
                rawInput = Console.ReadLine();
            }

            return Convert.ToDouble(rawInput.Replace('.', ','));
        }
    }
}
