using System;
using System.Collections.Generic;
using System.Text;
using Counting_;

namespace Counting_
{
    class quality: iSign
    {
        public List<string> ComboList = new List<string>
        {
            "VIP",
            "world class",
            "mid-range",
            "budget / limited"

        };

        List<string> iSign.ComboList => throw new NotImplementedException();
    }
}
