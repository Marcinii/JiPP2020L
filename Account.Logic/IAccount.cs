using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public interface IAccount
    {
        string Name { get; }
        decimal Deposit(decimal Value);
        decimal Withdraw(decimal Value);
    }
}
