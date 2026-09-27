using AM.Application.Contracts.Activity;
using AM.Presentation.Facade.Contract.Activity;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class ActivityCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IActivityCommandFacade
{
    public Guid Create(CreateActivity command)
    {
        return responsiveCommandBus.Dispatch<CreateActivity, Guid>(command);
    }

    public void Edit(EditActivity command)
    {
        commandBus.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivateActivity(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivateActivity(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveActivity(guid);
        commandBus.Dispatch(com);
    }
}