using System.Collections.Generic;
using UniConverter;

namespace unitConverter.Logic
{
    public class ConverterService
    {
        public List<Iconventer> GetConverters()
        {
            return new List<Iconventer>()
            {
                new temp(),
                new lenght(),
                new speed(),
                new zegar()


            };
        }





    }
}
