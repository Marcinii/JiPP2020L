using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class ConverterService
    {
        public List<IConverter> GetNames()
        {
            return new List<IConverter>()
            {
                new bitnab(),
                new bnabit(),
                new cnaf(),
                new cnakm(),
                new cnam(),
                new fnac(),
                new fnakg(),
                new kgnaf(),
                new kmnac(),
                new kmnam(),
                new mnac(),
                new mnakm(),
                new zegar()
            };
        }
    }
}
