using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unitConverterv2;

namespace UnitConverterv2.Logic
{
    public class ConverterService
    {
        public List<IConvert> getConverters()
        {
            return new List<IConvert>()
            {
              new tempConverter(),
              new lengthCon(),
              new weightConverter(),
              new SurfaceConvert(),
              new Clock()

            };
        }
    }
}
