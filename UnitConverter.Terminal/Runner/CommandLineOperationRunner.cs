using System;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.OperationUtil.Runner;
using UnitConverter.Library.TaskUtil;
using UnitConverter.Library.TaskUtil.Parameter;
using UnitConverter.Library.TypeUtil;
using UnitConverter.Terminal.Core;

namespace UnitConverter.Terminal.Runner
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="IOperationRunner"/> 
    /// służąca do uruchomienia aplikacji i wyświetlania instrukcji w konsoli, które informują użytkownika  co ma zrobić
    /// </summary>
    /// <param name="finished">Pole przechowujące informacje o tym, czy dana operacja została ukończona</param>
    /// <see cref="IOperationRunner"/>
    class CommandLineOperationRunner : IOperationRunner
    {
        private bool finished;

        public CommandLineOperationRunner() {
            this.finished = false;
        }


        /// <summary>
        /// Metoda zatrzymuje wykonywanie operacji
        /// </summary>
        public void finish() => this.finished = true;


        public void run(Operation operation)
        {
            if(operation.task is ISelectableTask)
            {
                while(!finished)
                {
                    ISelectableTask currentTask = ((ISelectableTask)operation.task);
                    Console.Clear();
                    Console.WriteLine("###################################################################");
                    Console.WriteLine("#-----------------------------------------------------------------#");
                    Console.WriteLine("# Co teraz chcesz zrobić?");
                    Console.WriteLine("#-----------------------------------------------------------------#");

                    currentTask.getOperations().ForEach(op => Console.WriteLine("# {0}. {1}", op.id, op.name));

                    Console.WriteLine("#-----------------------------------------------------------------#");
                    Console.Write("> ");
                    AppConsole.readValueTo<CustomInteger>(callback => currentTask.selectOperation(callback));

                    if (currentTask.getSelectedOperation().id == 0)
                    {
                        if (!currentTask.getSelectedOperation().task.getParameters().exists("commandLineRunner"))
                        {
                            currentTask.getSelectedOperation().task.addParameter(
                                new InputTaskParameter("commandLineRunner", this, false)
                            );
                        }
                        else
                        {
                            currentTask.getSelectedOperation().task.setParameter("commandLineRunner", this);
                        }
                    }

                    Console.Clear();
                    CommandLineOperationRunner runner = new CommandLineOperationRunner();
                    runner.run(currentTask.getSelectedOperation());
                }
            }
            else
            {
                operation.run();
            }
        }
    }
}
