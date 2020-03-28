using System;
using System.Diagnostics;
using UnitConverter.Library.TypeUtil.TypeException;

namespace UnitConverter.Library.TypeUtil
{
    /// <summary>
    /// Klasa, która zawiera zestaw metod do zarządzania obiektami typy <see cref="ICustomType"/>
    /// </summary>
    /// <see cref="ICustomType"/>
    public class CustomTypeUtils
    {
        /// <summary>
        /// Metoda inicjalizuje nową instancję obiektu z podanego typu
        /// </summary>
        /// <param name="type">Typ, z którego chcemy stworzyć obiekt</param>
        /// <returns>Utworzony obiekt o wprowadzonym typie</returns>
        /// <exception cref="CreateInstanceCustomTypeException">
        ///     Rzutuje się w momencie, gdy wprowadzony typ nie jest typem, który dziedziczy po
        ///     klasie <see cref="CustomObject{T}"/>
        /// </exception>
        /// <see cref="ICustomType"/>
        /// <see cref="CustomDouble"/>
        /// <see cref="CustomTime"/>
        /// <see cref="Custom12HTime"/>
        /// <see cref="CustomInteger"/>
        public static ICustomType createInstanceFrom(Type type)
        {
            Trace.WriteLine(
                string.Format("CustomTypeUtils :: createInstanceFrom :: type: {0}", type)
            );

            ICustomType res;

            switch (type.Name)
            {
                case "CustomDouble": res = new CustomDouble(); break;
                case "CustomTime": res = new CustomTime(); break;
                case "Custom12HTime": res = new Custom12HTime(); break;
                case "CustomInteger": res = new CustomInteger(); break;
                default: throw new CreateInstanceCustomTypeException(string.Format("Wprowadzony typ \"{0}\' nie został rozpoznany", type.ToString()));
            }

            return res;
        }



        /// <summary>
        /// Metoda inicjalizuje nową instancję obiektu z podanego typu
        /// Dodatkowo do utworzonej instancji wprowadza wartość przekazaną w parametrze <see cref="value"/>
        /// </summary>
        /// <param name="type">Typ, z którego chcemy stworzyć obiekt</param>
        /// <param name="value">Wartość, którą chcemy wprowadzić</param>
        /// <returns>Utworzony obiekt o wprowadzonym typie</returns>
        /// <exception cref="CreateInstanceCustomTypeException">
        ///     Rzutuje się w momencie, gdy wprowadzony typ nie jest typem, który dziedziczy po
        ///     klasie <see cref="CustomObject{T}"/>
        /// </exception>
        /// <see cref="ICustomType"/>
        /// <see cref="CustomDouble"/>
        /// <see cref="CustomTime"/>
        /// <see cref="Custom12HTime"/>
        /// <see cref="CustomInteger"/>
        public static ICustomType createInstanceFrom(Type type, string value)
        {
            Trace.WriteLine(
                string.Format("CustomTypeUtils :: createInstanceFrom :: type: {0}, value: {1}", type, value)
            );

            ICustomType res;

            switch (type.Name)
            {
                case "CustomDouble": res = new CustomDouble().fromString(value); break;
                case "CustomTime": res = new CustomTime().fromString(value); break;
                case "Custom12HTime": res = new Custom12HTime().fromString(value); break;
                case "CustomInteger": res = new CustomInteger().fromString(value); break;
                default: throw new CreateInstanceCustomTypeException(string.Format("Wprowadzony typ \"{0}\' nie został rozpoznany", type.ToString()));
            }

            return res;
        }



        /// <summary>
        /// Metoda inicjalizuje nową instancję obiektu z podanego typu
        /// Dodatkowo do utworzonej instancji wprowadza wartość przekazaną w parametrze <see cref="value"/>
        /// </summary>
        /// <param name="type">Typ, z którego chcemy stworzyć obiekt</param>
        /// <param name="value">Wartość, którą chcemy wprowadzić</param>
        /// <returns>Utworzony obiekt o wprowadzonym typie</returns>
        /// <exception cref="CreateInstanceCustomTypeException">
        ///     Rzutuje się w momencie, gdy wprowadzony typ nie jest typem, który dziedziczy po
        ///     klasie <see cref="CustomObject{T}"/>
        /// </exception>
        /// <see cref="ICustomType"/>
        /// <see cref="CustomDouble"/>
        /// <see cref="CustomTime"/>
        /// <see cref="Custom12HTime"/>
        /// <see cref="CustomInteger"/>
        public static ICustomType createInstanceFrom(Type type, ICustomType value)
        {
            Trace.WriteLine(
                string.Format("CustomTypeUtils :: createInstanceFrom :: type: {0}, value: {1}", type, value.ToString())
            );

            ICustomType res;

            switch (type.Name)
            {
                case "CustomDouble": res = (CustomDouble)value; break;
                case "CustomTime": res = (CustomTime)value; break;
                case "Custom12HTime": res = Custom12HTime.fromCustomTime((CustomTime)value); break;
                default: throw new CreateInstanceCustomTypeException(string.Format("Wprowadzony typ \"{0}\' nie został rozpoznany", type.ToString()));
            }

            return res;
        }
    }
}
