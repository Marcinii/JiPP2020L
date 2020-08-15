using System.Text.RegularExpressions;
using Logic.Model.Responses;

namespace Logic.Services
{
    public class TimeConvertingService
    {
        public TimeConversionResponse Convert(string time)
        {
            var result = Validate(time);
            if (!result.Success) return new TimeConversionResponse() {Success = false, Message = result.Message};
            var h = result.Item[0];
            var m = result.Item[1];
            var convertedTimeValue = "";

            if (h > 12)
            {
                h -= 12;
                convertedTimeValue = $"{LeadingZeroIntConvert(h)}:{LeadingZeroIntConvert(m)}PM";
            }
            else
            {
                convertedTimeValue = $"{LeadingZeroIntConvert(h)}:{LeadingZeroIntConvert(m)}AM";
            }

            return new TimeConversionResponse() {Success = true, TimeValue = convertedTimeValue};
        }

        protected TimeValidationResponse Validate(string time)
        {
            if (4 > time.Length || time.Length > 5) 
                return new TimeValidationResponse("Incorrect time string length");
            var substrings = Regex.Split(time, ":");
            if (substrings.Length != 2) 
                return new TimeValidationResponse("Incorrect time format");
            if (!int.TryParse(substrings[0], out var h)) 
                return new TimeValidationResponse("Incorrect hours format");
            if (h < 0 || h > 23) 
                return new TimeValidationResponse("Incorrect hours format");
            if (!int.TryParse(substrings[1], out var m)) 
                return new TimeValidationResponse("Incorrect minutes format");
            if (m < 0 || m >= 60)
                return new TimeValidationResponse("Incorrect minutes format");
            return new TimeValidationResponse(new[] { h, m });
        }

        protected string LeadingZeroIntConvert(int value)
        {
            return value < 10 ? $"0{value}" : value.ToString();
        }
    }
}
