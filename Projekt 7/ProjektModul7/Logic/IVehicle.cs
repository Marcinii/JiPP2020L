using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IVehicle
    {
        double CountPrice(int hours);
        string GetBrand();
        string GetModel();
        string Name { get; }
        string Type { get;  }
    }
}
