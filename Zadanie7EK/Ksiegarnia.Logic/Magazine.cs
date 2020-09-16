using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia.Logic
{
    public class Magazine : IBookstoreItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }
        public DateTime ReleaseDate { get; set; }

        public float Price { get; set; }
        public int Count { get; set; }
        public int Sold { get; set; }

        public async Task Save()
        {
            using (BookstoreDataModel context = new BookstoreDataModel())
            {
                context.Magazines.Add(this);
                await context.SaveChangesAsync();
            }
        }
        public async Task Edit()
        {
            using (BookstoreDataModel context = new BookstoreDataModel())
            {
                var result = context.Magazines.SingleOrDefault(x => x.Id == this.Id);
                result.Title = Title;
                result.Number = Number;
                result.ReleaseDate = ReleaseDate;

                result.Price = Price;
                result.Count = Count;
                result.Sold = Sold;

                await context.SaveChangesAsync();
            }
        }
    }
}
