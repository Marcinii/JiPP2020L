using FlowerManager.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerManager.Logic
{
    interface ITableControler
    {
        void AddRecord(IRow row);

        void UpdateRecord(int id);

        IRow GetRecord(int id);

        List<IRow> GetRecords();
    }
}
