using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_7
{
    public class MyRate
    {
        [Key]
        public int id { get; set; }
        public int rate_value { get; set; }
    }
}
