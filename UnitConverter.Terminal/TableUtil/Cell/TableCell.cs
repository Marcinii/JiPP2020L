using System;
using UnitConverter.Library.TypeUtil;
using UnitConverter.Library.TypeUtil.Number;

namespace UnitConverter.Terminal.TableUtil.Cell
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="ITableCell"/>, która posłuży do utworzenia nowej komórki w tabeli
    /// </summary>
    /// <typeparam name="T">
    ///     Typ danych, służaćych do przechowania wartości w komórce
    /// </typeparam>
    /// <param name="value">Przechowywana wartość w komórce</param>
    /// <param name="align">Położenie tekstu w komórce</param>
    /// <see cref="ITableCell"/>
    /// <see cref="ICustomType"/>
    /// <see cref="TableCellAlign"/>
    public class TableCell<T> : ITableCell where T : ICustomType
    {
        public T value { get; set; }
        public TableCellAlign align { get; set; }

        public TableCell(T value, TableCellAlign align = TableCellAlign.DEFAULT)
        {
            this.value = value;
            this.align = align;

            if(align == TableCellAlign.DEFAULT)
                this.align = (value is ICustomNumber) ? TableCellAlign.RIGHT : TableCellAlign.LEFT;
        }

        public Type getValueType() => typeof(T);
        public TableCellAlign getAlign() => align;
        public override string ToString() => $"{value}";
    }
}
