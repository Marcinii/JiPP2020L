using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitConverter.Library.RatingUtil
{
    /// <summary>
    /// Klasa, która reprezentuje rekord w tabeli przechowującej ostatnie oceny użytkowników aplikacji
    /// </summary>
    /// <param name="id">Numer oceny</param>
    /// <param name="value">Wartość oceny</param>
    /// <param name="createdAt">Data utworzenia oceny</param>
    [Table("rating")]
    public class Rating
    {
        [Key]
        public int id { get; set; }
        public int value { get; set; }

        [Column("created_at")]
        public DateTime createdAt { get; set; } = DateTime.Now;


        public Rating() { }

        public Rating(int value)
        {
            this.value = value;
        }
    }
}
