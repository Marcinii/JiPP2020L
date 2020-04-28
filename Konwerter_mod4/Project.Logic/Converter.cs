using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project.Logic
{
    public class Converter
    {
        [Key]
        public int ID_Converter { get; set; }
        public string Converter_Type { get; set; }
        public string Unit_from { get; set; }
        public string Unit_to { get; set; }
        public DateTime Date_of_Conversion { get; set; }
        public string Converted_Value { get; set; }
        public int? Rating_Value { get; set; }
    }
}
