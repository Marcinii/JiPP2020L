using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using application;

namespace application
{
    public class cDistance : iUnit
    {

        public List<string> UnitsList = new List<string>
        {
            "km --> miles",
            "miles --> km",
            "m --> mm",
            "mm --> m"
        };

        List<string> iUnit.UnitsList => throw new NotImplementedException();


        
    }
}