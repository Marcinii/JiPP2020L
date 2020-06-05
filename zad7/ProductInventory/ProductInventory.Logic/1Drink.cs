using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory
{
    public class Drink : IInventory
    {
        public string Name => "Napoj";

        public int Id => 1;

        public List<Item> Items => new List<Item>
        {
            new Item(0, "Coca Cola", 4.11),
            new Item(1, "Sprite", 4.32),
            new Item(2, "Tymbark", 1.89),
            new Item(3, "Hortex", 4.03),
            new Item(4, "Pepsi", 3.44),
            new Item(5, "Fanta", 3.90)
        };
        public List<string> ItemsNames => new List<string>
        {
            "Coca Cola",
            "Sprite",
            "Tymbark",
            "Hortex",
            "Pepsi",
            "Fanta"
        };
    }
}
