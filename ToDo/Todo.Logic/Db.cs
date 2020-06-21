using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Logic
{
    public class Db
    {
        public static List<ToDo> LoadAllUnfinishedTodos()
        {
            using(var context = new TodoModel())
            {
                var query = context.Todos.AsQueryable();
                return query.Where(t => !t.IsFinished).ToList();
            }
        }
        public static void SaveNewTodo(ToDo todo)
        {
            using(var context = new TodoModel())
            {
                context.Todos.Add(todo);
                context.SaveChanges();
            }
        }

        public static void UpdateTodoFinished(ITodo todo)
        {
            using (var context = new TodoModel())
            {
                var result = context.Todos.SingleOrDefault(t => t.date_added == todo.date_added);
                if (result != null)
                {
                    result.IsFinished = todo.IsFinished;
                }
                context.SaveChanges();
            }
        }
    }
}
