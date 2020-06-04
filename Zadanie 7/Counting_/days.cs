using System;
using System.Collections.Generic;
using System.Text;

namespace Counting_
{
    class days : iSign
    {
        public List<string> ComboList = new List<string>
        {
            "1-5",
            "5-10",
            "10-15",
            "month"
        };

        List<string> iSign.ComboList => throw new NotImplementedException();
    }
}
