using System;
using System.Collections.Generic;

namespace UnitConverter.Core
{

    class ConverterWizard
    {
        private List<string> units;


        public ConverterWizard()
        {
            this.units = new List<string>();
        }


        public WizardResult run()
        {
            WizardResult res = new WizardResult();
            Console.WriteLine("######################################################");
            Console.WriteLine("# Na co chcesz skonwertować (wybierz jedną z opcji)?");
            Console.WriteLine("#----------------------------------------------------#");

            for(int i = 0; i < this.units.Count; i++)
            {
                Console.WriteLine("# {0}. Na {1}", i + 1, this.units[i]);
            }

            Console.WriteLine("#----------------------------------------------------#");

            Console.Write("> ");
            int option = Convert.ToInt32(Console.ReadLine());

            while (option < 0 && option > this.units.Count)
            {
                Console.WriteLine("!!! Nie rozpoznano komendy. Wprowadź poprawny numer komendy");
                Console.Write("> ");
                option = Convert.ToInt32(Console.ReadLine());
            }


            res.setOption(option);

            Console.WriteLine("#----------------------------------------------------#");
            Console.Write("# Podaj wartość ({0}): ", this.units[(this.units.Count + option) % this.units.Count]);
            double input = Convert.ToDouble(Console.ReadLine());

            res.value = input;

            return res;
        }

        public void addUnitName(params string[] step)
        {
            for(int i = 0; i < step.Length; i++)
            {
                this.units.Add(step[i]);
            }
        }
    }
}
