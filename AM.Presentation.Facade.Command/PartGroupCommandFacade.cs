using Ex.Application.Contracts.PartGroup;
using Lab.Presentation.Facade.Contract.PartGroup;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command;

public class PartGroupCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IPartGroupCommandFacade
{
    public Guid Create(CreatePartGroup command)
    {
        return responsiveCommandBus.Dispatch<CreatePartGroup, Guid>(command);
    }

    public void Edit(EditPartGroup command)
    {
        commandBus.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivatePartGroup(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivatePartGroup(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemovePartGroup(guid);
        commandBus.Dispatch(com);
    }
}