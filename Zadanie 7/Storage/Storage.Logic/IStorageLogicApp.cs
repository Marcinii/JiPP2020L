using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Logic
{
    public interface IStorageLogicApp
    {
        
        string type { get; }
        List<string> company { get; }
        int Tax { get; }
        

        double CountInsurance(int Tax, double capacity, double value);




    }
}
