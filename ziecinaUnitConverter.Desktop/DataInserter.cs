using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.EntityFrameworkCore;
using DbContext = System.Data.Entity.DbContext;

namespace ziecinaUnitConverter.Desktop
{
    public class DataInserter
    {
        public void InsertData(string Converter0, string unitFrom0, string unitTo0, string valueBefore0, string valueAfter0, bool errorEncountered0)
        {
            var context = new KASETY_412_23Entities1();
            var toInsert = new JIPP4 { Converter = Converter0, unitFrom = unitFrom0, unitTo = unitTo0, valueBefore = valueBefore0, valueAfter = valueAfter0, errorEncountered = errorEncountered0, dateSent = DateTime.Now};
            context.JIPP4.Add(toInsert);
            context.SaveChanges();
        }
    }
}
