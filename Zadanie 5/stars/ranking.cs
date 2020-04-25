namespace stars
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ranking")]
    public partial class ranking
    {
        public int Id { get; set; }
        public int rating { get; set; }
    }
}
