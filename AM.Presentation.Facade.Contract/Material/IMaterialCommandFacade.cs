using AM.Application.Contracts.Material;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Material;

public interface IMaterialCommandFacade : IFacadeService
{

    Guid Create(CreateMaterial command);

    void Edit(EditMaterial command);

    void Delete(Guid guid);

    void Activate(Guid guid);

    void Deactivate(Guid guid);
}
