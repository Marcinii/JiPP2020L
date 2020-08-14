using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Logic
{
    public class K6 : IDice
    {
        int[] array = { 1, 2, 3, 4, 5, 6 };
        public string name => "K6";
        public int[] values => array;
        public int max_amount => 4;
        public int[] Throw(int amount)
        {
            int[] result = new int[amount];

            Random random = new Random();

            for (int i = 1; i <= amount; i++)
            {
                result[i - 1] = values[random.Next(0, values.Length)];
            }

            return result;
        }
    }
}
