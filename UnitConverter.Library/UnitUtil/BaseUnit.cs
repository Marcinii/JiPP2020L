using System;

namespace UnitConverter.Library.UnitUtil
{
    /// <summary>
    /// Klasa dziedzicząca klasę {Unit}. Służy ona do przechowywania danych odnośnie jednostki bazowej.
    /// </summary>
    /// <see cref="Unit"/>
    public class BaseUnit : Unit
    {
        public BaseUnit(string name, Type type) : base(name, type, value => value, value => value) { }
    }
}
