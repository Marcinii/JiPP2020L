namespace Calendar
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hotel")]
    public partial class hotel
    {
        public long id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public byte[] password { get; set; }

        [MaxLength(50)]
        public byte[] pets { get; set; }

        [Required]
        [StringLength(50)]
        public string city { get; set; }

        public short peopleNumber { get; set; }

        public int days { get; set; }

        [StringLength(50)]
        public string quality { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime calendarDay { get; set; }

        public decimal price { get; set; }
    }
}
