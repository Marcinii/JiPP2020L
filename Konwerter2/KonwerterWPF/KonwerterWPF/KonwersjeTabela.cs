namespace KonwerterWPF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KonwersjeTabela")]
    public partial class KonwersjeTabela
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nazwa { get; set; }

        public DateTime czas { get; set; }

        [Required]
        [StringLength(50)]
        public string wartosc_a { get; set; }

        [Required]
        [StringLength(50)]
        public string wartosc_b { get; set; }
    }
}
