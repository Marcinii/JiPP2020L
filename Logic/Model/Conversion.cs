using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Model
{
    public class Conversion
    {
        public int Id { get; set; }
        public int KindId { get; set; }
        public ConverterKind ConverterKind { get; set; }
        public string FromValue { get; set; }
        public string ToValue { get; set; }
        public DateTime Date { get; set; }
    }
}
