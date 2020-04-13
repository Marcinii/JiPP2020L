using System;
using UnitConverter.Library.History;
using UnitConverter.Library.TaskUtil.Parameter;

namespace UnitConverter.Library.TaskUtil.Runner
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="TaskRunFunction"/>, reprezentująca nowe zadanie.
    /// Wywoływanie jest po wykonanej konwersji i ma za zadanie zapisać informacje o konwersji w bazie danych.
    /// </summary>
    /// <param name="customDatabaseContext">
    ///     Pole niezbędne do wykonania operacji na bazie danych
    /// </param>
    /// <param name="operationName">Nazwa wykonywanej operacji</param>
    /// <see cref="CustomDatabaseContext"/>
    /// <see cref="TaskRunFunction"/>
    class ConversionTaskAfterRunTaskRunFunction : TaskRunFunction
    {
        private CustomDatabaseContext customDatabaseContext;
        private string operationName;

        public ConversionTaskAfterRunTaskRunFunction(string operationName, CustomDatabaseContext customDatabaseContext)
        {
            this.operationName = operationName;
            this.customDatabaseContext = customDatabaseContext;
        }

        public void apply(IRunnable runnable)
        {
            if(runnable.getParameter("value").value.ToString() != "0")
            {
                customDatabaseContext.conversionHistoryList.Add(new ConversionHistory(
                    operationName,
                    TaskParameterUtils.toSelectableTaskParameter(runnable.getParameter("fromConversion")).getSelectedOption().name,
                    TaskParameterUtils.toSelectableTaskParameter(runnable.getParameter("toConversion")).getSelectedOption().name,
                    runnable.getParameter("value").value.ToString(),
                    runnable.getResult().ToString(),
                    DateTime.Now
                ));

                customDatabaseContext.SaveChanges();
            }
        }
    }
}
