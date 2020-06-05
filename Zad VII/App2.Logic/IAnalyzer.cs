using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Logic
{
    interface IAnalyzer
    {
        int letterno();
        double entropy();
    }
}
