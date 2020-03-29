using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverterDesktopApp
{
    public class Result
    {
        public int Id { get; set; }
        public DateTime ConversionDate { get; set; }
        public string ConverterName { get; set; }
        public string SourceUnit { get; set; }
        public string TargetUnit { get; set; }
        public string InputValue { get; set; }
        public string OutputValue { get; set; }
    }
}
