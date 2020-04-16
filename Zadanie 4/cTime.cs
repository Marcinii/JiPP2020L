using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using application;

namespace application
{
    public class cTime : iUnit
    {
        public List<string> UnitsList = new List<string>
        {
            "hours --> minutes",
            "minutes --> hours"
        };

        List<string> iUnit.UnitsList => throw new NotImplementedException();

    }
}