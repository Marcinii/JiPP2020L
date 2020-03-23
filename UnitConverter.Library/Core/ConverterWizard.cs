using System;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.TypeUtil;
using UnitConverter.Library.Validator;

namespace UnitConverter.Library.Core
{

    /// <summary>
    /// Klasa służąca do stworzenia mini-formularza,
    /// do którego będziemy wprowadzali niezbędne dane do konwersji jednostek
    /// <param name="units">Lista ze wszystkimi możliwymi jednostkami</param>
    /// <see cref="WizardResult"/>
    /// </summary>
    public class ConverterWizard
    {
        public UnitOperation operation { get; private set; }

        public ConverterWizard(UnitOperation operation)
        {
            this.operation = operation;
        }


        /// <summary>
        /// Metoda uruchamiająca formularz do wprowadzenia niezbędnych danych do konwersji.
        /// </summary>
        /// <returns>Zwraca obiekt klasy WzardResult, która przechowuje dane wpisane w formularzu</returns>
        public ICustomType run()
        {
            CommandValidator validator = new CommandValidator(this.operation.units.Count);

            Console.WriteLine("######################################################");
            Console.WriteLine("# Z czego chcesz skonwertować (wybierz jedną z opcji)?");
            Console.WriteLine("#----------------------------------------------------#");

            for(int i = 0; i < this.operation.units.Count; i++)
            {
                Console.WriteLine("# {0}. {1}", i + 1, this.operation.units[i].name);
            }
            Console.WriteLine("#----------------------------------------------------#");


            Console.Write("> ");
            this.operation.selectFromUnit(AppConsole.readInt(validator) - 1);


            Console.WriteLine("######################################################");
            Console.WriteLine("# Na co chcesz skonwertować (wybierz jedną z opcji)?");
            Console.WriteLine("#----------------------------------------------------#");

            for (int i = 0; i < this.operation.units.Count; i++)
            {
                Console.WriteLine("# {0}. Na {1}", i + 1, this.operation.units[i].name);
            }
            Console.WriteLine("#----------------------------------------------------#");

            Console.Write("> ");
            this.operation.selectToUnit(AppConsole.readInt(validator) - 1);

            Console.WriteLine("#----------------------------------------------------#");
            Console.Write("# Podaj wartość ({0}): ", this.operation.getFromUnit().name);


            ICustomType res = CustomTypeUtils.createInstanceFrom(
                this.operation.getFromUnit().type,
                (ICustomType) Activator.CreateInstance(this.operation.getFromUnit().type)
            );

            AppConsole.readValueTo(res);
            
            return res;
        }
    }
}
