using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Logic
{
    public class InterfaceService
    {
        public List<IStorageLogicApp> getTypes()
        {
            return new List<IStorageLogicApp>()
            {
                new Car(),
                new TruckInformation(),
                new Motocycle(),
                new Van(),
            };
        }
}
    }

