using System;
using System.Collections.Generic;
using UnitConverter.Library.OperationUtil.OpException;
using UnitConverter.Library.UnitUtil;

namespace UnitConverter.Library.OperationUtil
{
    /// <summary>
    /// Klasa reprezentująca zestaw danych i operacji służących do wykonania podstawowych operacji obliczenowych
    /// <param name="id">Numer operacji (wymagany w aplikacji konsolowej)</param>
    /// <param name="name">Nazwa operacji</param>
    /// <param name="units">Wprowadzone jednostki</param>
    /// </summary>
    /// <see cref="Unit"/>
    public class UnitOperation : Operation
    {
        public Type type { get; private set; }
        public List<Unit> units { get; private set; }
        public int fromUnitSelectedIndex { get; private set; }
        public int toUnitSelectedIndex { get; private set; }

        public UnitOperation(int id, string name, Type type) : base(id, name)
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


        public Unit getFromUnit() => this.units[this.fromUnitSelectedIndex];
        public Unit getToUnit() => this.units[this.toUnitSelectedIndex];
        public void selectFromUnit(int command) => this.fromUnitSelectedIndex = command;
        public void selectToUnit(int command) => this.toUnitSelectedIndex = command;
        public bool isFromUnitSelected() => this.fromUnitSelectedIndex > -1;
        public bool isToUnitSelected() => this.toUnitSelectedIndex > -1;
    }
}
