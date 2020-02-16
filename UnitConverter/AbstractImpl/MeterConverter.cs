using System;
using System.Collections.Generic;
using System.Text;
using UnitConverter.Abstract;

namespace UnitConverter.AbstractImpl
{
    class MeterConverter : Converter
    {

        public MeterConverter(FromValue _from, ToValue to) : base(_from, to)
        { }

        public override double convert()
        {
            throw new NotImplementedException();
        }
    }
}
