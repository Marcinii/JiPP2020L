using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class SavingsAccount: IAccount
    {
        public string Name => "Konto oszczędnościowe";
        public decimal balance = 0;
        public string info = "";


        public decimal Deposit(decimal Value)
        {
            info = "Success";
            return balance += Value;
        }

        public decimal Withdraw(decimal Value)
        {
            if (balance >= Value)
            {
                info = "Success";
                return balance -= Value;
            }
            else
            {
                info = "Not enough money";
                return balance;
            }
        }
    }
}
