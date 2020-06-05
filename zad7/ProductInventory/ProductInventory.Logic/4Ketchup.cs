using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory
{
    public class Ketchup : IInventory
    {
        public string Name => "Ketchup";

        public int Id => 4;

        public List<Item> Items => new List<Item>
        {
            new Item(0, "Kotlin", 4.38),
            new Item(1, "Heinz", 8.34),
            new Item(2, "Tortex", 6.49),
            new Item(3, "Pudliszki", 7.36)
        };
        public List<string> ItemsNames => new List<string>
        {
            "Kotlin",
            "Heinz",
            "Tortex",
            "Pudliszki"
        };
    }
}
