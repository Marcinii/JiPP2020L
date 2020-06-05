using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reviewer.Logic
{
    public class Book: IMedia
    {
        public string Type => "Book";
        public string Color => "Blue";
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Score { get; set; }
    }
}
