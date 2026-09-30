using AM.Application.Contracts.Material;
using AM.Presentation.Facade.Contract.Material;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class MaterialCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IMaterialCommandFacade
{
    public Guid Create(CreateMaterial command)
    {
        return responsiveCommandBus.Dispatch<CreateMaterial, Guid>(command);
    }

    public void Edit(EditMaterial command)
    {
        commandBus.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivateMaterial(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivateMaterial(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveMaterial(guid);
        commandBus.Dispatch(com);
    }
}