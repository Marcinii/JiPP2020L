namespace application
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatTable")]
    public partial class StatTable
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ConverterType { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitFrom { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitTo { get; set; }

        [Required]
        [StringLength(50)]
        public string ValueFrom { get; set; }

        [Required]
        [StringLength(50)]
        public string ValueTo { get; set; }

        public DateTime ClickDate { get; set; }
    }
}
