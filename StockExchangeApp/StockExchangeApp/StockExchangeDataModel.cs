using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockExchangeApp.Desktop
{
    [Table("StockExchange")]
    public class StockExchangeDataModel
    {
        [Key]
        public int Id { get; set; }
        public string Country { get; set; }
        public int NumberOfStocksToCompute { get; set; }
        public string TypeOfTransaction { get; set; }
        public int AmountOfStocksToExchange { get; set; }
        public string Stocks_1 { get; set; }
        public string Stocks_2 { get; set; }
        public string Stocks_3 { get; set; }
        public string Stocks_4 { get; set; }
        public DateTime? StockExchangeDate { get; set; }
    }
}
