using System.Collections.Generic;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.TaskUtil.Parameter;

namespace UnitConverter.Library.TaskUtil.Group
{
    /// <summary>
    /// Klasa dziedzicząca klasę abstrakcyjną <see cref="Task{T}"/> i implementująca interfejs <see cref="ITaskGroup"/>.
    /// Za pomocą tej klasy, możemy utworzyć obiekt, który będzie przechowywał w sobie listę zadań do wykonania.
    /// Klasa ta w momencie uruchamiania wywołuje wszystkie wprowadzone zadania na raz.
    /// Wyniki wykonania operacji są dodawane do listy rezultatów.
    /// </summary>
    /// <param name="tasks">Lista zadań do wykonania</param>
    /// <see cref="Task{T}"/>
    /// <see cref="ITaskGroup"/>
    public class TaskGroup : Task<List<object>>, ITaskGroup
    {
        private List<IRunnable> tasks;




        private TaskGroup()
        {
            this.tasks = new List<IRunnable>();
            this.result = new List<object>();
        }





        /// <summary>
        /// Metoda statyczna, która zwraca obiekt do budowania nowego grupowego zadania
        /// </summary>
        /// <returns>Obiekt budujący zadanie grupowe</returns>
        /// <see cref="TaskGroupBuilder"/>
        public static TaskGroupBuilder builder() => new TaskGroupBuilder(new TaskGroup());



        public override void addParameter(TaskParameter parameter)
        {
            base.addParameter(parameter);
            tasks.ForEach(task => task.addParameter(parameter));
        }




        public override void setParameter(string name, object value)
        {
            base.setParameter(name, value);
            tasks.ForEach(task => task.setParameter(name, value));
        }



        public List<IRunnable> getAllTasks() => tasks;



        public void addTasks(params IRunnable[] tasks)
        {
            foreach (IRunnable task in tasks)
                this.tasks.Add(task);

            for(int i = 1; i < this.tasks.Count; i++)
            {
                tasks[i].addParameter(new InputTaskParameter("$prev", tasks[i - 1].getResultType(), TaskParameterLevel.HIDDEN));
            }
        }




        protected override List<object> apply(Operation operation)
        {
            result.Clear();
            for (int i = 0; i < tasks.Count; i++)
            {
                if (i >= 1)
                {
                    tasks[i].setParameter("$prev", tasks[i - 1].getResult());
                }

                result.Add(tasks[i].run(operation));
            }

            return result;
        }
    }
}
