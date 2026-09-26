using Ex.Application.Contracts.Personnel;
using Lab.Presentation.Facade.Contract.Personnel;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command;

public class PersonnelCommandFacade(
    ICommandBus commandBus,
    IResponsiveCommandBus responsiveCommandBus,
    IResponsiveCommandBusAsync responsiveCommandBusAsync,
    ICommandBusAsync commandBusAsync)
    : IPersonnelCommandFacade
{
    private readonly IResponsiveCommandBus _responsiveCommandBus = responsiveCommandBus;

    public async Task<Guid> Create(CreatePersonnel command)
    {
        return await responsiveCommandBusAsync.Dispatch<CreatePersonnel, Guid>(command);
    }

    public async Task Edit(EditPersonnel command)
    {
        await commandBusAsync.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivatePersonnel(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivatePersonnel(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemovePersonnel(guid);
        commandBus.Dispatch(com);
    }
}