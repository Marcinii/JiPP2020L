using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia.Logic
{
    public static class DatabaseIO
    {
        public static List<Book> GetBooks()
        {
            using (BookstoreDataModel context = new BookstoreDataModel())
            {
                return context.Books.ToList();
            }
        }
        public static List<Book> GetMagazines()
        {
            using (BookstoreDataModel context = new BookstoreDataModel())
            {
                return context.Books.ToList();
            }
        }
    }
}
