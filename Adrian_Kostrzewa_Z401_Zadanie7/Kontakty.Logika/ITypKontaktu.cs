using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakty
{
    public interface ITypKontaktu
    {
        string NazwaTypu { get; }
        int NumerTypu { get; }
    }
}
