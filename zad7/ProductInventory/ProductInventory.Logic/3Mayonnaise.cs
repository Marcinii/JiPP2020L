using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory
{
    public class Mayonnaise :IInventory
    {
        public string Name => "Majonez";

        public int Id => 3;

        public List<Item> Items => new List<Item>
        {
            new Item(0, "Kielecki", 5.99),
            new Item(1, "Winiary", 4.99),
            new Item(2, "Roleski", 5.79),
            new Item(3, "Hellmann's", 6.29)
        };
        public List<string> ItemsNames => new List<string>
        {
            "Kielecki",
            "Winiary",
            "Roleski",
            "Hellmann's"
        };
    }
}
