using System.Collections.Generic;
using UnitConverter.Library.TypeUtil.TypeException;

namespace UnitConverter.Library.TypeUtil.Number
{
    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="CustomObject{T}"/>, która reprezentuje
    /// typ przechowujący liczbę całkowitą.
    /// Liczba ta może być ujemna (choć nie musi)
    /// </summary>
    /// <see cref="CustomObject{T}"/>
    public class CustomInteger : CustomObject<int>, ICustomNumber
    {
        protected override string validationRegex => @"^[-]?[0-9]+$";
        protected override CustomTypeException exception => new CustomIntegerIncorrectValueException();


        public CustomInteger() : base(0) { }
        public CustomInteger(int value) : base(value) { }


        public static bool operator ==(CustomInteger integer, int value) => integer.value == value;
        public static bool operator !=(CustomInteger integer, int value) => integer.value != value;
        public static bool operator ==(CustomInteger integer1, CustomInteger integer2) => integer1.value == integer2.value;
        public static bool operator !=(CustomInteger integer1, CustomInteger integer2) => integer1.value != integer2.value;
        public static bool operator >(CustomInteger integer, int value) => integer.value > value;
        public static bool operator <(CustomInteger integer, int value) => integer.value < value;
        public static bool operator >(CustomInteger integer1, CustomInteger integer2) => integer1.value > integer2.value;
        public static bool operator <(CustomInteger integer1, CustomInteger integer2) => integer1.value < integer2.value;
        public static bool operator >=(CustomInteger integer, int value) => integer.value >= value;
        public static bool operator <=(CustomInteger integer, int value) => integer.value <= value;
        public static CustomInteger operator -(CustomInteger integer, int value) => new CustomInteger(integer.value - value);
        public static CustomInteger operator -(CustomInteger i1, CustomInteger i2) => new CustomInteger(i1.value - i2.value);
        public static CustomInteger operator +(CustomInteger integer, int value) => new CustomInteger(integer.value + value);
        public static CustomInteger operator +(CustomInteger i1, CustomInteger i2) => new CustomInteger(i1.value + i2.value);
        public static CustomInteger operator *(CustomInteger integer, int value) => new CustomInteger(integer.value * value);
        public static CustomInteger operator *(CustomInteger i1, CustomInteger i2) => new CustomInteger(i1.value * i2.value);
        public static CustomInteger operator /(CustomInteger integer, int value) => new CustomInteger(integer.value / value);
        public static CustomInteger operator /(CustomInteger i1, CustomInteger i2) => new CustomInteger(i1.value / i2.value);
        public static CustomInteger operator ++(CustomInteger integer) => new CustomInteger(integer.value + 1);
        public static CustomInteger operator --(CustomInteger integer) => new CustomInteger(integer.value - 1);

        public static implicit operator CustomInteger(int value) => new CustomInteger(value);

        protected override int parseValue(string input) => int.Parse(input);

        public override bool isEmpty() => value == 0;


        public override bool Equals(object obj)
        {
            return obj is CustomInteger integer &&
                   validationRegex == integer.validationRegex &&
                   EqualityComparer<CustomTypeException>.Default.Equals(exception, integer.exception);
        }

        public override int GetHashCode()
        {
            int hashCode = -542306109;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(validationRegex);
            hashCode = hashCode * -1521134295 + EqualityComparer<CustomTypeException>.Default.GetHashCode(exception);
            return hashCode;
        }
    }
}
