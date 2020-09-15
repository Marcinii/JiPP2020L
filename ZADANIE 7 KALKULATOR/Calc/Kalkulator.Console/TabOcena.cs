using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator.Console
{
    public class TabOcena
    {
        [Key]
        public int ID { get; set; }
        public int Ocena { get; set; }
        public DateTime Czas { get; set; }
    }
}
