using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ibook> books = new Book.ComBooks().Getbooks();
        }
    }
}
