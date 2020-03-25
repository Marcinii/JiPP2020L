using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{

    public interface IConverter
    {
        //double Convert(string unitFrom, string unitTo, double value);
        string Convert(string unitFrom, string unitTo, string stringValue);
        string Name { get; }
        List<string>Units { get; }
    }

    public abstract class IConverterDefault : IConverter
    {
        public virtual List<string> Units { get => new List<string>(ValueDictionary?.Keys); }

        public abstract string Name { get; }

        protected Dictionary<string, double> ValueDictionary;

        //public double Convert(string unitFrom, string unitTo, double value)
        //{
        //    try
        //    {
        //        return value * (ValueDictionary[unitFrom] / ValueDictionary[unitTo]);
        //    }
        //    catch (Exception)
        //    {
        //        return value;
        //    }
        //}
        public string Convert(string unitFrom, string unitTo, string stringValue)
        {
            double value = 0;
            try
            {
                Double.TryParse(stringValue, out value);

                return (value * (ValueDictionary[unitFrom] / ValueDictionary[unitTo])).ToString();
            }
            catch (Exception)
            {
                return stringValue;
            }
        }
    }

}
