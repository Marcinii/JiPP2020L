using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Storage.Logic
{
    class Car : IStorageLogicApp
    {
        public string type => "Cars";

        public List<string> company => new List<string>()
        {
            "Audi",
            "Alfa Romero",
            "BMW",
            "Honda",
            "Fiat",
            "Volvo",
            "Opel",
            "Volkswagen",
            "Mercedes Benz",
            "Ford",
            "Toyota",
            "Jaguar",
            "Chevrolet",
            "Dodge"


        };

        public int Tax => 9;

        public double CountInsurance( int Tax, double capacity, double value)
        {

            value += (value * (Tax) * capacity * capacity)/700; 
            return value;
        }
    }
}
