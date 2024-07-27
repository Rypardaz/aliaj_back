using Ex.Application.Contracts.Salon;
using Lab.Presentation.Facade.Contract.Salon;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class SalonCommandFacade : ISalonCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IResponsiveCommandBus _responsiveCommandBus;

        public SalonCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
        }

        public Guid Create(CreateSalon command)
        {
            return _responsiveCommandBus.Dispatch<CreateSalon, Guid>(command);
        }

        public void Edit(EditSalon command)
        {
            _commandBus.Dispatch(command);
        }

        public void Deactivate(Guid guid)
        {
            var com = new DeactivateSalon(guid);
            _commandBus.Dispatch(com);
        }

        public void Activate(Guid guid)
        {
            var com = new ActivateSalon(guid);
            _commandBus.Dispatch(com);
        }

        public void Delete(Guid guid)
        {
            var com = new RemoveSalon(guid);
            _commandBus.Dispatch(com);
        }
    }
}