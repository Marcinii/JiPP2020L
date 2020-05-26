using System;

namespace UnitConverter.Terminal.TableUtil.Cell
{
    /// <summary>
    /// Klasa posiadająca zestaw metod do zarządzania komórką w tabeli
    /// </summary>
    public class TableCellUtils
    {
        /// <summary>
        /// Metoda, która przetwarza wprowadzony tekst wejściowy i ustawia wartość
        /// zgodnie z ustalonym wyrównywaniem tekstu
        /// </summary>
        /// <param name="cell">Komórka, do której chcemy wstawić sformatowaną wartość</param>
        /// <param name="size">Rozmiar komórki</param>
        /// <returns>Zwraca sformatowany ciąg znaków wraz z wstawioną wartością wejściową</returns>
        public static string getJustifiedText(ITableCell cell, int size)
        {
            int diff = Math.Abs(size - cell.ToString().Length);
            string spaces = "";

            for (int i = 0; i < diff; i++) spaces += " ";

            switch(cell.getAlign())
            {
                case TableCellAlign.LEFT: return cell + spaces;
                case TableCellAlign.RIGHT: return spaces + cell;
                case TableCellAlign.CENTER:
                    string halfSpace = spaces.Substring(0, spaces.Length / 2);
                    string additionalSpace = (halfSpace.Length * 2 + cell.ToString().Length < size) ? " " : "";

                    return halfSpace + cell + halfSpace + additionalSpace;
                default: return cell + spaces;
            }
        }
    }
}
