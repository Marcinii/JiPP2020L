using System;
using System.Collections.Generic;
using UnitConverter.Library.TypeUtil;
using UnitConverter.Terminal.Style;
using UnitConverter.Terminal.TableUtil.Cell;
using UnitConverter.Terminal.TableUtil.Row;

namespace UnitConverter.Terminal.TableUtil.Drawer
{
    /// <summary>
    /// Klasa przechowująca zestaw metod do rysowania tabeli
    /// </summary>
    /// <param name="table">Tabela do narysowania</param>
    /// <param name="tableLineSet">
    ///     Zestaw znaków, które posłużą do narysowania obramowania tabeli i komórek
    /// </param>
    /// <param name="cellLengths">
    ///     Lista z liczbami całkowitymi przechowująca wartości najdłuższych komórek w tabeli
    /// </param>
    /// <param name="charLength">Pole przechowujące sumaryczną długość tabeli</param>
    /// <see cref="Table"/>
    /// <see cref="BorderLineSet"/>
    public class TableDrawerUtils
    {
        private Table table;
        private BorderLineSet tableLineSet;
        private List<int> cellLengths;
        private int charLength;

        public TableDrawerUtils(Table table, BorderLineSet tableLineSet)
        {
            this.table = table;
            this.tableLineSet = tableLineSet;
            this.cellLengths = new List<int>();

            this.getLongestCharLength();
        }





        /// <summary>
        /// Metoda rysująca nagłówek tabeli
        /// </summary>
        public void drawTableHeader()
        {
            string columnString = tableLineSet.lineVertical + getPaddingSpace();
            for (int i = 0; i < table.columns.Count; i++)
                columnString += TableCellUtils.getJustifiedText(new TableCell<CustomString>(""), cellLengths[i]) 
                                        + getPaddingSpace() + tableLineSet.lineVertical 
                                        + (
                                            (i < table.columns.Count - 1) ? getPaddingSpace() : ""
                                        );
            Console.WriteLine(columnString);


            drawTableRow(table.columns.ToArray());


            columnString = tableLineSet.lineVertical + getPaddingSpace();
            for (int i = 0; i < table.columns.Count; i++)
                columnString += TableCellUtils.getJustifiedText(new TableCell<CustomString>(""), cellLengths[i])
                                        + getPaddingSpace() + tableLineSet.lineVertical
                                        + (
                                            (i < table.columns.Count - 1) ? getPaddingSpace() : ""
                                        );
            Console.WriteLine(columnString);
        }



        /// <summary>
        /// Metoda wyswietlająca odpowiednio sformatowany wiersz tabeli
        /// </summary>
        /// <param name="arr">Lista komórek do wstawienia</param>
        /// <see cref="ITableCell"/>
        public void drawTableRow(ITableCell[] arr)
        {
            string columnString = "";
            for (int i = 0; i < arr.Length; i++)
                columnString += drawCell(arr[i], cellLengths[i]);

            Console.WriteLine(columnString + tableLineSet.lineVertical);
        }



        /// <summary>
        /// Metoda, która zwraca pierwszy wyświetlany numer wiersza. Jest on zależny od numeru strony,
        /// który oglądamy
        /// </summary>
        /// <returns></returns>
        public int getCurrentFirstRow() => table.pageSize * table.currentPage;



        /// <summary>
        /// Metoda, która zwraca ostatni wyświetlany numer wiersza. Jest on zależny od numeru strony,
        /// który oglądamy
        /// </summary>
        /// <returns></returns>
        public int getCurrentLastRow() => Math.Min(table.pageSize + (table.pageSize * table.currentPage), table.rows.Count);



        /// <summary>
        /// Metoda, która rysuje linię startową (linię, która rozpoczyna rysowanie tabeli)
        /// </summary>
        public void drawStartRule() => drawHorizontalRule(tableLineSet.topLeftCorner, tableLineSet.topRightCorner, tableLineSet.lineHorizontal, tableLineSet.topEnding);
        
        

        /// <summary>
        /// Metoda rysuje linię oddzielającą wiersze w tabeli
        /// </summary>
        public void drawRule() => drawHorizontalRule(tableLineSet.leftEnding, tableLineSet.rightEnding, tableLineSet.lineHorizontal, tableLineSet.cross);
        
        
        
        /// <summary>
        /// Metoda rysująca linie rozdzielającą dane
        /// </summary>
        public void drawSplitterRule() => drawHorizontalRule(tableLineSet.leftEnding, tableLineSet.rightEnding, tableLineSet.lineHorizontal, tableLineSet.lineHorizontal);
        
        
        
        /// <summary>
        /// Metoda rysująca linię pod ostatnim wierszem w tabeli
        /// </summary>
        public void drawEndSplitterRule() => drawHorizontalRule(tableLineSet.leftEnding, tableLineSet.rightEnding, tableLineSet.lineHorizontal, tableLineSet.bottomEnding);



        /// <summary>
        /// Metoda, która rysuje linię, kończącą tabelę
        /// </summary>
        public void drawEndRule() => drawHorizontalRule(tableLineSet.bottomLeftCorner, tableLineSet.bottomRightCorner, tableLineSet.lineHorizontal, tableLineSet.lineHorizontal);



        /// <summary>
        /// Metoda, służąca do rysowania poziomych linii
        /// </summary>
        /// <param name="beginChar">Znak początkowy</param>
        /// <param name="endChar">Znak końcowy</param>
        /// <param name="verticalLineChar">
        ///     Znak poziomy, który jest wyświetlany do wypełnienia przestrzeni między znakiem początkowym, znakiem końcowym oraz znakiem przecięcia linii
        /// </param>
        /// <param name="crossChar">Znak, kóry wyświetlany jest w miejscu przecięcia dwóch linii</param>
        public void drawHorizontalRule(char beginChar, char endChar, char verticalLineChar, char crossChar)
        {
            Console.Write(beginChar);
            int cellLengthsIndex = 1;
            int actualLength = cellLengths[0] + table.cellPadding * 2;
            for (int i = 0; i < charLength - table.cellPadding * 2; i++)
            {
                char hr = verticalLineChar;

                if (i == actualLength && cellLengthsIndex < cellLengths.Count)
                {
                    actualLength += cellLengths[cellLengthsIndex] + table.cellPadding * 2 + 1;
                    cellLengthsIndex++;
                    hr = crossChar;
                }
                Console.Write(hr);
            }
            Console.WriteLine(endChar);
        }



        /// <summary>
        /// Metoda wyświetla informacje odnośnie aktualnie wyświetlanego numeru strony oraz ilości wszystkich stron
        /// </summary>
        public void drawCurrentPageData()
        {
            Console.WriteLine(
                TableCellUtils.getJustifiedText(
                    new TableCell<CustomString>(
                        string.Format("{0} Strona {1}/{2}", tableLineSet.lineVertical, table.currentPage + 1, table.pages + 1)
                    ),
                    charLength - table.cellPadding * 2
                ) + getPaddingSpace() + tableLineSet.lineVertical
            );
        }



        /// <summary>
        /// Metoda, która wyświetla tekst w tabeli
        /// </summary>
        /// <param name="text">Tekst do wyświetlenia</param>
        public void drawText(string text)
        {
            Console.WriteLine(
                TableCellUtils.getJustifiedText(
                    new TableCell<CustomString>(
                        string.Format("{0} {1}", tableLineSet.lineVertical, text)
                    ),
                    charLength - table.cellPadding * 2
                ) + getPaddingSpace() + tableLineSet.lineVertical
            );
        }



        /// <summary>
        /// Metoda, która służy do rozpoczęcia rysowania tabeli
        /// </summary>
        public void start()
        {
            this.charLength = 0;
            this.cellLengths.Clear();
            this.getLongestCharLength();
        }



        /// <summary>
        /// Metoda, służąca do zakończenia rysowania tabeli
        /// </summary>
        public void end()
        {
            this.cellLengths.Clear();
            this.charLength = 0;
        }



        /// <summary>
        /// Metoda zwracająca odpowiednią ilość spacji w celu sformatowania komórki
        /// </summary>
        /// <returns></returns>
        private string getPaddingSpace() => string.Format("{0," + (table.cellPadding / 2) + "}", ' ');



        /// <summary>
        /// Metoda, która ma za zadanie narysowanie komórki tabeli
        /// </summary>
        /// <param name="value">Komórka do wyświetlenia</param>
        /// <param name="cellLength">Długość komórki</param>
        /// <returns>Zwraca odpowiednio sformatowany ciąg znaków zawieracjący wartość komórki</returns>
        /// <see cref="ITableCell"/>
        private string drawCell(ITableCell value, int cellLength)
        {
            return tableLineSet.lineVertical + getPaddingSpace()
                    + TableCellUtils.getJustifiedText(new TableCell<CustomString>(value.ToString(), value.getAlign()), cellLength)
                    + getPaddingSpace();
        }



        /// <summary>
        /// Metoda wyliczająca sumaryczną długość tabeli oraz wylicza największe wartości długości komórek
        /// </summary>
        private void getLongestCharLength()
        {
            int totalDelimiterLength = 0;
            for (int i = 0; i < table.columns.Count; i++)
            {
                totalDelimiterLength += 1 + getPaddingSpace().Length * ((i < table.columns.Count - 1) ? 2 : 1);
                cellLengths.Add(table.columns[i].value.Length);
                charLength += table.columns[i].value.Length + 1 + getPaddingSpace().Length * ((i < table.columns.Count - 1) ? 2 : 1);
            }


            for (int i = getCurrentFirstRow(); i < getCurrentLastRow(); i++)
            {
                string columnString = tableLineSet.lineHorizontal + getPaddingSpace();
                TableRow row = table.rows[i];

                for (int j = 0; j < row.cells.Count; j++)
                {
                    ITableCell cell = row.cells[j];
                    if (cellLengths[j] < row.cells[j].ToString().Length)
                    {
                        int x = row.cells[j].ToString().Length;
                        cellLengths[j] = x + (x % 2 != 0 ? 1 : 0);
                    }

                    columnString += TableCellUtils.getJustifiedText(
                                        cell,
                                        cellLengths[j]) + getPaddingSpace() + tableLineSet.lineHorizontal + (
                                            (j < table.columns.Count - 1) ? getPaddingSpace() : ""
                                        );
                }

                if (charLength < columnString.Length)
                    charLength = columnString.Length;
            }
        }
    }
}
