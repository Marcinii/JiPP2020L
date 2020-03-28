using System;
using UnitConverter.Library.TypeUtil.TypeException;

namespace UnitConverter.Library.TypeUtil
{
    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="CustomObject{T}"/>, która reprezentuje
    /// typ przechowujący godzinę w formacie 24-godzinnym
    /// </summary>
    /// <see cref="CustomObject{T}"/>
    public class CustomTime : CustomObject<DateTime>
    {
        protected override string validationRegex => @"^([0-1]?[0-9]|2[0-3])\:([0-5]?[0-9])$";
        protected override CustomTypeException exception => new CustomTimeIncorrectValueException();

        public CustomTime() : base(new DateTime()) { }
        public CustomTime(DateTime value) : base(value) { }


        public static implicit operator CustomTime(DateTime value) => new CustomTime(value);
        public static implicit operator CustomTime(string value) => (CustomTime) new CustomTime().typeParser.parse(value);

        protected override DateTime parseValue(string input) => DateTime.Parse(input);



        /// <summary>
        /// Metoda, która tworzy czas 24-godzinny z czasu 12-godzinnego
        /// </summary>
        /// <param name="time">
        ///     Obiekt, który przechowuje czas w formacie 12-godzinnym
        /// </param>
        /// <returns>Zwraca obiekt zawierający czas w formacie 24-godzinnym</returns>
        public static CustomTime fromCustom12HTime(Custom12HTime time)
        {
            CustomTime res = new CustomTime();
            res.value = time.value;

            if(time.timeType == Custom12HTimeType.PM)
                res.value.AddHours(12);

            return res;
        }

        public override string ToString() => value.ToString("HH:mm");
    }
}
