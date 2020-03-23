using System;

namespace UnitConverter.Library.TypeUtil
{
    public class Custom12HTime : CustomTime
    {
        protected override string validationRegex => @"^([0]?[0-9]|[1]?[0-2])\:([0-5]?[0-9])(\s([Aa]|[Pp])[Mm])?$";
        public Custom12HTimeType timeType { get; private set; }

        public Custom12HTime() : base() { }
        public Custom12HTime(DateTime value, Custom12HTimeType timeType = default) : base(value)
        {
            this.timeType = timeType;
        }

        public override string ToString() => value.ToString("hh:mm tt");

        public static Custom12HTime fromCustomTime(CustomTime time) => new Custom12HTime { value = time.value };
    }
}
