using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Logic
{
    public interface IDice
    {
        string name { get; }
        int[]  values { get; }
        int max_amount { get; }
        int[] Throw(int amount);
    }
}
