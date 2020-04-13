using UnitConverter.Library.History;
using UnitConverter.Library.TaskUtil;
using UnitConverter.Library.TaskUtil.Group;
using UnitConverter.Library.TaskUtil.Impl;
using UnitConverter.Library.TaskUtil.Parameter;
using UnitConverter.Library.TaskUtil.Runner;
using UnitConverter.Library.TypeUtil;
using UnitConverter.Library.TypeUtil.DateTimeType;
using UnitConverter.Library.TypeUtil.Number;
using UnitConverter.Library.UnitUtil;

namespace UnitConverter.Library.OperationUtil.Repository
{
    /// <summary>
    /// Klasa, która posiada zestaw metod do zainicjalizowania repozytorium z operacjami.
    /// 
    /// <param name="repository">Repozytorium, któe chcemy zainicjalizować</param>
    /// </summary>
    /// <see cref="OperationRepository"/>
    /// <see cref="Operation"/>
    public class OperationRepositoryInitializer
    {
        private OperationRepository repository;
        private CustomDatabaseContext customDatabaseContext;

        public OperationRepositoryInitializer(OperationRepository repository, CustomDatabaseContext customDatabaseContext)
        {
            this.repository = repository;
            this.customDatabaseContext = customDatabaseContext;
        }


        /// <summary>
        /// Metoda, w której inicjalizujemy repozytorium
        /// </summary>
        public void initializeRepository()
        {
            SelectableTaskParameterOption[] temperaturesOptions =
            {
                new SelectableTaskParameterOption(1, "stopnie Celsjusza", typeof(CustomDouble), new BaseUnit(typeof(CustomDouble))),
                new SelectableTaskParameterOption(2, "stopnie Fahrenheitt'a", typeof(CustomDouble),
                    new Unit(
                        typeof(CustomDouble),
                        value => 9 * ((CustomDouble) value) / 5 + 32,
                        value => 5.0 * (((CustomDouble)value) - 32.0) / 9.0
                    )
                ),
                new SelectableTaskParameterOption(3, "stopnie Kelvina", typeof(CustomDouble), 
                    new Unit(
                        typeof(CustomDouble),
                        value => ((CustomDouble)value) + 273.15,
                        value => ((CustomDouble)value) - 273.15
                    )
                )
            };


            SelectableTaskParameterOption[] distanceOptions =
            {
                new SelectableTaskParameterOption(1, "metry", typeof(CustomDouble), new BaseUnit(typeof(CustomDouble))),
                new SelectableTaskParameterOption(2, "kilometry", typeof(CustomDouble),
                    new Unit(
                        typeof(CustomDouble),
                        value => ((CustomDouble)value) / 1000,
                        value => ((CustomDouble)value) * 1000
                    )
                ),
                new SelectableTaskParameterOption(3, "mile", typeof(CustomDouble),
                    new Unit(
                        typeof(CustomDouble),
                        value => ((CustomDouble)value) / 1609.344,
                        value => ((CustomDouble)value) * 1609.344
                    )
                )
            };


            SelectableTaskParameterOption[] weightOptions =
            {
                new SelectableTaskParameterOption(1, "gramy", typeof(CustomDouble), new BaseUnit(typeof(CustomDouble))),
                new SelectableTaskParameterOption(2, "kilogramy", typeof(CustomDouble), 
                    new Unit(
                        typeof(CustomDouble),
                        value => ((CustomDouble)value) / 1000,
                        value => ((CustomDouble)value) * 1000
                    )
                ),
                new SelectableTaskParameterOption(3, "funty", typeof(CustomDouble),
                    new Unit(
                        typeof(CustomDouble),
                        value => ((CustomDouble)value) * 0.00220462262,
                        value => ((CustomDouble)value) / 0.00220462262
                    )
                )
            };



            SelectableTaskParameterOption[] velocityOptions =
            {
                new SelectableTaskParameterOption(1, "litry", typeof(CustomDouble), new BaseUnit(typeof(CustomDouble))),
                new SelectableTaskParameterOption(2, "metry sześcienne", typeof(CustomDouble),
                    new Unit(
                        typeof(CustomDouble),
                        value => ((CustomDouble)value) / 1000,
                        value => ((CustomDouble)value) * 1000
                    )
                ),
                new SelectableTaskParameterOption(3, "galony", typeof(CustomDouble),
                    new Unit(
                        typeof(CustomDouble),
                        value => ((CustomDouble)value) / 3.78541178,
                        value => ((CustomDouble)value) * 3.78541178
                    )
                )
            };


            SelectableTaskParameterOption[] timesOptions =
            {
                new SelectableTaskParameterOption(1, "24-godzinny", typeof(CustomTime), new BaseUnit(typeof(CustomTime))),
                new SelectableTaskParameterOption(2, "12-godzinny", typeof(Custom12HTime),
                    new Unit(
                        typeof(Custom12HTime),
                        value => Custom12HTime.fromCustomTime((CustomTime)value),
                        value => CustomTime.fromCustom12HTime(Custom12HTime.fromCustomTime((CustomTime) value))
                    )
                )
            };







            SelectableTaskParameterBuilder fromConversionTaskParameterBuilder = new SelectableTaskParameterBuilder()
                    .name("fromConversion").label("Z czego chcesz konwertować");

            SelectableTaskParameterBuilder toConversionTaskParameterBuilder = new SelectableTaskParameterBuilder()
                    .name("toConversion").label("Na co chcesz konwertować");







            VoidOperation conversionOperation = new VoidOperation(1, "Konwersja jednostek", new SelectableTask(
                new DefaultOperation(1, "Konwersja temperatury",
                    new TaskBuilder()
                        .instance(new ConversionTask())
                        .parameters(
                            fromConversionTaskParameterBuilder.options(temperaturesOptions).build(),
                            toConversionTaskParameterBuilder.options(temperaturesOptions).build(),
                            new InputTaskParameter("value", typeof(CustomInteger), 0)
                        )
                        .afterRun(new ConversionTaskAfterRunTaskRunFunction("Konwersja temperatury", customDatabaseContext))
                        .build()
                ),
                new DefaultOperation(2, "Konwersja długości",
                    new TaskBuilder()
                        .instance(new ConversionTask())
                        .parameters(
                            fromConversionTaskParameterBuilder.options(distanceOptions).build(),
                            toConversionTaskParameterBuilder.options(distanceOptions).build(),
                            new InputTaskParameter("value", typeof(CustomInteger))
                        )
                        .afterRun(new ConversionTaskAfterRunTaskRunFunction("Konwersja długości", customDatabaseContext))
                        .build()
                ),
                new DefaultOperation(3, "Konwersja masy",
                    new TaskBuilder()
                        .instance(new ConversionTask())
                        .parameters(
                            fromConversionTaskParameterBuilder.options(weightOptions).build(),
                            toConversionTaskParameterBuilder.options(weightOptions).build(),
                            new InputTaskParameter("value", typeof(CustomInteger))
                        )
                        .afterRun(new ConversionTaskAfterRunTaskRunFunction("Konwersja masy", customDatabaseContext))
                        .build()
                ),
                new DefaultOperation(4, "Konwersja objętości",
                    new TaskBuilder()
                        .instance(new ConversionTask())
                        .parameters(
                            fromConversionTaskParameterBuilder.options(velocityOptions).build(),
                            toConversionTaskParameterBuilder.options(velocityOptions).build(),
                            new InputTaskParameter("value", typeof(CustomInteger))
                        )
                        .afterRun(new ConversionTaskAfterRunTaskRunFunction("Konwersja objętości", customDatabaseContext))
                        .build()
                ),
                new DefaultOperation(5, "Konwersja czasu",
                    new TaskBuilder()
                        .instance(new ConversionTask())
                        .parameters(
                            fromConversionTaskParameterBuilder.options(timesOptions).build(),
                            toConversionTaskParameterBuilder.options(timesOptions).build(),
                            new InputTaskParameter("value", typeof(CustomTime))
                        )
                        .afterRun(new ConversionTaskAfterRunTaskRunFunction("Konwersja czasu", customDatabaseContext))
                        .build()
                )
            ));

            repository.addOperation(conversionOperation);




            DefaultOperation statisticsOperation = new DefaultOperation(2, "Wyświetl statystyki konwersji",
                TaskGroup.builder()
                    .tasks(
                        new FindAllConversionHistoryTask(customDatabaseContext),
                        new FindTopThreeConversionsTask(customDatabaseContext)
                    )
                    .parameters(
                        new InputTaskParameter("Nazwa konwertera", typeof(CustomString), TaskParameterLevel.OPTIONAL),
                        new InputTaskParameter("Data początkowa", typeof(CustomDate), TaskParameterLevel.OPTIONAL),
                        new InputTaskParameter("Data końcowa", typeof(CustomDate), TaskParameterLevel.OPTIONAL)
                    )
                    .build()
            );

            repository.addOperation(statisticsOperation);
        }
    }
}
