using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_converter
{
    public class Converter
    {
        private double valueToConvert, result;
        private bool isValueValid = false;

        public Converter() { }
        private void enterData()
        {
            Console.WriteLine("Please enter the value to convert: ");
            double inputDouble;            
            string inputString = Console.ReadLine();

            if (!Double.TryParse(inputString, out inputDouble))
            {
                Console.WriteLine("Invalid input value");
            }
            else
            {
                this.valueToConvert = inputDouble;
                this.isValueValid = true;
            }
        }
        private void printResult(string inputUnit, string outputUnit)
        {
            Console.WriteLine($"{Math.Round(this.valueToConvert, 2, MidpointRounding.AwayFromZero)} {inputUnit} is equal to " +
                $"{Math.Round(this.result, 2, MidpointRounding.AwayFromZero)} {outputUnit}");
        }
        public void celsiusToFahrenheit()
        {
            this.enterData();
            if (this.isValueValid)
            {
                this.result = (this.valueToConvert * 1.80) + 32.0;
                this.isValueValid = false;
                this.printResult(Unit.Celsius(), Unit.Fahrenheit());
            }
        }
        public void fahrenheitToCelsius()
        {
            this.enterData();
            if (this.isValueValid)
            {
                this.result = (this.valueToConvert - 32.0) / 1.80;
                this.isValueValid = false;
                this.printResult(Unit.Fahrenheit(), Unit.Celsius());
            }
        }
        public void kilometersToMiles()
        {
            this.enterData();
            if (this.isValueValid)
            {
                this.result = this.valueToConvert / 1.609344;
                this.isValueValid = false;
                this.printResult(Unit.Kilometers(), Unit.Miles());
            }
        }
        public void milesToKilometers()
        {
            this.enterData();
            if (this.isValueValid)
            {
                this.result = this.valueToConvert * 1.609344;
                this.isValueValid = false;
                this.printResult(Unit.Miles(), Unit.Kilometers());
            }
        }
        public void kilogramsToPounds()
        {
            this.enterData();
            if (this.isValueValid)
            {
                this.result = this.valueToConvert * 2.2046;
                this.isValueValid = false;
                this.printResult(Unit.Kilograms(), Unit.Pounds());
            }
        }
        public void poundsToKilograms()
        {
            this.enterData();
            if (this.isValueValid)
            {
                this.result = this.valueToConvert / 2.2046;
                this.isValueValid = false;
                this.printResult(Unit.Pounds(), Unit.Kilograms());
            }
        }
    }
}
