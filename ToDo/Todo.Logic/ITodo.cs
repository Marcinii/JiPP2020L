using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Logic
{
    public interface ITodo
    {
        string Title { get; set; }
        string Content { get; set; }
        bool IsFinished { get; set; }
        DateTime date_added { get; set; }
    }
}
