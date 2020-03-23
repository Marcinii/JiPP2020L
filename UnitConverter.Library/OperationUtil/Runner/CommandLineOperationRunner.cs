using UnitConverter.Library.Converter;
using UnitConverter.Library.Core;
using UnitConverter.Library.OperationUtil.Repository;
using UnitConverter.Library.TypeUtil;

namespace UnitConverter.Library.OperationUtil.Runner
{
    public class CommandLineOperationRunner : OperationRunner<UnitOperation>
    {
        public CommandLineOperationRunner(OperationRepository<UnitOperation> operationRepository) : base(operationRepository) {}

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
