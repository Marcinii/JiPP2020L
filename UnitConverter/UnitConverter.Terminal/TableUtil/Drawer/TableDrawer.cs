using System.Collections.Generic;
using UnitConverter.Terminal.Style;

namespace UnitConverter.Terminal.TableUtil.Drawer
{
    /// <summary>
    /// Klasa, która ma za zadanie narysować tabele w konsoli
    /// </summary>
    /// <param name="table">Tabela do narysowania</param>
    /// <param name="tableDrawerUtils">
    ///     Pole prrzechowujące zestaw metod do rysowania tabeli
    /// </param>
    /// <param name="functions">
    ///     Funkcje, które chcemy dodatkowo uruchomić w ramach tabeli
    /// </param>
    /// <see cref="Table"/>
    /// <see cref="TableDrawerUtils"/>
    /// <see cref="TableDrawerFunction"/>
    public class TableDrawer
    {
        private Table table;
        private TableDrawerUtils tableDrawerUtils;
        private List<TableDrawerFunction> functions;



        public TableDrawer(Table table, BorderStyle style = BorderStyle.DOUBLE_LINE)
        {
            this.table = table;
            this.tableDrawerUtils = new TableDrawerUtils(table, BorderStyleUtils.getStyle(style));
            this.functions = new List<TableDrawerFunction>();
        }



        /// <summary>
        /// Metoda, która dodaje nową funkcję do wyświetlenia tekstu zgodnie z instrukcjami, stwrzonymi przez użytkownika
        /// </summary>
        /// <param name="function">Funkcja, która wstawia nowy tekst</param>
        public void addCustomText(TableDrawerFunction function) => this.functions.Add(function);



        /// <summary>
        /// Metoda wyświetlająca tabele w konsoli
        /// </summary>
        public void draw()
        {
            tableDrawerUtils.start();
            tableDrawerUtils.drawStartRule();
            tableDrawerUtils.drawTableHeader();
            tableDrawerUtils.drawRule();

            for (int i = tableDrawerUtils.getCurrentFirstRow(); i < tableDrawerUtils.getCurrentLastRow(); i++)
            {
                tableDrawerUtils.drawTableRow(table.rows[i].cells.ToArray());

                if (i < tableDrawerUtils.getCurrentLastRow() - 1)
                    tableDrawerUtils.drawRule();
            }

            if (table.rows.Count > table.pageSize)
            {
                tableDrawerUtils.drawEndSplitterRule();
                tableDrawerUtils.drawText("");
                tableDrawerUtils.drawCurrentPageData();

                if (table.currentPage > 0)
                    tableDrawerUtils.drawText("Poprzednia strona (wciśnij strzałkę w lewo lub w górę na klawiaturze)");

                if (table.currentPage < table.pages)
                    tableDrawerUtils.drawText("Następna strona (wciśnij strzałkę w prawo lub w dół na klawiaturze)");

                tableDrawerUtils.drawText("");
            }

            this.functions.ForEach(function =>
            {
                if (table.rows.Count > table.pageSize)
                {
                    tableDrawerUtils.drawSplitterRule();
                }
                else
                {
                    tableDrawerUtils.drawEndSplitterRule();
                }
                tableDrawerUtils.drawText("");
                function(tableDrawerUtils);
                tableDrawerUtils.drawText("");
            });

            tableDrawerUtils.drawSplitterRule();
            tableDrawerUtils.drawText("");
            tableDrawerUtils.drawText("Naciśnij klawisz (Esc), aby wyjść z tabeli");
            tableDrawerUtils.drawText("");
            tableDrawerUtils.drawEndRule();
            tableDrawerUtils.end();
        }
    }
}
