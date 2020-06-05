using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory
{
    public class Water : IInventory
    {
        public string Name => "Woda";

        public int Id => 0;

        public List<Item> Items => new List<Item>
        {
            new Item(0, "Cisowianka", 1.18),
            new Item(1, "Naleczowianka", 2.09),
            new Item(2, "Kropla Beskidu", 1.89),
            new Item(3, "Zywiec Zdroj", 2.59),
            new Item(4, "Muszynianka", 3.12),
            new Item(5, "Saguaro", 1.98),
            new Item(6, "Kinga Pieninska", 1.20)
        };

        public List<string> ItemsNames => new List<string>
        {
            "Cisowianka",
            "Naleczowianka",
            "Kropla Beskidu",
            "Zywiec Zdroj",
            "Muszynianka",
            "Saguaro",
            "Kinga Pieninska"
        };
    }
}
