using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Model.Responses
{
    public class TimeConversionResponse
    {
        public bool Success { get; set; }
        public string TimeValue { get; set; }
        public string Message { get; set; }
    }
}
