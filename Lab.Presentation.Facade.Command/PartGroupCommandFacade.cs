using Ex.Application.Contracts.PartGroup;
using Lab.Presentation.Facade.Contract.PartGroup;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class PartGroupCommandFacade : IPartGroupCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IResponsiveCommandBus _responsiveCommandBus;

        public PartGroupCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
        }

        public Guid Create(CreatePartGroup command)
        {
            return _responsiveCommandBus.Dispatch<CreatePartGroup, Guid>(command);
        }

        public void Edit(EditPartGroup command)
        {
            _commandBus.Dispatch(command);
        }

        public void Deactivate(Guid guid)
        {
            var com = new DeactivatePartGroup(guid);
            _commandBus.Dispatch(com);
        }

        public void Activate(Guid guid)
        {
            var com = new ActivatePartGroup(guid);
            _commandBus.Dispatch(com);
        }

        public void Delete(Guid guid)
        {
            var com = new RemovePartGroup(guid);
            _commandBus.Dispatch(com);
        }
    }
}