using System;
using System.Collections.Generic;
using System.Text;

namespace Counting_
{
    class cities : iSign
    {

        public List<string> ComboList = new List<string>
        {
            "Czech Prague",
            "Florence",
            "London",
            "Moscov",
            "Paris",
            "Tokyo"
        };

        List<string> iSign.ComboList => throw new NotImplementedException();
    }
}
