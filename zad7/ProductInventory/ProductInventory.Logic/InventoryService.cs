using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory
{
    public class InventoryService
    {
        public List<IInventory> GetInventories() => new List<IInventory>()
            {
                new Water(),
                new Drink(),
                new Bread(),
                new Mayonnaise(),
                new Ketchup()
            };
    }
}
