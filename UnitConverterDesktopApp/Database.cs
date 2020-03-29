using System;
using System.Collections.Generic;
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
        public static List<Result> SelectResults()
        {
            using (ConverterDataModel context = new ConverterDataModel())
            {
                List<Result> results = context.Results.ToList();
                return results;
            }
        }
    }
}
