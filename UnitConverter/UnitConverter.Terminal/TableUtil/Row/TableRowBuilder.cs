using System.Collections.Generic;
using UnitConverter.Terminal.TableUtil.Cell;

namespace UnitConverter.Terminal.TableUtil.Row
{
    /// <summary>
    /// Klasa, która ma za zadanie zbudowanie nowego wiersza tabeli
    /// </summary>
    /// <param name="instance">Instancja wiersza gotowa do skonfigurowania</param>
    /// <param name="_cells">Lista komórek do wstawienia</param>
    /// <see cref="TableRow"/>
    /// <see cref="ITableCell"/>
    public class TableRowBuilder
    {
        private TableRow instance;
        private List<ITableCell> _cells;

        public TableRowBuilder(TableRow instance)
        {
            this.instance = instance;
            this._cells = new List<ITableCell>();
        }




        /// <summary>
        /// Metoda dodająca nowe komórki do wiersza
        /// </summary>
        /// <param name="cells">Lista komórek do wstawienia</param>
        /// <returns></returns>
        /// <see cref="ITableCell"/>
        public TableRowBuilder cells(params ITableCell[] cells)
        {
            this._cells = new List<ITableCell>(cells);
            return this;
        }



        /// <summary>
        /// Metoda budująca i zwracająca zbudowany obiektt
        /// </summary>
        /// <returns></returns>
        /// <see cref="TableRow"/>
        public TableRow build()
        {
            instance.cells = _cells;
            return instance;
        }
    }
}
