using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Desktop
{
    public class MostPopularConversion
    {
        [Key]
        public Int64 id { get; set; }
        public string name { get; set; }
        public string unitFrom { get; set; }
        public string unitTo { get; set; }
        public int ile { get; set; }
    }
}
