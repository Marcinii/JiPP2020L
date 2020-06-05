using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class VirtualAccount : IAccount
    {
        public string Name => "Konto wirtualne";
        public decimal balance = 0;
        public string info = "";


        public decimal Deposit(decimal Value)
        {
            info = "Success";
            return balance += 2*Value;
        }

        public decimal Withdraw(decimal Value)
        {
            if (balance >= Value)
            {
                info = "Success";
                return balance -= Value/2;
            }
            else
            {
                info = "Not enough money";
                return balance;
            }
        }
    }
}
