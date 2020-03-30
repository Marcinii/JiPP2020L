namespace UnitConverter.Wpf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Record
    {
        [Key]
        public int id { get; set; }

        public DateTime date { get; set; }

        [Required]
        [StringLength(20)]
        public string converter { get; set; }

        public double inputValue { get; set; }

        [Required]
        [StringLength(10)]
        public string inputUnit { get; set; }

        public double outputValue { get; set; }

        [Required]
        [StringLength(10)]
        public string outputUnit { get; set; }
    }
}
