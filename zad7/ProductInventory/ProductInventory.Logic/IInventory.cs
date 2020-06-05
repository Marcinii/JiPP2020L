using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory
{
    public interface IInventory
    {
        string Name { get; }
        int Id { get; }
        List<Item> Items { get; }
        List<string> ItemsNames { get; }
    }
}
