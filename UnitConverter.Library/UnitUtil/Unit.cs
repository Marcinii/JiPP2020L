using System;
using UnitConverter.Library.TypeUtil;

namespace UnitConverter.Library.UnitUtil
{

    /// <summary>
    /// Klasa reprezentująca typ, która przechowje dane odnoście jednostki miary
    /// <param name="name">Nazwa jednostki</param>
    /// <param name="frombaseUnitFormula">
    ///     Jest to referencja do metody, która przechowuje wzór na skonwertowanie 
    ///     jednostki bazowej na jednostkę, w której obecnie się znajdujemy.
    ///     Np. Jeżeli chcemy skonwertować kilometry na mile, to 'bazową' jednostką dla obu miar będzie metr.
    ///         Wobec czego w tym przykładzie ta formułka posłuży do skonwertowania metrów na kilometry
    /// </param>
    /// <param name="toBaseUnitFormula">
    ///     Jest to referencja do metody, która przechowuje wzór na skonwertowanie 
    ///     jednostki, w której obecnie się znajdujemy na jednostkę bazową.
    ///     Np. Jeżeli chcemy skonwertować kilometry na mile, to 'bazową' jednostką dla obu miar będzie metr.
    ///         Wobec czego w tym przykładzie ta formułka posłuży do skonwertowania kilometrów na metry
    /// </param>
    /// </summary>
    /// <see cref="UnitFormula"/>
    public class Unit
    {
        public string name { get; private set; }
        public Type type { get; private set; }
        public UnitFormula fromBaseUnitFormula { get; private set; }
        public UnitFormula toBaseUnitFormula { get; private set; }

        public Unit(string name, Type type, UnitFormula fromBaseUnitFormula, UnitFormula toBaseUnitFormula)
        {
            this.name = name;
            this.type = type;
            this.fromBaseUnitFormula = fromBaseUnitFormula;
            this.toBaseUnitFormula = toBaseUnitFormula;
        }
    }
}
