using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using application;

namespace application
{
    public class cWeight : iUnit
    {
        public List<string> UnitsList = new List<string>
        {
            "kg --> pounds",
            "pounds --> kg"
        };

        List<string> iUnit.UnitsList => throw new NotImplementedException();

      

    }
}