using System;
using System.Collections.Generic;
using UnitConverter.UnitUtil;

namespace UnitConverter.Core
{

    /// <summary>
    /// Klasa służąca do stworzenia mini-formularza,
    /// do którego będziemy wprowadzali niezbędne dane do konwersji jednostek
    /// <param name="units">Lista ze wszystkimi możliwymi jednostkami</param>
    /// <see cref="WizardResult"/>
    /// </summary>
    public class ConverterWizard
    {
        private List<Unit> units;

        public ConverterWizard(List<Unit> units)
        {
            this.units = units;
        }

        public ConverterWizard() : this(new List<Unit>()) {}


        /// <summary>
        /// Metoda uruchamiająca formularz do wprowadzenia niezbędnych danych do konwersji.
        /// </summary>
        /// <returns>Zwraca obiekt klasy WzardResult, która przechowuje dane wpisane w formularzu</returns>
        public WizardResult run()
        {
            CommandValidator validator = new CommandValidator(this.units.Count);   
            WizardResult res = new WizardResult();
            Console.WriteLine("######################################################");
            Console.WriteLine("# Z czego chcesz skonwertować (wybierz jedną z opcji)?");
            Console.WriteLine("#----------------------------------------------------#");

            for(int i = 0; i < this.units.Count; i++)
            {
                Console.WriteLine("# {0}. {1}", i + 1, this.units[i].name);
            }
            Console.WriteLine("#----------------------------------------------------#");


            Console.Write("> ");
            int fromValue = AppConsole.readInt(validator);


            Console.WriteLine("######################################################");
            Console.WriteLine("# Na co chcesz skonwertować (wybierz jedną z opcji)?");
            Console.WriteLine("#----------------------------------------------------#");

            for (int i = 0; i < this.units.Count; i++)
            {
                Console.WriteLine("# {0}. Na {1}", i + 1, this.units[i].name);
            }
            Console.WriteLine("#----------------------------------------------------#");

            Console.Write("> ");
            int toValue = AppConsole.readInt(validator);

            Console.WriteLine("#----------------------------------------------------#");
            Console.Write("# Podaj wartość ({0}): ", this.units[fromValue - 1].name);

            res.value = AppConsole.readDouble();
            res.fromUnit = this.units[fromValue - 1];
            res.toUnit = this.units[toValue - 1];

            return res;
        }

        /// <summary>
        /// Metoda służąca do umieszczenia nowej jednostki miary w kolekcji {units}
        /// </summary>
        /// <param name="step">
        ///     Nazwa jednostki. Jako argument przkmujemy liste jednostek (wpisywanych po przecinku)
        /// </param>
        public void addUnitName(params Unit[] step)
        {
            for(int i = 0; i < step.Length; i++)
            {
                this.units.Add(step[i]);
            }
        }
    }
}
