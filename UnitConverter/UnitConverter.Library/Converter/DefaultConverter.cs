using UnitConverter.Library.TypeUtil;
using UnitConverter.Library.UnitUtil;

namespace UnitConverter.Library.Converter
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="IConverter"/> służąca do konwersji jednosek miar
    /// 
    /// <param name="value">Wprowadzona wartość wejściowa</param>
    /// <param name="fromUnit">Pole przechowujące informacje odnośnie jednostki, z której mamy konwertować</param>
    /// <param name="toUnit">Pole przechowujące informacje odnośnie jednostki, na którą mamy konwertować</param>
    /// 
    /// <see cref="IConverter"/>
    /// </summary>
    public class DefaultConverter : IConverter<ICustomType>
    {
        protected ICustomType value;
        protected Unit fromUnit;
        protected Unit toUnit;

        public DefaultConverter(ICustomType value, Unit fromUnit, Unit toUnit)
        {
            this.value = value;
            this.fromUnit = fromUnit;
            this.toUnit = toUnit;
        }


        /// <summary>
        /// Metoda konwertująca liczby zgodnie z wybranymi jednostkami.
        /// Konwerter najpierw konwertuję wartość początkową na jednotkę bazową, a tą skonwertowaną wartość
        /// ponownie konwertuje - tym razem na wartość w jednostce docelowej
        /// </summary>
        /// <returns>Zwraca wartość liczby skonwertowanej na inną jednostkę</returns>
        public ICustomType convert() => this.toUnit.fromBaseUnitFormula(this.fromUnit.toBaseUnitFormula(this.value));
    }
}
