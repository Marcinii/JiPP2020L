using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia.Logic
{
    public class Book : IBookstoreItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool HardCover { get; set; }

        public float Price { get; set; }
        public int Count { get; set; }
        public int Sold { get; set; }

        public async Task Save()
        {
            using (BookstoreDataModel context = new BookstoreDataModel())
            {
                context.Books.Add(this);
                await context.SaveChangesAsync();
            }
        }

        public async Task Edit()
        {
            using (BookstoreDataModel context = new BookstoreDataModel())
            {
                var result = context.Books.SingleOrDefault(x => x.Id == this.Id);
                result.Title = Title;
                result.Author = Author;
                result.HardCover = HardCover;

                result.Price = Price;
                result.Count = Count;
                result.Sold = Sold;

                await context.SaveChangesAsync();
            }
        }
    }
}
