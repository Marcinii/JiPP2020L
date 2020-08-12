using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Model.Responses
{
    public class TimeValidationResponse : BaseResponse<int[]>
    {
        public TimeValidationResponse(string message) : base(message)
        {
        }

        public TimeValidationResponse(int[] item) : base(item)
        {
        }
    }
}
