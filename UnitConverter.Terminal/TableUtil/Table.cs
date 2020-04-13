using System.Collections.Generic;
using UnitConverter.Library.TypeUtil;
using UnitConverter.Terminal.TableUtil.Cell;
using UnitConverter.Terminal.TableUtil.Row;

namespace UnitConverter.Terminal.TableUtil
{
    /// <summary>
    /// Klasa reprezentująca tabelę danych.
    /// </summary>
    /// <param name="_rows">Lista wierszy w tabeli</param>
    /// <param name="columns">Kolumny tabeli</param>
    /// <param name="cellPadding">Odstęp między tekstem a obramowaniem</param>
    /// <param name="pageSize">Limit wyświetlanych wierszy w tabeli</param>
    /// <param name="currentPage">Aktualny numer strony</param>
    /// <param name="pages">Liczba stron</param>
    /// <see cref="TableRow"/>
    /// <see cref="TableCell{T}"/>
    /// <see cref="CustomString"/>
    public class Table
    {
        private List<TableRow> _rows;

        public List<TableCell<CustomString>> columns;
        public int cellPadding { get; set; }
        public int pageSize { get; set; }
        public int currentPage { get; set; }
        public int pages { get; set; }

        public List<TableRow> rows
        {
            get => _rows;
            set
            {
                this._rows = value;
                this.pages = this.rows.Count / this.pageSize;
            }
        }



        private Table()
        {
            this._rows = new List<TableRow>();
            this.cellPadding = 1;
            this.pageSize = 20;
            this.currentPage = 0;
            this.pages = 0;
        }





        /// <summary>
        /// Metoda zwracająca obiekt do bodowania nowej tabeli
        /// </summary>
        /// <returns>Obiekt do budowania nowej tabeli</returns>
        /// <see cref="TableBuilder"/>
        public static TableBuilder builder() => new TableBuilder(new Table());



        /// <summary>
        /// Metoda dodaje nowy wiersz w tabeli
        /// </summary>
        /// <param name="row">Wiersz do dodania</param>
        /// <see cref="TableRow"/>
        public void addRow(TableRow row)
        {
            this.rows.Add(row);
            this.pages = this.rows.Count / this.pageSize;
        }



        /// <summary>
        /// Metoda przełącza tabele na następną stronę
        /// </summary>
        public void nextPage()
        {
            if (currentPage < pages) currentPage++;
        }



        /// <summary>
        /// Metoda przełącza tabele na poprzednią stronę
        /// </summary>
        public void previousPage()
        {
            if (currentPage > 0) currentPage--;
        }



        /// <summary>
        /// Metoda sprawdzająca czy aktualny numer strony odpowiada pierwszej stronie
        /// </summary>
        /// <returns>
        ///     Zwraca prawdę, jeżeli aktualny numer strony odpowiada pierwszej stronie.
        ///     Zwraca fałsz w przeciwnym przypadku
        /// </returns>
        public bool isFirstPage() => currentPage == 0;



        /// <summary>
        /// Metoda sprawdzająca czy aktualny numer strony odpowiada ostatniej stronie
        /// </summary>
        /// <returns>
        ///     Zwraca prawdę, jeżeli aktualny numer strony odpowiada ostatniej stronie.
        ///     Zwraca fałsz w przeciwnym przypadku
        /// </returns>
        public bool isLastPage() => currentPage == pages;



        /// <summary>
        /// Metoda, która przełącza tabele na stronę wskazaną w parametrze
        /// </summary>
        /// <param name="page">Numer strony</param>
        public void goToPage(int page)
        {
            page--;
            if (page < 0 || page > pages) return;

            this.currentPage = page;
        }
    }
}
