using System;
using Logic.Model.Enums;

namespace Logic.Model.Queries
{
    public class ConversionQuery : Query
    {
        public ConversionQuery(int page, int itemsPerPage) : base(page, itemsPerPage)
        {
        }
        public ESortType SortMethod { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
