using System;
using UnitConverter.Library.TypeUtil.TypeException;

namespace UnitConverter.Library.TypeUtil.DateTimeType
{
    /// <summary>
    /// Klasa dziedzicząca klasę abstrakcyjną <see cref="CustomObject{T}"/> oraz implementująca interfejs <see cref="ICustomDateTime"/>,
    /// która reprezentuje typ danych <see cref="DateTime"/>. Ma ona za zadanie przechowywać datę bez godziny
    /// </summary>
    public class CustomDate : CustomObject<DateTime>, ICustomDateTime
    {
        protected override string validationRegex => @"^[0-9]{4}\-(0?[1-9]|1[1-2])\-(0?[1-9]|[1-2][0-9]|3[0-1])$";
        protected override CustomTypeException exception => new CustomDateIncorrectValueException();

        public CustomDate() : base(new DateTime()) { }
        public CustomDate(DateTime value) : base(value) { }

        public static implicit operator CustomDate(DateTime value) => new CustomDate(value);
        public static implicit operator CustomDate(string value) => (CustomDate)new CustomDate().typeParser.parse(value);
        public static bool operator >=(DateTime dateTime, CustomDate date) => dateTime >= date.value;
        public static bool operator <=(DateTime dateTime, CustomDate date) => dateTime <= date.value;
        public static bool operator >=(CustomDate date1, CustomDate date2) => date1.value >= date2.value;
        public static bool operator <=(CustomDate date1, CustomDate date2) => date1.value <= date2.value;

        protected override DateTime parseValue(string input) => DateTime.Parse(input);

        public override bool isEmpty() => value == new DateTime();

        public override string ToString() => value.ToString("yyyy-MM-dd");
    }
}
