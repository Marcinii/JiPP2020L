using System.Collections.Generic;

namespace Storage.Logic
{
    class TruckInformation : IStorageLogicApp
    {

        public string type => "Trucks";

        public List<string> company => new List<string>()
        {
            "Mercedes",
            "Man",
            "Volvo",
            "Iveco",
            "Scania",
            "Daf",

        };




        public int Tax => 13;
        public double CountInsurance( int Tax, double capacity, double value)
        {

            value += (value/capacity) * (Tax / 3);

            return value;
        }


    }
}
