using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Abstract
{
    abstract class Converter
    {
        protected FromValue _from;
        protected ToValue to;

        protected Converter(FromValue _from, ToValue to)
        {
            this._from = _from;
            this.to = to;
        }

        public abstract double convert();
    }
}
