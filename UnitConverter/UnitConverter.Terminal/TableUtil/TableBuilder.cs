using System.Collections.Generic;
using System.Linq;
using UnitConverter.Library.TypeUtil;
using UnitConverter.Terminal.TableUtil.Cell;
using UnitConverter.Terminal.TableUtil.Row;

namespace UnitConverter.Terminal.TableUtil
{
    /// <summary>
    /// Klasa, która ma za zadanie zbudowanie nowej tabeli
    /// </summary>
    /// <param name="instance">Instancja tabeli gotowa do skonfigurowania</param>
    /// <param name="_columns">Lista z kolumnami w tabeli</param>
    /// <param name="_rows">Lista wierszy</param>
    /// <see cref="Table"/>
    /// <see cref="TableCell{T}"/>
    /// <see cref="CustomString"/>
    /// <see cref="TableRow"/>
    public class TableBuilder
    {
        private Table instance;
        private List<TableCell<CustomString>> _columns;
        private List<TableRow> _rows;


        public TableBuilder(Table instance)
        {
            this.instance = instance;
            this._columns = new List<TableCell<CustomString>>();
            this._rows = new List<TableRow>();
        }



        /// <summary>
        /// Metoda dodaje kolumny do listy kolumn w tabeli
        /// </summary>
        /// <param name="columns">Lista z nazwami kolumn</param>
        /// <returns></returns>
        public TableBuilder columns(params string[] columns)
        {
            this._columns = new List<TableCell<CustomString>>(
                columns.Select(x => new TableCell<CustomString>(x, TableCellAlign.CENTER)).ToList()
            );
            return this;
        }



        /// <summary>
        /// Metoda dodaje nowe wiersze do tabeli
        /// </summary>
        /// <param name="rows">Lista wierszy do dodania</param>
        /// <returns></returns>
        /// <see cref="TableRow"/>
        public TableBuilder rows(params TableRow[] rows)
        {
            this._rows = new List<TableRow>(rows);
            return this;
        }




        /// <summary>
        /// Metoda budująca i zwracająca zbudowany obiekt
        /// </summary>
        /// <returns></returns>
        /// <see cref="Table"/>
        public Table build()
        {
            instance.columns = _columns;
            instance.rows = _rows;
            return instance;
        }
    }
}
