using System.Collections.Generic;
using UnitConverter.Terminal.TableUtil.Cell;

namespace UnitConverter.Terminal.TableUtil.Row
{
    /// <summary>
    /// Klasa, która reprezentuje wiersz w tabeli.
    /// </summary>
    /// <param name="cells">Lista komórek w wierszu</param>
    public class TableRow
    {
        public List<ITableCell> cells { get; set; }

        private TableRow() {
            this.cells = new List<ITableCell>();
        }


        /// <summary>
        /// Metoda, która zwraca obiekt, który będzie budować nowy wiersz tabeli
        /// </summary>
        /// <returns>Obiekt, do budowania wiersza tabeli</returns>
        /// <see cref="TableRowBuilder"/>
        public static TableRowBuilder builder() => new TableRowBuilder(new TableRow());
    }
}
