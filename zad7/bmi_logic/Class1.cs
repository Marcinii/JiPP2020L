using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmi_logic
{
    public class Bmi_calculator
    {
        public float calculate_bmi(float weight, float height)
        {
            return weight / ((height / 100) * (height/100));
        }
    }
}
