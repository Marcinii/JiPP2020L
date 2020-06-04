using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadLogic
{
    public class DeadTime : IDeadConv
    {
        public int deadEnd(int Age, int HandAge, int Traning)
        {
            int Value = 125;

            Value -= Age;
            if(HandAge == 0)
            {
                Value -= 5;

            }
            if (Traning == 0)
            {
                Value /= 3;
            }
            else if(Traning >= 1 && Traning <= 3)
            {
                Value /= 2;
            }
            else if (Traning > 3)
            {
                Value /= 1;
            }

            return Value;
        }

    }
}
