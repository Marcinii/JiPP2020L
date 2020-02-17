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
        private string inputUnit, outputUnit;

        private bool isValueValid = false;

        public Converter()
        {
            inputUnit = "";
            outputUnit = "";
        }

        public void enterData()
        {
            Console.WriteLine($"*** Convert {this.inputUnit} to {this.outputUnit} ***");
            Console.WriteLine("Please enter the value to convert: ");
            string inputString = Console.ReadLine();

            if (!Double.TryParse(inputString, out this.valueToConvert))
            {
                Console.WriteLine("Invalid input value. Please try again.");
            }
            else
            {
                this.isValueValid = true;
            }
        }
        public void printResult()
        {
            Console.WriteLine($"{this.valueToConvert} {this.inputUnit} is equal to {this.result} {this.outputUnit}.");
        }
        public void celsiusToFahrenheit()
        {
            this.inputUnit = "Celsius";
            this.outputUnit = "Fahrenheit";
            this.enterData();
            if (this.isValueValid)
            {
                this.result = (this.valueToConvert * 1.80) + 32.0;
                this.isValueValid = false;
                this.printResult();
            }
        }
        public void fahrenheitToCelsius()
        {
            this.inputUnit = "Fahrenheit";
            this.outputUnit = "Celsius";
            this.enterData();
            if (this.isValueValid)
            {
                this.result = (this.valueToConvert - 32.0) / 1.80;
                this.isValueValid = false;
                this.printResult();
            }
        }
        public void kilometersToMiles()
        {
            this.inputUnit = "kilometers";
            this.outputUnit = "miles";
            this.enterData();
            if (this.isValueValid)
            {
                this.result = this.valueToConvert / 1.609344;
                this.isValueValid = false;
                this.printResult();
            }
        }
        public void milesToKilometers()
        {
            this.inputUnit = "miles";
            this.outputUnit = "kilometers";
            this.enterData();
            if (this.isValueValid)
            {
                this.result = this.valueToConvert * 1.609344;
                this.isValueValid = false;
                this.printResult();
            }
        }
        public void kilogramsToPounds()
        {
            this.inputUnit = "kilograms";
            this.outputUnit = "pounds";
            this.enterData();
            if (this.isValueValid)
            {
                this.result = this.valueToConvert * 2.2046;
                this.isValueValid = false;
                this.printResult();
            }
        }
        public void poundsToKilograms()
        {
            this.inputUnit = "pounds";
            this.outputUnit = "kilograms";
            this.enterData();
            if (this.isValueValid)
            {
                this.result = this.valueToConvert / 2.2046;
                this.isValueValid = false;
                this.printResult();
            }
        }
    }
}
