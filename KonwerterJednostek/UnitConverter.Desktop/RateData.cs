using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Desktop
{
    [Table("ConverterRates")]
    public class RateData
    {
        public int Id { get; set; }
        public int? Rate { get; set; }
        public DateTime? RateDate { get; set; }
    }
}
