using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Desktop
{
    public class GRADES
    {
        [Key]
        public Int64 id { get; set; }
        public Int64 grade { get; set; }
    }
}
