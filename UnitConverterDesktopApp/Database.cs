using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverterDesktopApp
{
    public static class Database
    {
        public static void InsertResult(string converterName, string sourceUnit, string targetUnit, string inputValue, string outputValue)
        {
            using (ConverterDataModel context = new ConverterDataModel())
            {
                Result result = new Result()
                {
                    ConversionDate = DateTime.Now,
                    ConverterName = converterName,
                    SourceUnit = sourceUnit,
                    TargetUnit = targetUnit,
                    InputValue = inputValue,
                    OutputValue = outputValue,
                };
                context.Results.Add(result);
                context.SaveChanges();
            }
        }
        public static dynamic SelectResults(List<string> converters, DateTime? dateFrom, DateTime? dateTo, bool? topOnly)
        {
            using (ConverterDataModel context = new ConverterDataModel())
            {
                var results = context.Results.AsQueryable();

                results = results.AsQueryable()
                    .Where(r => converters.Any(c => r.ConverterName.Equals(c)));

                if (dateFrom.HasValue)
                {
                    results = results.Where(
                        r => DbFunctions.TruncateTime(r.ConversionDate) >= dateFrom);
                }
                if (dateTo.HasValue)
                {
                    results = results.Where(
                        r => DbFunctions.TruncateTime(r.ConversionDate) <= dateTo);
                }

                if (topOnly != true)
                {
                    return results.ToList();
                }
                else
                {
                    var topResults = results
                    .GroupBy(x => new { x.ConverterName, x.SourceUnit, x.TargetUnit })
                    .Select(x => new { x.Key.ConverterName, x.Key.SourceUnit, x.Key.TargetUnit, Count = x.Count() })
                    .OrderByDescending(x => x.Count)
                    .Take(3);
                    return topResults.ToList();
                }
            }
        }

    }
}
