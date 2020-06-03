using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Scooter : IVehicle
    {
        private string brand;
        private string model;
        private double price;

        public Scooter(string brand, string model, double price)
        {
            this.brand = brand;
            this.model = model;
            this.price = price;
        }

        public string Name => brand + " " + model;

        public string Type => "Scooter";

        public double CountPrice(int hours)
        {
            return hours * price;
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
