using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_ver01.Desktop
{
    public class RateDa
    {
        [Key]
        public int IdRate { get; set; }
        public int RateValue { get; set; }
    }
}
