using AM.Application.Contracts.Salon;
using AM.Presentation.Facade.Contract.Salon;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class SalonCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : ISalonCommandFacade
{
    public Guid Create(CreateSalon command)
    {
        return responsiveCommandBus.Dispatch<CreateSalon, Guid>(command);
    }

    public void Edit(EditSalon command)
    {
        commandBus.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivateSalon(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivateSalon(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveSalon(guid);
        commandBus.Dispatch(com);
    }
}