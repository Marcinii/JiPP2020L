using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Bike : IVehicle
    {
        private string brand;
        private string model;
        private string type;
        private double price;

        public Bike(string brand, string model, string type, double price)
        {
            this.brand = brand;
            this.model = model;
            this.type = type;
            this.price = price;
        }

        public string Name => brand + " " + model;

        public string Type => "Bike";

        public double CountPrice(int hours)
        {
            double rate = 0;
            if(type == "kross")
            {
                rate = 1.1;
            }
            else if(type == "city")
            {
                rate = 1.2;
            }
            else
            {
                throw new Exception("Invalid bike type");
            }

            return rate * price * hours;
        }

        public string GetBrand()
        {
            return brand;
        }

        public string GetModel()
        {
            return model;
        }
    }
}
