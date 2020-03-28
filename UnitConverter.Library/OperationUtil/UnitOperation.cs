using System;
using System.Linq;
using System.Collections.Generic;
using UnitConverter.Library.OperationUtil.OpException;
using UnitConverter.Library.UnitUtil;
using UnitConverter.Library.TypeUtil;

namespace UnitConverter.Library.OperationUtil
{
    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="Operation"/>, która zawiera zestaw danych do wykonywania operacji
    /// na jednostkach miar
    /// 
    /// <param name="type">Typ danych w przechowywanych jednostkach</param>
    /// <param name="units">Wprowadzone jednostki</param>
    /// <param name="fromUnitSelectedIndex">
    ///     Wartość indeksu odpowiadająca wybranej jednostce, z której chcemy wykonać konwersję
    /// </param>
    /// <param name="toUnitSelectedIndex">
    ///     Wartość indeksu odpowiadająca wybranej jednostce, na którą chcemy wykonać konwersję
    /// </param>
    /// </summary>
    /// <see cref="Unit"/>
    /// <see cref="Operation" />
    public class UnitOperation : Operation
    {
        public Type type { get; private set; }
        public List<Unit> units { get; private set; }
        public CustomInteger fromUnitSelectedIndex { get; private set; }
        public CustomInteger toUnitSelectedIndex { get; private set; }

        public UnitOperation(CustomInteger id, string name, Type type) : base(id, name)
        {
            this.type = type;
            this.units = new List<Unit>();
            this.fromUnitSelectedIndex = -1;
            this.toUnitSelectedIndex = -1;
        }



        /// <summary>
        /// Metoda służąca do dodawania nowych jednostek do listy
        /// </summary>
        /// <param name="unit">Jednostka</param>
        public void addUnit(Unit unit)
        {
            if(unit.type != this.type && !unit.type.IsSubclassOf(this.type))
            {
                throw new OperationException(
                    string.Format(
                        "Nie można dodać objektu Unit o typie \'{0}\', ponieważ wynagany jest typ \'{1}\'",
                        unit.type.ToString(),
                        this.type.ToString()
                    )
                );
            }

            this.units.Add(unit);
        }


        /// <summary>
        /// Metoda zwraca zaznaczoną jednostkę miary, z której chcemy konwertować
        /// </summary>
        /// <returns>Element typu Unit</returns>
        /// <see cref="Unit"/>
        public Unit getFromUnit() => this.units[this.fromUnitSelectedIndex.toPrimitiveValue()];



        /// <summary>
        /// Metoda zwraca zaznaczoną jednostkę miary, na którą chcemy konwertować
        /// </summary>
        /// <returns>Element typu Unit</returns>
        /// <see cref="Unit"/>
        public Unit getToUnit() => this.units[this.toUnitSelectedIndex.toPrimitiveValue()];



        /// <summary>
        /// Metoda, która wybiera jednostkę, z której chcemy konwertować
        /// </summary>
        /// <param name="command">Numer jednostki</param>
        public void selectFromUnit(CustomInteger command)
        {
            if(command < 0 || command > this.units.Count)
                throw new UnitOperationNotFoundException();

            this.fromUnitSelectedIndex = command;
        }



        /// <summary>
        /// Metoda, która wybiera jednostkę, na którą chcemy konwertować
        /// </summary>
        /// <param name="command">Numer jednostki</param>
        public void selectToUnit(CustomInteger command)
        {
            if (command < 0 || command > this.units.Count)
                throw new UnitOperationNotFoundException();

            this.toUnitSelectedIndex = command;
        }



        /// <summary>
        /// Metoda sprawdzająca, czy jednostka, z której chcemy konwertować jest wybrana
        /// </summary>
        /// <returns>
        ///     Zwraca true jeżeli jednostka została wybrana, w przeciwnym wypadku - false
        /// </returns>
        public bool isFromUnitSelected() => this.fromUnitSelectedIndex > -1;



        /// <summary>
        /// Metoda sprawdzająca, czy jednostka, na którą chcemy konwertować jest wybrana
        /// </summary>
        /// <returns>
        ///     Zwraca true jeżeli jednostka została wybrana, w przeciwnym wypadku - false
        /// </returns>
        public bool isToUnitSelected() => this.toUnitSelectedIndex > -1;
    }
}
