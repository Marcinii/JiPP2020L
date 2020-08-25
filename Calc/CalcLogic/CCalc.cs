using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLogic
{
    public class CCalc
    {
        double total = 0;
        List<IOperation> ops = new List<IOperation>
        {
            new CAdder(),
            new CSubstractor(),
            new CDivider(),
            new CMultiplier(),
        };

        IOperation FindOperation(string name)
        {
            foreach (IOperation op in ops)
            {
                if (op.Name == name)
                {
                    return op;
                }
            }
            return null;
        }

        IOperation Adder()
        {
            return FindOperation("Adder");
        }

        IOperation Substractor()
        {
            return FindOperation("Substractor");
        }

        IOperation Divider()
        {
            return FindOperation("Divider");
        }

        IOperation Multiplier()
        {
            return FindOperation("Multiplier");
        }

        public void Add(double x)
        {
            this.total = Adder().Execute(this.total, x);
        }

        public void Substract(double x)
        {
            this.total = Substractor().Execute(this.total, x);
        }

        public void Divide(double x)
        {
            this.total = Divider().Execute(this.total, x);
        }

        public void Multiply(double x)
        {
            this.total = Multiplier().Execute(this.total, x);
        }

        public double Result()
        {
            return this.total;
        }
    }
}
