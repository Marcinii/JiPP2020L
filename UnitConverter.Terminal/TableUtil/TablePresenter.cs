using System;
using UnitConverter.Terminal.TableUtil.Drawer;

namespace UnitConverter.Terminal.TableUtil
{
    /// <summary>
    /// Klasa odpowiedzialna za wyświetleniw tabeli w sposób interaktywny.
    /// </summary>
    /// <param name="drawer">Obiekt służący do narysowania tabeli</param>
    /// <param name="table">Tabela do narysowania</param>
    /// <see cref="TableDrawer"/>
    /// <see cref="Table"/>
    public class TablePresenter
    {
        private TableDrawer drawer;
        private Table table;

        
        
        public TablePresenter(TableDrawer drawer, Table table)
        {
            this.drawer = drawer;
            this.table = table;
        }



        /// <summary>
        /// Główna metoda startowa prezentera tabeli.
        /// Reaguje ona na wciśnięte klawisze, dzięki czemu na ich podstawie będzie można wykonać odpowiednie operacje
        /// </summary>
        public void presentTable()
        {
            int prevPage = -1;
            ConsoleKey key;
            do
            {
                if (prevPage != table.currentPage)
                {
                    prevPage = table.currentPage;
                    Console.Clear();
                    drawer.draw();
                }

                key = Console.ReadKey().Key;
                if (table.pages > 0)
                {
                    switch (key)
                    {
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.DownArrow:
                            table.nextPage();
                            break;

                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.UpArrow:
                            table.previousPage();
                            break;
                    }
                }
            }
            while (key != ConsoleKey.Escape);
        }
    }
}
