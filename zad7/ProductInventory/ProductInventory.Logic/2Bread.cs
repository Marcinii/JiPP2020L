using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory
{
    public class Bread : IInventory
    {
        public string Name => "Chleb";

        public int Id => 2;

        public List<Item> Items => new List<Item>
        {
            new Item(0, "Slowianski", 2.99),
            new Item(1, "Cale Ziarno", 3.49),
            new Item(2, "Z Ziarnami", 2.99),
            new Item(3, "Krojony", 1.59),
            new Item(4, "Wiejski Pano Krojony", 2.69)
        };
        public List<string> ItemsNames => new List<string>
        {
            "Slowianski",
            "Cale Ziarno",
            "Z Ziarnami",
            "Krojony",
            "Wiejski Pano Krojony"
        };
    }
}
