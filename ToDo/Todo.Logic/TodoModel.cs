namespace Todo.Logic
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TodoModel : DbContext
    {
        public TodoModel()
            : base("name=TodoModel")
        {
        }

        public virtual DbSet<ToDo> Todos { get; set; }
    }
}