using Ex.Application.Contracts.TaskMaster;
using Lab.Presentation.Facade.Contract.TaskMaster;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class TaskMasterCommandFacade : ITaskMasterCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IResponsiveCommandBus _responsiveCommandBus;

        public TaskMasterCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
        }

        public Guid Create(CreateTaskMaster command)
        {
            return _responsiveCommandBus.Dispatch<CreateTaskMaster, Guid>(command);
        }

        public void Edit(EditTaskMaster command)
        {
            _commandBus.Dispatch(command);
        }

        public void Deactivate(Guid guid)
        {
            var com = new DeactivateTaskMaster(guid);
            _commandBus.Dispatch(com);
        }

        public void Activate(Guid guid)
        {
            var com = new ActivateTaskMaster(guid);
            _commandBus.Dispatch(com);
        }

        public void Delete(Guid guid)
        {
            var com = new RemoveTaskMaster(guid);
            _commandBus.Dispatch(com);
        }
    }
}