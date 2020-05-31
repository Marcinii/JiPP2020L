using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class ComBooks
    {
        public List<Ibook> Getbooks()
        {
            return new List<Ibook>()
                {
                new Work(),
                new Private()
            };
        }
    }
}
