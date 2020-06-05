using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reviewer.Logic
{
    public interface IMedia
    {
        string Type { get; }
        string Color { get; }
        string Title { get; set; }
        string ReleaseDate { get; set; }
        string Description { get; set; }
        string Score { get; set; }
    }
}
