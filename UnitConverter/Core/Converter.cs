using System;

namespace UnitConverter.Core
{

    enum ConvertTo
    {
        FIRST, SECOND
    }


    abstract class Converter
    {
        protected double value;
        protected ConvertTo convertTo;
        protected string message;

        protected Converter(double value, ConvertTo convertTo)
        {
            this.value = value;
            this.convertTo = convertTo;
            this.setMessage();
        }


        protected abstract double convert();
        protected abstract void setMessage();

        public void print()
        {
            Console.WriteLine();
            Console.WriteLine("#----------------------------------------------------#");
            Console.WriteLine("# {0}", String.Format(this.message, value, convert()));
            Console.WriteLine("#----------------------------------------------------#");
        }
    }
}
