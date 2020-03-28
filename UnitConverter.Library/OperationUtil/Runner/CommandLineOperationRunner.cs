using UnitConverter.Library.Converter;
using UnitConverter.Library.Core;
using UnitConverter.Library.OperationUtil.Repository;
using UnitConverter.Library.TypeUtil;

namespace UnitConverter.Library.OperationUtil.Runner
{

    /// <summary>
    /// Klasa dziedzicząca klasę obstrakcyjną <see cref="OperationRunner{T}"/> wraz z typem generycznym <see cref="UnitOperation"/>,
    /// która ma za zadanie uruchomienie operacji z poziomu wiersza poleceń
    /// </summary>
    /// <see cref="OperationRunner{T}"/>
    /// <see cref="UnitOperation"/>
    public class CommandLineOperationRunner : OperationRunner<UnitOperation>
    {
        public CommandLineOperationRunner(OperationRepository<UnitOperation> operationRepository) : base(operationRepository) {}




        /// <summary></summary>
        /// <see cref="ConverterWizard"/>
        /// <see cref="ICustomType"/>
        /// <see cref="DefaultConverter"/>
        public override void run()
        {
            ConverterWizard wizard = new ConverterWizard(operationRepository.getSelectedOperation());
            ICustomType value = wizard.run();

            DefaultConverter converter = new DefaultConverter(
                CustomTypeUtils.createInstanceFrom(
                    operationRepository.getSelectedOperation().getFromUnit().type,
                    value
                ),
                operationRepository.getSelectedOperation().getFromUnit(),
                operationRepository.getSelectedOperation().getToUnit()
            );

            converter.print();
        }
    }
}
