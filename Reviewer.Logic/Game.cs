using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reviewer.Logic
{
    public class Game: IMedia
    {
        public string Type => "Game";
        public string Color => "Green";
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Score { get; set; }
    }
}
