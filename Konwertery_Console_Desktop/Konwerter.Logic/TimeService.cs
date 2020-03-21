using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class TimeService
    {

        public static string fromPmToNumeric (string value)
        {
            DateTime time = DateTime.Parse(value);
            return time.ToString("HH:mm");
        }
        public static string fromNumericToPm(string value)
        {
            DateTime time = DateTime.Parse(value);
            return time.ToString("hh:mm");
        }
    }
}
