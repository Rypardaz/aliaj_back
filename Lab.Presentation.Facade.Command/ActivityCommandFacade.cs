using Ex.Application.Contracts.Activity;
using Lab.Presentation.Facade.Contract.Activity;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class ActivityCommandFacade : IActivityCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IResponsiveCommandBus _responsiveCommandBus;

        public ActivityCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
        }

        public Guid Create(CreateActivity command)
        {
            return _responsiveCommandBus.Dispatch<CreateActivity, Guid>(command);
        }

        public void Edit(EditActivity command)
        {
            _commandBus.Dispatch(command);
        }

        public void Deactivate(Guid guid)
        {
            var com = new DeactivateActivity(guid);
            _commandBus.Dispatch(com);
        }

        public void Activate(Guid guid)
        {
            var com = new ActivateActivity(guid);
            _commandBus.Dispatch(com);
        }

        public void Delete(Guid guid)
        {
            var com = new RemoveActivity(guid);
            _commandBus.Dispatch(com);
        }
    }
}
