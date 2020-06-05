using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory
{
    public class Item
    {
        public int IdP;
        public string Name;
        public double Price;


        public Item(int IdP, string Name, double Price)
        {
            this.IdP = IdP;
            this.Name = Name;
            this.Price = Price;
        }
        public Item()
        {
            this.IdP = 0;
            this.Name = "";
            this.Price = 0;
        }
        public double Sum(int quantity)
        {
            double result = this.Price * quantity;
            return result;
        }
    }
}
