using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Czesc!");
            List<IInventory> Inventories = new InventoryService().GetInventories();




            if (false) { }
        }
    }
}
