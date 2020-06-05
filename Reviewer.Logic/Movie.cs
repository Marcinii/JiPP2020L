using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reviewer.Logic
{
    public class Movie: IMedia
    {
        public string Type => "Movie";
        public string Color => "Red";
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Score { get; set; }

    }
}
