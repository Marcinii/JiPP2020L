using System;
using System.Text.RegularExpressions;
using UnitConverter.Library.TypeUtil;
using UnitConverter.Library.TypeUtil.TypeException;
using UnitConverter.Library.Validator;

namespace UnitConverter.Library
{

    /// <summary>
    /// Klasa przechowująca metody statyczne, które zajmują się odczytem danych z konsoli i ich walidacją
    /// </summary>
    public class AppConsole
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
        public static int readInt(CommandValidator validator)
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
        public static void readValueTo(ICustomType value)
        {
            bool exceptionThrown = true;
            while(exceptionThrown)
            {
                try
                {
                    value.fromString(Console.ReadLine());
                    exceptionThrown = false;
                }
                catch(CustomTypeException ex)
                {
                    Console.WriteLine("!!! {0}. Wprowadź wartość jeszcze raz: ", ex.Message);
                    Console.Write("> ");
                }
            }
        }
    }
}
