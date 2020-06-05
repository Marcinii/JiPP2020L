using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Logic
{
    public class Analyze : IAnalyzer
    {
        public string texts;
        public Analyze(string texts)
        {
            this.texts = texts;
        }

        public int letterno()
        {
            int counter = 0;

            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i] == ' ') continue;
                else counter++;
            }

            return counter;
        }

        public double entropy()
        {
            double tmp = Math.Log(letterno(), 2);
            return tmp;
        }
    }
}
