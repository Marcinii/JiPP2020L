using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia.Logic
{
    public interface IBookstoreItem
    {
        string Title { get; set; }
        float Price { get; set; }
        int Count { get; set; }
        int Sold { get; set; }

        Task Save();
        Task Edit();

    }
}
