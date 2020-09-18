using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverterv2.Logic
{
    public class Rating
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public void Save()
        {
            using (ConverterDataModel context = new ConverterDataModel())
            {
                context.Ratings.Add(this);
                context.SaveChanges();
            }
        }
        public static int LoadLastRating()
        {
            using (ConverterDataModel context = new ConverterDataModel())
            {
                try
                {
                    return context.Ratings.OrderByDescending(x => x.Id).Take(1).ToList()[0].Value;
                }
                catch(IndexOutOfRangeException)
                {
                    return 1;
                }
            }
        }
    }
}
