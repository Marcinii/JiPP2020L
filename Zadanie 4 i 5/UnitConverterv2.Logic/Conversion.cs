using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverterv2.Logic
{
    public class Conversion
    {
        public int? Id { get; set; }

        public string Type { get; set; }

        public string UnitFrom { get; set; }
        public decimal? ValueFrom { get; set; }

        public string UnitTo { get; set; }
        public decimal? ValueTo { get; set; }

        public DateTime? Date { get; set; }


        public void Save()
        {
            using (ConverterDataModel context = new ConverterDataModel())
            {
                context.Conversions.Add(this);
                context.SaveChanges();
            }
        }

        public static List<Conversion> LoadConversions()
        {
            using (ConverterDataModel context = new ConverterDataModel())
            {
                return context.Conversions.ToList();
            }
        }

        public static List<Conversion> LoadConversionPage(int pageNumber)
        {
            using (ConverterDataModel context = new ConverterDataModel())
            {
                return context.Conversions.OrderBy(x => x.Id).Skip((pageNumber-1) * 20).Take(20).ToList();
            }
        }

        public static List<Conversion> LoadConversionPage(int pageNumber, DateTime dateFrom, DateTime dateTo)
        {
            using (ConverterDataModel context = new ConverterDataModel())
            {
                return context.Conversions.Where(x => x.Date >= dateFrom && x.Date <= dateTo).OrderBy(x => x.Id).Skip((pageNumber - 1) * 20).Take(20).ToList();
            }
        }
        public static List<Conversion> LoadConversionPage(int pageNumber, string ConverterName)
        {
            using (ConverterDataModel context = new ConverterDataModel())
            {
                return context.Conversions.Where(x => x.Type == ConverterName).OrderBy(x => x.Id).Skip((pageNumber - 1) * 20).Take(20).ToList();
            }
        }
        public static List<Conversion> LoadConversionPage(int pageNumber, string ConverterName, DateTime dateFrom, DateTime dateTo)
        {
            using (ConverterDataModel context = new ConverterDataModel())
            {
                return context.Conversions.Where(x => (x.Type == ConverterName) && (x.Date >= dateFrom && x.Date <= dateTo)).OrderBy(x => x.Id).Skip((pageNumber - 1) * 20).Take(20).ToList();
            }
        }

    }
}
