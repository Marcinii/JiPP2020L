using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Storage.Logic
{
    class Motocycle : IStorageLogicApp
    {
        public string type => "Motocycle";

        public List<string> company => new List<string>()
        {
            "KTM",
            "Yamaha",
            "Romet",
            "Ducati",
            "Aprilla",
            "Kawasaki",
            "Triumph"
        };
        public int Tax => 4;

        public double CountInsurance(int Tax, double capacity, double value)
        {
            value += (value * (Tax) * capacity * capacity) / 500;
            return value;
        }
    }
}
