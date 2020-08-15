using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Model
{
    public class ConverterKind
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }
    }
}
