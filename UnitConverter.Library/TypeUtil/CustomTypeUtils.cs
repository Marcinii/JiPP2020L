using System;
using System.Diagnostics;
using UnitConverter.Library.TypeUtil.TypeException;

namespace UnitConverter.Library.TypeUtil
{
    public class CustomTypeUtils
    {
        public static ICustomType createInstanceFrom(Type type, string value)
        {
            Trace.WriteLine(
                string.Format("CustomTypeUtils :: createInstanceFrom :: type: {0}, value: {1}", type, value)
            );

            ICustomType res;

            switch (type.Name)
            {
                case "CustomDouble": res = new CustomDouble().fromString(value); break;
                case "CustomTime": res = new CustomTime().fromString(value); break;
                case "Custom12HTime": res = new Custom12HTime().fromString(value); break;
                default: throw new CreateInstanceCustomTypeException(string.Format("Wprowadzony typ \"{0}\' nie został rozpoznany", type.ToString()));
            }

            return res;
        }


        public static ICustomType createInstanceFrom(Type type, ICustomType value)
        {
            Trace.WriteLine(
                string.Format("CustomTypeUtils :: createInstanceFrom :: type: {0}, value: {1}", type, value.ToString())
            );

            ICustomType res;

            switch (type.Name)
            {
                case "CustomDouble": res = (CustomDouble)value; break;
                case "CustomTime": res = (CustomTime)value; break;
                case "Custom12HTime": res = Custom12HTime.fromCustomTime((CustomTime)value); break;
                default: throw new CreateInstanceCustomTypeException(string.Format("Wprowadzony typ \"{0}\' nie został rozpoznany", type.ToString()));
            }

            return res;
        }
    }
}
