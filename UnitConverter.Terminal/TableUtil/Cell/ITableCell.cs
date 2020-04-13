using System;

namespace UnitConverter.Terminal.TableUtil.Cell
{
    /// <summary>
    /// Interfejs, który posłuży do utworzenia nowej koórki w tabeli
    /// </summary>
    public interface ITableCell
    {
        /// <summary>
        /// Metoda, która zwraca typ danych przechowywany w komórkach
        /// </summary>
        /// <returns></returns>
        Type getValueType();


        
        /// <summary>
        /// Zwraca informacje odnośnie położenia tekstu w komórce
        /// </summary>
        /// <returns></returns>
        TableCellAlign getAlign();
    }
}
