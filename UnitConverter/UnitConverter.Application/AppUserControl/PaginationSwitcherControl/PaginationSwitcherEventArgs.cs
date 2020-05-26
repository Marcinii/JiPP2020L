using System;
using UnitConverter.Library.TypeUtil.Number;

namespace UnitConverter.Application.AppUserControl.PaginationSwitcherControl
{

    /// <summary>
    /// Klasa dziedzicząca klasę <see cref="EventArgs"/>. Jest ona tworzona w momencie
    /// wywołania zdarzenia, które wywołuje się wtedy, gdy dojdzie do zmiany numeru strony
    /// w kontrolce <see cref="PaginationSwitcher"/>
    /// </summary>
    /// <param name="currentPage">Aktualny numer strony, na który został przełączony</param>
    public class PaginationSwitcherEventArgs : EventArgs
    {
        public CustomInteger currentPage { get; private set; }

        public PaginationSwitcherEventArgs(CustomInteger currentPage)
        {
            this.currentPage = currentPage;
        }
    }
}
