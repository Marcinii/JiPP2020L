using System;

namespace UnitConverter.Library.TypeUtil.DateTimeType
{
    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="CustomTime"/>, 
    /// która reprezentuje typ danych <see cref="DateTime"/>, ale z tą różnicą,
    /// że ten typ obsługuje tylko czas 12-godzinny
    /// </summary>
    /// 
    /// <param name="timeType">
    ///     Pole przechowujące informacje odnośnie tego, jakka jest pora dla danej godziny
    /// </param>
    /// <see cref="CustomTime" />
    /// <see cref="Custom12HTimeType"/>
    public class Custom12HTime : CustomTime, ICustomDateTime
    {
        protected override string validationRegex => @"^([0]?[0-9]|[1]?[0-2])\:([0-5]?[0-9])(\s([Aa]|[Pp])[Mm])?$";
        public Custom12HTimeType timeType { get; private set; }

        public Custom12HTime() : base() { }
        public Custom12HTime(DateTime value, Custom12HTimeType timeType = default) : base(value)
        {
            this.timeType = timeType;
        }

        public override string ToString() => value.ToString("hh:mm tt");

        /// <summary>
        /// Metoda, która tworzy czas 12-godzinny z czasu 24-godzinnego
        /// </summary>
        /// <param name="time">
        ///     Obiekt, który przechowuje czas w formacie 24-godzinnym
        /// </param>
        /// <returns>Zwraca obiekt zawierający czas w formacie 12-godzinnym</returns>
        public static Custom12HTime fromCustomTime(CustomTime time) => new Custom12HTime { value = time.value };
    }
}
