using System;
using UnitConverter.Library.OperationUtil.OpException;
using UnitConverter.Library.TypeUtil;
using UnitConverter.Library.TypeUtil.Number;
using UnitConverter.Library.TypeUtil.TypeException;

namespace UnitConverter.Terminal.Core
{

    /// <summary>
    /// Klasa przechowująca metody statyczne, które zajmują się odczytem danych z konsoli i ich walidacją
    /// </summary>
    public class AppConsole
    {

        /// <summary>
        /// Metoda odczytuje i waliduje wprowadzoną wartość mojego własnego typu zmiennej
        /// Dodatkowo w ramach odczytu może wywołać metodę w przypadku, gdy zostanie wpisana parwidłowa wartość
        /// </summary>
        /// <typeparam name="T">
        ///     Typ zmiennej, który chcemy odczytać. Wazne, by był typu <see cref="ICustomType"/>
        /// </typeparam>
        /// <param name="callBackFunction">
        ///     Funkcja, która ma się wywołać w przypadku, gdy wprowadzimy w konsoli prawidłową wartość
        /// </param>
        /// <returns>Zwraca w pełni prawidłową wartość mojego własnego typu zmiennych</returns>
        /// <exception cref="OperationException">
        ///     Wyjątek rzucany w przypadku, gdy wystapią problemy związane z wyszukaniem lub zarządzaniem operacją
        /// </exception>
        /// <see cref="CustomTypeUtils"/>
        /// <see cref="CustomTypeException"/>
        public static T readValueTo<T>(Action<T> callBackFunction)
        {
            bool exceptionThrown = true;
            T res = (T) CustomTypeUtils.createInstanceFrom(typeof(T));

            while (exceptionThrown)
            {
                try
                {
                    res = (T) readValueTo(typeof(T));
                    callBackFunction(res);
                    exceptionThrown = false;
                }
                catch (OperationException ex)
                {
                    Console.WriteLine("!!! {0}. Wprowadź wartość jeszcze raz", ex.Message);
                    Console.Write("> ");
                }
            }

            return res;
        }



        /// <summary>
        /// Metoda odczytuje i waliduje wprowadzoną wartość mojego własnego typu zmiennej
        /// </summary>
        /// <param name="type">Typ danych, który zamierzamy odczytać z konsoli</param>
        /// <param name="required">
        ///     Pole, które decyduje, czy dana wartość jest wymagana do wprowadzenia
        /// </param>
        /// <returns>Zwraca w pełni prawidłową wartość mojego własnego typu zmiennych</returns>
        /// <exception cref="CustomTypeException">
        ///     Wyjątek rzucany w momencie, gdy zostanie wprowadzona nieprawidłowa wartość
        /// </exception>
        /// <see cref="ICustomType"/>
        /// <see cref="CustomTypeUtils"/>
        /// <see cref="CustomTypeException"/>
        public static ICustomType readValueTo(Type type, bool required = true)
        {
            bool exceptionThrown = true;
            ICustomType res = CustomTypeUtils.createInstanceFrom(type);

            while (exceptionThrown)
            {
                try
                {
                    string input = Console.ReadLine();
                    if(required || input != "")
                    {
                        res.fromString(input);
                    }
                    exceptionThrown = false;
                }
                catch(CustomTypeException ex)
                {
                    Console.WriteLine("!!! {0}. Wprowadź wartość jeszcze raz: ", ex.Message);
                    Console.Write("> ");
                }
            }

            return res;
        }



        /// <summary>
        /// Metoda odczytuje i waliduje wprowadzoną liczbę całkowitą
        /// </summary>
        /// <returns>Zwraca w pełni prawidłową liczbę całkowitą</returns>
        /// <exception cref="CustomIntegerIncorrectValueException">
        ///     Wyjątek rzucany w momencie, gdy zostanie wprowadzona nieprawidłowa wartość
        /// </exception>
        /// <see cref="CustomInteger"/>
        public static CustomInteger readCustomInteger()
        {
            bool exceptionThrown = true;
            CustomInteger res = 0;

            while (exceptionThrown)
            {
                try
                {
                    res.fromString(Console.ReadLine());
                    exceptionThrown = false;
                }
                catch (CustomIntegerIncorrectValueException ex)
                {
                    Console.WriteLine("!!! {0}. Wprowadź wartość jeszcze raz: ", ex.Message);
                    Console.Write("> ");
                }
            }

            return res;
        }
    }
}
