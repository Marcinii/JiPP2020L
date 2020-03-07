using System;
using System.Collections.Generic;
using System.Text;
using UnitConverter.Core;
using UnitConverter.UnitUtil;

namespace UnitConverter.OperationUtil
{
    /// <summary>
    /// Klasa reprezentująca zestaw danych i operacji służących do wykonania podstawowych operacji obliczenowych
    /// <param name="id">Numer operacji (wymagany w aplikacji konsolowej)</param>
    /// <param name="name">Nazwa operacji</param>
    /// <param name="units">Wprowadzone jednostki</param>
    /// </summary>
    /// <see cref="ConverterWizard"/>
    /// <see cref="DefaultConverter"/>
    /// <see cref="WizardResult"/>
    public class Operation
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Unit> units { get; set; }


        public Operation()
        {
            this.units = new List<Unit>();
        }

        public Operation(string name) : this()
        {
            this.name = name;
        }

        public Operation(int id, string name) : this()
        {
            this.id = id;
            this.name = name;
        }



        /// <summary>
        /// Metoda służąca do dodawania nowych jednostek do listy
        /// </summary>
        /// <param name="unit">Jednostka</param>
        public void addUnit(Unit unit)
        {
            this.units.Add(unit);
        }


        /// <summary>
        /// Metoda konwertująca jednostki
        /// </summary>
        /// <param name="value">Wprowadzona wartość w jednostce początkowej</param>
        /// <param name="fromUnit">Początkowa jednostka</param>
        /// <param name="toUnit">Jednostka, na którą chcey wartość skonwertować</param>
        /// <returns>Zwraca skonwertowaną jednostkę</returns>
        public double convert(double value, Unit fromUnit, Unit toUnit)
        {
            DefaultConverter converter = new DefaultConverter(value, fromUnit, toUnit);
            return converter.convert();
        }

        /// <summary>
        /// Metoda uruchamiająca formularz do wprowadzenia niezbędnych danych do konwersji
        /// UWAGA: ta metoda potrzebna jest tylko do aplikacji konsolowej
        /// </summary>
        public void run()
        {
            ConverterWizard wizard = new ConverterWizard(this.units);
            WizardResult res = wizard.run();

            DefaultConverter converter = new DefaultConverter(res.value, res.fromUnit, res.toUnit);
            converter.print();
        }
    }
}
