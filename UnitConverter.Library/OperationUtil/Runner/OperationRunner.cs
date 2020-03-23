using UnitConverter.Library.OperationUtil.Repository;

namespace UnitConverter.Library.OperationUtil.Runner
{
    public abstract class OperationRunner<T> where T : Operation
    {
        public OperationRepository<T> operationRepository { get; private set; }

        protected OperationRunner(OperationRepository<T> operationRepository)
        {
            this.operationRepository = operationRepository;
        }

        public void selectOperation(int command) => this.operationRepository.selectOperation(command);

        public abstract void run();
    }
}
