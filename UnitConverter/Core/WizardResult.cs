using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Core
{
    class WizardResult
    {
        public ConvertTo convertTo { get; private set; }
        public double value { get; set; }



        public void setOption(int option)
        {
            switch(option)
            {
                case 1: this.convertTo = ConvertTo.FIRST; break;
                case 2: this.convertTo = ConvertTo.SECOND; break;
            }
        }
    }
}
