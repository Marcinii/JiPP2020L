using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Car : IVehicle
    {
        private string brand;
        private string model;
        private string _class;

        public Car(string brand, string model, string _class)
        {
            this.brand = brand;
            this.model = model;
            this._class = _class;
        }

        public string Name => brand + " " + model;

        public string Type => "Car";

        public double CountPrice(int hours)
        {
            double pricePerHour = 0;
            if(_class == "A")
            {
                pricePerHour = 70;
            }
            else if(_class == "B")
            {
                pricePerHour = 100;
            }
            else if(_class == "C")
            {
                pricePerHour = 120;
            }
            else
            {
                throw new Exception("Invalid car class");
            }

            return pricePerHour * hours;
        }

        public string GetModel()
        {
            return model;
        }

        public string GetBrand()
        {
            return brand;
        }
    }
}
