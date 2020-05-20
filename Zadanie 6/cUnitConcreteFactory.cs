using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using application;


namespace application
{
    public class cUnitConcreteFactory : cUnitFactory
    {
        override public iUnit unitBuilder(int externalchoice)
        {

            switch (externalchoice)
            {
                case 1:
                    return new cTime();
                case 2:
                    return new cTemperature();
                case 3:
                    return new cDistance();
                case 4:
                    return new cWeight();
                default: return null;
            }
        }
    }
}