using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeApp.Desktop
{
    [Table("MajorMarketIndice")]
    public class MajorMarketIndiceDataModel
    {
        [Key]
        public int Id { get; set; }
        public int? MajorIndice { get; set; }
        public DateTime? IndiceDate { get; set; }
    }
}
