using System;
using System.Text;
using System.Collections.Generic;
using static UnitConverter.Lib.Units;
using static UnitConverter.Lib.Formulas;

namespace UnitConverter.Lib
{
    public class TimeConverter : IConverter<string, TimeFormat>
    {
        public string Name => "Distance Converter";
        public List<TimeFormat> SupportedUnits => new List<TimeFormat>() {
            TimeFormat.TwelveHour,
            TimeFormat.TwentyFourHour,
        };
        public Tuple<string, TimeFormat> Convert(string val, TimeFormat inpFormat, TimeFormat outFormat)
        {
            if (inpFormat == TimeFormat.TwelveHour)
            {
                return new Tuple<string, TimeFormat>(TwelveHToTwentyFour(val), TimeFormat.TwentyFourHour);
            }
            else
            {
                return new Tuple<string, TimeFormat>(TwentyFourHToTwelveH(val), TimeFormat.TwelveHour);
            }
        }
    }
}
