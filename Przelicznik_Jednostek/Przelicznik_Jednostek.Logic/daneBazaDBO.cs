using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Przelicznik_Jednostek.Logic
    {
        public class daneBazaDBO
        {
            [Key]
            public int id_konwersja { get; set; }
            public string typ_konwersji { get; set; }
            public string jed_przed { get; set; }
            public string jed_po { get; set; }
            public DateTime data_konwersji { get; set; }
        }
    public class ocenaDBO
    {
        [Key]
        public int id { get; set; }
        public int ocena { get; set; }
    }
    }